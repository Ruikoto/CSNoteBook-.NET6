using System;
using System.Collections.Generic;
using CSNoteBook.DAO;
using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public class NoteBookService : INoteBookService
    {
        //获取单例
        private readonly INoteBookDao _dao = NoteBookDao.Instance;

        //添加笔记
        public int AddNote(bool isChecked = false,string title = "",string content = "")
        {
            var vChecked = isChecked ? 1 : 0;
            return _dao.AddNote(vChecked,title, content);
        }

        //删除笔记
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

        //获取笔记
        public Note GetNote(int id)
        {
            if (_dao.IsNoteExist(id))
            {
                return _dao.GetNote(id);
            }
            throw new ArgumentException($"Cannot find index: {id}.");
        }

        //获取所有笔记
        public List<Note> GetAllNote()
        {
            return _dao.GetAllNote();
        }

        //获取所有笔记的索引
        public List<int> GetAllNoteIndex()
        {
            return _dao.GetAllNoteIndex();
        }

        //编辑笔记
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