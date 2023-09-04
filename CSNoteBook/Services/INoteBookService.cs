using System.Collections.Generic;
using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public interface INoteBookService
    {
        int NewNote(bool isChecked = false,string title = "",string content = "");
        void DeleteNote(int id);
        Note GetNote(int id);
        List<Note> GetAllNote();
        List<int> GetAllNoteIndex();
        void EditNote(int id,bool isChecked,string title, string content);
    }
}