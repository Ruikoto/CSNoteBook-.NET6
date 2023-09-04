using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using CSNoteBook.Models;
using CSNoteBook.Services;
using CSNoteBook.ViewModels;

public class AddNoteViewModel : INotifyPropertyChanged
{
    public Note Model { get; } = new Note();
    public ICommand SubmitCommand { get; }

    public AddNoteViewModel()
    {
        this.SubmitCommand = new RelayCommand(Submit, CanSubmit);
    }

    private bool CanSubmit(object obj)
    {
        return true;
    }

    private void Submit(object obj)
    {
        if (string.IsNullOrEmpty(Model.Title)) return;
        INoteBookService service = new NoteBookService();
        service.NewNote(Model.IsChecked, Model.Title);
        Model.Title = "";
        OnPropertyChanged(nameof(Model));
        NotebookViewModel.Instance.LoadNotes();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
