using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSNoteBook.Models
{
    public class Note : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}