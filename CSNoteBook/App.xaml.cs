using System.Windows;
using CSNoteBook.DAO;

namespace CSNoteBook
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
      private void Application_Exit(object sender, ExitEventArgs e)
      {
          NoteBookDao.Instance.Close();
      }
  }
}
