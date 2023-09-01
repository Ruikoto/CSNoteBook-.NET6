using CSNoteBook.DAO;

namespace CSNoteBook.Utils
{
    public static class GetDaoFactory
    {
        private static readonly INoteBookDao Dao = new NoteBookDao();

        public static INoteBookDao GetDao()
        {
            return Dao;
        }
    }
}