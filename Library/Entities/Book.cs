using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Entities
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
    }
}
