using Npgsql;
using System;
using System.Windows.Forms;

namespace Admin_Panel
{
    internal class DB_Table
    {
        public static void DB_TableInitialize(ListView listView1)
        {
            listView1.GridLines = true;
            listView1.View = View.Details;

            // названия столбцов
            listView1.Columns.Add("Номер", 50);
            listView1.Columns.Add("Название", 200);
            listView1.Columns.Add("Картинка", 50);
            listView1.Columns.Add("Кинопоиск", 220);
            listView1.Columns.Add("Ссылка", 100);
            listView1.Columns.Add("Ссылка", 100);
            listView1.Columns.Add("Ссылка", 100);
            listView1.Columns.Add("Ссылка", 100);
            listView1.Columns.Add("Редактировать", 100);
            listView1.Columns.Add("Удалить", 74);

            DB_TableShow(listView1);

        }

        public static void DB_TableShow(ListView listView1)//отображение списка на главной форме
        {
            string sql = "Select id, name, image, link, link2, link3, link4, link5 from kino.kino";//запрос на вывод данных
            NpgsqlConnection connection = FormMain.CONNECTION_STRING();
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            var Reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (Reader.Read())//вывод данных БД в таблицу
            {
                ListViewItem lv = new ListViewItem(Reader["id"].ToString());
                lv.SubItems.Add((string)Reader["name"]);
                lv.SubItems.Add((string)Reader["image"]);
                lv.SubItems.Add((string)Reader["link"]);
                lv.SubItems.Add((Reader["link2"] == DBNull.Value ? "" : (string)Reader["link2"]));
                lv.SubItems.Add((Reader["link3"] == DBNull.Value ? "" : (string)Reader["link3"]));
                lv.SubItems.Add((Reader["link4"] == DBNull.Value ? "" : (string)Reader["link4"]));
                lv.SubItems.Add((Reader["link5"] == DBNull.Value ? "" : (string)Reader["link5"]));
                listView1.Items.Add(lv);
            }
            Reader.Close();
            connection.Close();
        }
    }
}
