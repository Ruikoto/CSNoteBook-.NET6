using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CSNoteBook.Models;
using CSNoteBook.Services;

namespace CSNoteBook.ViewModels
{
    public class AddNoteViewModel : INotifyPropertyChanged
    {
        //模型
        public Note Model { get; } = new Note();
        //提交命令
        public ICommand SubmitCommand { get; }

        //构造函数
        public AddNoteViewModel()
        {
            this.SubmitCommand = new RelayCommand(Submit, CanSubmit);
        }

        //判断是否可以提交
        private bool CanSubmit(object obj)
        {
            return !string.IsNullOrEmpty(Model.Title);
        }

        //提交
        private void Submit(object obj)
        {
            if (string.IsNullOrEmpty(Model.Title)) return;
            INoteBookService service = new NoteBookService();
            service.AddNote(Model.IsChecked, Model.Title);
            Model.Title = "";
            OnPropertyChanged(nameof(Model));
            NotebookViewModel.Instance.LoadNotes();
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
