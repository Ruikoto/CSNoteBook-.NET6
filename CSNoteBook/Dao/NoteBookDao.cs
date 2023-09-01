using System;
using CSNoteBook.Models;
using CSNoteBook.Services;
using System.Data.SQLite;
using System.IO;
using System.Windows;


namespace CSNoteBook.DAO
{
    public class NoteBookDao : INoteBookDao
    {
        private readonly SQLiteConnection _connection;
        private const string ConnInfo = "Data Source=notebook.sqlite;Version=3;";

        public NoteBookDao()
        {
            using (_connection = new SQLiteConnection(ConnInfo))
            {
                _connection.Open();
                using (var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS notebooks (id INTEGER PRIMARY KEY, title TEXT, content TEXT)", _connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int NewNote(string title, string content)
        {
            throw new System.NotImplementedException();
        }

        public int EditNote(int id, string title, string content)
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