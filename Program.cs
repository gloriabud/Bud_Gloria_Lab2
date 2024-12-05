using Microsoft.EntityFrameworkCore;
using Bud_Gloria_Lab2.Data;
using Bud_Gloria_Lab2.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Bud_Gloria_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Bud_Gloria_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Bud_Gloria_Lab2Context' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Bud_Gloria_Lab2Context") ?? throw new InvalidOperationException("Connectionstring 'Bud_Gloria_Lab2Context' not found."))); 



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Bud_Gloria_Lab2Context>();

    // Apply migrations
    context.Database.Migrate();

    // Seed authors if the table is empty
    if (!context.Authors.Any())
    {
        var authors = new[]
        {
            new Author { FirstName = "John", LastName = "Doe" },
            new Author { FirstName = "Jane", LastName = "Smith" }
        };

        context.Authors.AddRange(authors);
        context.SaveChanges(); // Save changes to the database
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
