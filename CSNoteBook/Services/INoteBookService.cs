using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public interface INoteBookService
    {
        int NewNote(string title = null,string context = null);
        void DeleteNote(int id);
        Note GetNote(int id);
        Note[] GetAllNote();
        int[] GetAllNoteIndex();
        void EditNote(int id,string title, string context);
    }
}