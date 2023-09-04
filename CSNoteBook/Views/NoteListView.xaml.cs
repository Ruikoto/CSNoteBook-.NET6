using System;
using System.Collections.Generic;
using System.Linq;
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
using CSNoteBook.ViewModels;

namespace CSNoteBook.Views
{
    /// <summary>
    /// NoteListView.xaml 的交互逻辑
    /// </summary>
    public partial class NoteListView : UserControl
    {
        public NoteListView()
        {
            InitializeComponent();

            //绑定DataContext
            var viewModels = NotebookViewModel.Instance;
            this.DataContext = viewModels;

            //添加事件，窗口加载完成后加载笔记
            Loaded += (sender, e)=> viewModels.LoadNotes();
        }
    }
}
