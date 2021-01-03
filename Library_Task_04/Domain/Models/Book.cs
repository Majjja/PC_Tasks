using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
    }
}
