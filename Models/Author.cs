using System.ComponentModel.DataAnnotations;

namespace Bud_Gloria_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; } // Cheia primară
        public string FirstName { get; set; } // Prenume
        public string LastName { get; set; } // Nume

        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;

        // Relație cu Book
        public ICollection<Book>? Books { get; set; } // Navigation property
    }
}

