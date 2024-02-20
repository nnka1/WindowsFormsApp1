using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void войти_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=5432;Database=bank;User ID=postgres;Password=123";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            string логин = логинBox.Text;
            string пароль = парольBox.Text;

            string query = "SELECT * FROM admin WHERE log = @логин AND pass = @пароль";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@логин", логин);
                cmd.Parameters.AddWithValue("@пароль", пароль);

                try
                {
                    connection.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        string fullname = reader["log"].ToString();  

                        this.Hide();
                        Form2 Form2 = new Form2();
                        Form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
