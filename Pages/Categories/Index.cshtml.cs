using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bud_Gloria_Lab2.Data;
using Bud_Gloria_Lab2.Models;
using Bud_Gloria_Lab2.ViewModels;

namespace Bud_Gloria_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Bud_Gloria_Lab2.Data.Bud_Gloria_Lab2Context _context;

        public IndexModel(Bud_Gloria_Lab2.Data.Bud_Gloria_Lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData(); // Inițializare implicită
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;

                var selectedCategory = CategoryData.Categories
                    .FirstOrDefault(c => c.ID == id.Value);

                if (selectedCategory?.BookCategories != null)
                {
                    CategoryData.Books = selectedCategory.BookCategories
                        .Where(bc => bc.Book != null) // Verificăm dacă Book nu este null
                        .Select(bc => bc.Book!)
                        .ToList();
                }
            }
        }
    }
}
