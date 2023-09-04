using System;
using System.Collections.Generic;
using CSNoteBook.DAO;
using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public class NoteBookService : INoteBookService
    {
        //private static readonly INoteBookDao Dao = new NoteBookDao();
        private readonly INoteBookDao _dao = NoteBookDao.Instance;

        public int NewNote(bool isChecked = false,string title = "",string content = "")
        {
            var vChecked = isChecked ? 1 : 0;
            return _dao.NewNote(vChecked,title, content);
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
            throw new ArgumentException($"Cannot find index: {id}.");
        }

        public List<Note> GetAllNote()
        {
            return _dao.GetAllNote();
        }

        public List<int> GetAllNoteIndex()
        {
            return _dao.GetAllNoteIndex();
        }

        public void EditNote(int id, bool isChecked, string title, string content)
        {
            if (_dao.IsNoteExist(id))
            {
                var vChecked = isChecked ? 1 : 0;
                _dao.EditNote(id, vChecked,title, content);
            }
            else
            {
                throw new ArgumentException($"Cannot find index: {id}.");
            }
        }
    }
}