using CSNoteBook.DAO;
using CSNoteBook.Test;

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
      NoteBookDao.Instance.Init();

      //调用测试方法
      //Test.Test.TestMethod(null);
    }
  }
}
