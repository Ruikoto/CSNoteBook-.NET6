using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using CSNoteBook.Models;
using CSNoteBook.Services;
using CSNoteBook.ViewModels;

namespace CSNoteBook.Views
{
    /// <summary>
    /// AddNoteView.xaml 的交互逻辑
    /// </summary>
    public partial class AddNoteView : UserControl
    {
        //构造函数
        public AddNoteView()
        {
            InitializeComponent();
            this.DataContext = new AddNoteViewModel();
        }
    }
}
