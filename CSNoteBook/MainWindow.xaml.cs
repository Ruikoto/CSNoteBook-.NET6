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
      GetDaoFactory.GetDao().Init();
      Test.Test.TestMethod(null);
    }

  }
}
