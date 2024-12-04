using System.Collections.Generic;
using Bud_Gloria_Lab2.Models;

namespace Bud_Gloria_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Book>? Books { get; set; }
    }
}
