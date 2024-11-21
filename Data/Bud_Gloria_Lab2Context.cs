using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bud_Gloria_Lab2.Models;

namespace Bud_Gloria_Lab2.Data
{
    public class Bud_Gloria_Lab2Context : DbContext
    {
        public Bud_Gloria_Lab2Context (DbContextOptions<Bud_Gloria_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Bud_Gloria_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Publisher> Publishers { get; set; }
    }
}
