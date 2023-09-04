using System.Collections;
using System.Collections.Generic;
using CSNoteBook.Models;
using System.Data.SQLite;


namespace CSNoteBook.DAO
{
    public class NoteBookDao : INoteBookDao
    {
        //单例模式
        private static NoteBookDao _instance;
        public static NoteBookDao Instance => _instance ?? (_instance = new NoteBookDao());

        //数据库连接信息
        private const string ConnInfo = "Data Source=notebook.sqlite;Version=3;Pooling=True;";
        private static readonly SQLiteConnection Conn = new SQLiteConnection(ConnInfo);

        //初始化数据库
        public void Init()
        {
            Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "CREATE TABLE IF NOT EXISTS noteData (" +
                       "id INTEGER PRIMARY KEY, " +
                       "is_checked INTEGER, " +
                       "content TEXT," +
                       "title TEXT)",
                       Conn))
            {
                cmd.ExecuteNonQuery();
                //Conn.Close();
            }
        }

        //关闭数据库
        public void Close()
        {
            Conn.Close();
        }

        //添加笔记
        public int AddNote(int isChecked, string title, string content)
        {
            //Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "INSERT INTO noteData(is_checked,title,content)VALUES (@isChecked,@title,@content);" +
                       "SELECT last_insert_rowId();",
                       Conn))
            {
                cmd.Parameters.AddWithValue("@isChecked", isChecked);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@content", content);

                var index = (long)cmd.ExecuteScalar();
                //Conn.Close();
                return (int)index;
            }
        }

        //编辑笔记
        public void EditNote(int id, int isChecked, string title, string content)
        {
            //Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "UPDATE noteData SET is_checked = @isChecked,title = @title, content = @content WHERE id = @id"
                       , Conn))
            {
                cmd.Parameters.AddWithValue("@isChecked", isChecked);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.ExecuteNonQuery();
                //Conn.Close();
            }
        }

        //删除笔记
        public void DeleteNote(int id)
        {
            //Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "DELETE FROM noteData WHERE id = @id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                //Conn.Close();
            }
        }

        //判断笔记是否存在
        public bool IsNoteExist(int id)
        {
            //Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "SELECT id FROM noteData WHERE id = @id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                var sqLiteDataReader = cmd.ExecuteReader();
                return sqLiteDataReader.HasRows;
                //Conn.Close();
            }
        }

        //获取笔记
        public Note GetNote(int id)
        {
            var note = new Note();
            //Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "SELECT id, is_checked, title, content FROM noteData WHERE id = @id", Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var sqLiteDataReader = cmd.ExecuteReader())
                {
                    sqLiteDataReader.Read();
                    note.Id = sqLiteDataReader.GetInt32(0);
                    note.IsChecked = sqLiteDataReader.GetInt32(1) != 0;
                    note.Title = sqLiteDataReader.IsDBNull(2) ? null : sqLiteDataReader.GetString(2);
                    note.Content = sqLiteDataReader.IsDBNull(3) ? null : sqLiteDataReader.GetString(3);
                }
            }
            //Conn.Close();
            return note;
        }

        //获取所有笔记
        public List<Note> GetAllNote()
        {
            var notes = new List<Note>();
            //Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "SELECT id, is_checked, title, content FROM noteData", Conn))
            {
                using (var sqLiteDataReader = cmd.ExecuteReader())
                {
                    while (sqLiteDataReader.Read())
                    {
                        var note = new Note
                        {
                            Id = sqLiteDataReader.GetInt32(0),
                            IsChecked = sqLiteDataReader.GetInt32(1) != 0,
                            Title = sqLiteDataReader.IsDBNull(2) ? null : sqLiteDataReader.GetString(2),
                            Content = sqLiteDataReader.IsDBNull(3) ? null : sqLiteDataReader.GetString(3)
                        };
                        notes.Add(note);
                    }
                }
            }
            //Conn.Close();
            return notes;
        }

        //获取所有笔记的索引
        public List<int> GetAllNoteIndex()
        {
            var list = new List<int>();
            //Conn.Open();
            using (var cmd = new SQLiteCommand(
                       "SELECT id FROM noteData", Conn))
            {
                using (var sqLiteDataReader = cmd.ExecuteReader())
                {
                    while (sqLiteDataReader.Read())
                    {
                        list.Add(sqLiteDataReader.GetInt32(0));
                    }
                }
            }

            //Conn.Close();
            return list;
        }
    }
}