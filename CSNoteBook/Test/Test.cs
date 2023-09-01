using System;
using CSNoteBook.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSNoteBook.Test
{
    //[TestClass]
    public static class Test
    {
        //[TestMethod]
        public static void TestMethod(string[] args)
        {
            INoteBookDao dao = new NoteBookDao();
            dao.NewNote("123", "456");
        }
    }
}