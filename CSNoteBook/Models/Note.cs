using System;

namespace CSNoteBook.Models
{
    public class Note
    {
        public int Id { get;  set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }

        public Note()
        {
        }

        public Note(int id, string title, string content, bool isChecked)
        {
            Id = id;
            Title = title;
            Content = content;
            IsChecked = isChecked;
        }

        public override string ToString()
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (IsChecked)
            {
                return $@"(*)Note #{Id}: Title: {Title}, Content: {Content}";
            }
            else
            {
                return $@"( )Note #{Id}: Title: {Title}, Content: {Content}";
            }

        }
    }
}