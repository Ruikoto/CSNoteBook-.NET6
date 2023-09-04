using System.Collections.Generic;
using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public interface INoteBookService
    {
        //添加笔记
        int AddNote(bool isChecked = false,string title = "",string content = "");
        //删除笔记
        void DeleteNote(int id);
        //获取笔记
        Note GetNote(int id);
        //获取所有笔记
        List<Note> GetAllNote();
        //获取所有笔记的索引
        List<int> GetAllNoteIndex();
        //编辑笔记
        void EditNote(int id,bool isChecked,string title, string content);
    }
}