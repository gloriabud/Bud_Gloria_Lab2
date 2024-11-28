﻿using Bud_Gloria_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bud_Gloria_Lab2.Data
{
    public class Bud_Gloria_Lab2Context : DbContext
    {
        public Bud_Gloria_Lab2Context(DbContextOptions<Bud_Gloria_Lab2Context> options)
            : base(options)
        {
        }

        // Modificat pentru a reflecta pluralizarea corectă
        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<Publisher> Publishers { get; set; }

        // Corectat pentru a reflecta denumirea corectă a clasei Author
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Bud_Gloria_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
