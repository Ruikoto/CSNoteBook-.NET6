using System;
using CSNoteBook.DAO;
using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public class NoteBookService : INoteBookService
    {
        private readonly INoteBookDao _dao = new NoteBookDao();

        public int NewNote(string title = null, string context = null)
        {
            return _dao.NewNote(title, context);
        }

        public void DeleteNote(int id)
        {
            if (_dao.IsNoteExist(id))
            {
                _dao.DeleteNote(id);
            }
            else
            {
                throw new ArgumentException($"Cannot find index: {id}.");
            }
        }

        public Note GetNote(int id)
        {
            if (_dao.IsNoteExist(id))
            {
                return _dao.GetNote(id);
            }
            else
            {
                throw new ArgumentException($"Cannot find index: {id}.");
            }
        }

        public Note[] GetAllNote()
        {
            return _dao.GetAllNote();
        }

        public int[] GetAllNoteIndex()
        {
            return _dao.GetAllNoteIndex();
        }

        public void EditNote(int id, string title, string context)
        {
            if (_dao.IsNoteExist(id))
            {
                _dao.EditNote(id, title, context);
            }
            else
            {
                throw new ArgumentException($"Cannot find index: {id}.");
            }
        }
    }
}