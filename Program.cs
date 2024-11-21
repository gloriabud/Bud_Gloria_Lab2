using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bud_Gloria_Lab2.Data;
using Bud_Gloria_Lab2.Models; // Importă modelul Author
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Bud_Gloria_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Bud_Gloria_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Bud_Gloria_Lab2Context' not found.")));

var app = builder.Build();

// Insert authors if they don't already exist
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Bud_Gloria_Lab2Context>();

    // Verifică dacă există deja autori în tabelă
    if (!context.Authors.Any())
    {
        // Creează autori
        var author1 = new Author { FirstName = "John", LastName = "Doe" };
        var author2 = new Author { FirstName = "Jane", LastName = "Smith" };

        // Adaugă autorii în context
        context.Authors.AddRange(author1, author2);
        context.SaveChanges(); // Salvează modificările în baza de date
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
