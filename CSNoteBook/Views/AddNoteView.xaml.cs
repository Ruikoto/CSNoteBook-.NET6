using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSNoteBook.Models;
using CSNoteBook.Services;
using CSNoteBook.ViewModels;


namespace CSNoteBook.Views
{
    /// <summary>
    /// AddNoteView.xaml 的交互逻辑
    /// </summary>
    public partial class AddNoteView : UserControl,INotifyPropertyChanged
    {
        public Note Model { get; } = new Note();
        public ICommand SubmitCommand { get; }


        public AddNoteView()
        {
            this.SubmitCommand = new RelayCommand(Submit, CanSubmit);
            InitializeComponent();
            this.DataContext = this;
        }
        private bool CanSubmit(object obj)
        {
            //return Model.Content != null;
            return true;
        }

        private void Submit(object obj)
        {
            INoteBookService service = new NoteBookService();
            service.NewNote(Model.IsChecked,Model.Title);
            Model.Title = "";
            OnPropertyChanged(nameof(Model));
            NotebookViewModel.Instance.LoadNotes();
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
