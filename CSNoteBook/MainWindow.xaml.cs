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
      Test.Test.TestMethod(null);
    }

  }
}
