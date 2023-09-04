using System;
using System.Collections.Generic;
using CSNoteBook.Models;

namespace CSNoteBook.DAO
{
    public interface INoteBookDao
    {
        //初始化数据库
        void Init();
        //新建笔记
        int AddNote(int isChecked, string title, string content);
        //编辑笔记
        void EditNote(int id, int isChecked, string title, string content);
        //删除笔记
        void DeleteNote(int id);
        //判断笔记是否存在
        bool IsNoteExist(int id);
        //获取笔记
        Note GetNote(int id);
        //获取所有笔记
        List<Note> GetAllNote();
        //获取所有笔记的索引
        List<int> GetAllNoteIndex();
    }
}