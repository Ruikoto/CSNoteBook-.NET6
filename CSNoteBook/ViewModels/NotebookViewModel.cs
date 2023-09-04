using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSNoteBook.Models;
using CSNoteBook.Services;

namespace CSNoteBook.ViewModels
{
    public class NotebookViewModel : INotifyPropertyChanged
    {
        //单例模式
        private static NotebookViewModel _instance;
        public static NotebookViewModel Instance => _instance ?? (_instance = new NotebookViewModel());

        //新建ObservableCollection字段
        private ObservableCollection<Note> _notes;

        //ObservableCollection属性的get和set方法
        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set
            {
                if (_notes == value) return;
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }

        //属性改变事件
        public event PropertyChangedEventHandler PropertyChanged;

        //属性改变方法
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //加载/重新加载笔记
        public void LoadNotes()
        {
            var notesFromDb = new NoteBookService().GetAllNote();
            Notes = new ObservableCollection<Note>(notesFromDb);
            OnPropertyChanged(nameof(Notes));
        }
    }
}