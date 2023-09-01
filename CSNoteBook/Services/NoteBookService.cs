using System;
using CSNoteBook.DAO;
using CSNoteBook.Models;
using CSNoteBook.Utils;

namespace CSNoteBook.Services
{
    public class NoteBookService : INoteBookService
    {
        //private static readonly INoteBookDao Dao = new NoteBookDao();
        private readonly INoteBookDao _dao = GetDaoFactory.GetDao();

        public int NewNote(string title = null, string content = null)
        {
            return _dao.NewNote(title, content);
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

        public void EditNote(int id, string title, string content)
        {
            if (_dao.IsNoteExist(id))
            {
                _dao.EditNote(id, title, content);
            }
            else
            {
                throw new ArgumentException($"Cannot find index: {id}.");
            }
        }
    }
}