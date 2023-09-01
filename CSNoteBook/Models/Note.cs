using System;

namespace CSNoteBook.Models
{
    public class Note
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Context { get; set; }
    }
}