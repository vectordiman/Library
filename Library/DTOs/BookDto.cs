using System;

namespace Library.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
    }
}