using System;
using CSNoteBook.DAO;
using CSNoteBook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSNoteBook.Test
{
    //[TestClass]
    public static class Test
    {
        //[TestMethod]
        public static void TestMethod(string[] args)
        {
            INoteBookService service = new NoteBookService();
            service.NewNote(false,"first", "per");
            service.NewNote(true,"2", "4680");
            service.NewNote(true,"三");
            service.NewNote();
            var allNote = service.GetAllNote();
            foreach (var note in allNote)
            {
                Console.WriteLine(note);
            }

            Console.WriteLine(@"==========");
            var allIndex = service.GetAllNoteIndex();
            foreach (var index in allIndex)
            {
                Console.WriteLine(index);
            }
        }
    }
}