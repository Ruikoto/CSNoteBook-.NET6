using System;
using CSNoteBook.Models;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CSNoteBook.DAO
{
    public class NoteBookDao : INoteBookDao
    {
        private SQLiteConnection _conn;
        private const string ConnInfo = "Data Source=notebook.sqlite;Version=3;";

        public NoteBookDao()
        {
            Init();
        }

        private void Init()
        {
            _conn = new SQLiteConnection(ConnInfo);
            _conn.Open();
            using (var cmd = new SQLiteCommand(
                       "CREATE TABLE IF NOT EXISTS notebooks (id INTEGER PRIMARY KEY, title TEXT, content TEXT)",
                       _conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public int NewNote(string title, string content)
        {
            using (var cmd = new SQLiteCommand(
                       "INSERT INTO notebooks(title,content)VALUES (@title,@content);" +
                       "SELECT last_insert_rowId();", _conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@content", content);

                var index = (long)cmd.ExecuteScalar();
                return (int)index;
            }
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