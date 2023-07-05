using Npgsql;
using System;
using System.Windows.Forms;

namespace Admin_Panel
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            DB_Table.DB_TableInitialize(listView1);
        }

        public static NpgsqlConnection CONNECTION_STRING()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=devUser;Password=1234;Database=Kino;");
            // в БД создан пользователь для удалённого подключения и администрирования
        }
     
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var AddForm = new FormAdd();
            AddForm.ShowDialog();
            DB_Table.DB_TableShow(listView1);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DB_Table.DB_TableShow(listView1);
        }

        private void buttonUserChange_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
             "В разработке",
             "Сообщение",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information,
             MessageBoxDefaultButton.Button1);
        }
    }
}
