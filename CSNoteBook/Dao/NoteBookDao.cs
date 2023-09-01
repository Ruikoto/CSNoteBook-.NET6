using CSNoteBook.Models;
using CSNoteBook.Services;

namespace CSNoteBook.DAO
{
    public class NoteBookDao : INoteBookDao
    {
        public int NewNote(string title, string context)
        {
            throw new System.NotImplementedException();
        }

        public int EditNote(int id, string title, string context)
        {
            throw new System.NotImplementedException();
        }

        public int GetNewIndex()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteNote(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool IsNoteExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public Note GetNote(int id)
        {
            throw new System.NotImplementedException();
        }

        public Note[] GetAllNote()
        {
            throw new System.NotImplementedException();
        }

        public int[] GetAllNoteIndex()
        {
            throw new System.NotImplementedException();
        }
    }
}