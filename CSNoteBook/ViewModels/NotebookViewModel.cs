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
        public ObservableCollection<Note> Notes { get; private set; }

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

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}