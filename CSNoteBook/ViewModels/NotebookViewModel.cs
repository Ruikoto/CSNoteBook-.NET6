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
        private static NotebookViewModel _instance;

        public static NotebookViewModel Instance => _instance ?? (_instance = new NotebookViewModel());

        private ObservableCollection<Note> _notes;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadNotes()
        {
            var notesFromDb = new NoteBookService().GetAllNote();
            Notes = new ObservableCollection<Note>(notesFromDb);
            OnPropertyChanged(nameof(Notes));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}