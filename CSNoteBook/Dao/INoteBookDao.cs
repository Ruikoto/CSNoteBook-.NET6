using System;
using CSNoteBook.Models;

namespace CSNoteBook.DAO
{
    public interface INoteBookDao
    {
        int NewNote(string title, string content);
        int EditNote(int id, string title, string content);
        int GetNewIndex();
        void DeleteNote(int id);
        bool IsNoteExist(int id);
        Note GetNote(int id);
        Note[] GetAllNote();
        int[] GetAllNoteIndex();
    }
}