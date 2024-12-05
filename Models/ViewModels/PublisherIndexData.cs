﻿using Bud_Gloria_Lab2.Models;

namespace Bud_Gloria_Lab2.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; } = new List<Publisher>();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    
    }
}

