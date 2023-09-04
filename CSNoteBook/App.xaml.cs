using System.Windows;
using CSNoteBook.DAO;

namespace CSNoteBook
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
      //程序退出时关闭数据库
      private void Application_Exit(object sender, ExitEventArgs e)
      {
          NoteBookDao.Instance.Close();
      }
  }
}
