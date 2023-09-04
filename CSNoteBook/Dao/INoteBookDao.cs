using System;
using System.Collections.Generic;
using CSNoteBook.Models;

namespace CSNoteBook.DAO
{
    public interface INoteBookDao
    {
        void Init();
        int NewNote(int isChecked, string title, string content);
        void EditNote(int id, int isChecked, string title, string content);
        void DeleteNote(int id);
        bool IsNoteExist(int id);
        Note GetNote(int id);
        List<Note> GetAllNote();
        List<int> GetAllNoteIndex();
    }
}