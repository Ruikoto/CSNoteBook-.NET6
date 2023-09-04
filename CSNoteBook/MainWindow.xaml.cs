using System.Windows;
using CSNoteBook.DAO;
using CSNoteBook.Test;
using CSNoteBook.Utils;

namespace CSNoteBook
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();

      //初始化Dao
      GetDaoFactory.GetDao().Init();

      //调用测试方法
      //Test.Test.TestMethod(null);
    }
  }
}
