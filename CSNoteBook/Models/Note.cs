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

        //无参构造
        public Note()
        {
        }

        //全参构造
        public Note(int id, string title, string content, bool isChecked)
        {
            Id = id;
            Title = title;
            Content = content;
            IsChecked = isChecked;
        }

        //重写ToString方法
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

        //属性改变事件
        public event PropertyChangedEventHandler PropertyChanged;

        //属性改变方法
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}