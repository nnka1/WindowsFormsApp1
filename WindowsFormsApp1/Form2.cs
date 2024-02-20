using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Port=5432;Database=bank;User ID=postgres;Password=123";

            DataTable table = new DataTable();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM \"Договор\""; 

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlQuery, connection))
                {
                    adapter.Fill(table);
                }
            }

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=5432;Database=bank;User ID=postgres;Password=123";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO \"Договор\" (\"ID Договора\", \"ID Клиента\", \"Номер счёта\", \"Процент первоначального взноса\", \"Стоимость товара\", \"Дата договора\") " +
                                    "VALUES (@idДоговора, @idКлиента, @номерСчета, @процентВзноса, @стоимостьТовара, @датаДоговора)";

                using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idДоговора", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@idКлиента", int.Parse(textBox2.Text));
                    command.Parameters.AddWithValue("@номерСчета", int.Parse(textBox3.Text));
                    command.Parameters.AddWithValue("@процентВзноса", int.Parse(textBox4.Text));
                    command.Parameters.AddWithValue("@стоимостьТовара", int.Parse(textBox5.Text));

                    DateTime dateValue;
                    if (DateTime.TryParse(textBox6.Text, out dateValue))
                    {
                        command.Parameters.AddWithValue("@датаДоговора", dateValue);
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат даты!");
                        return;
                    }

                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись добавлена в таблицу 'Договор'.");

                    DataTable updatedTable = new DataTable();
                    string selectQuery = "SELECT * FROM \"Договор\"";
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(selectQuery, connection))
                    {
                        adapter.Fill(updatedTable);
                    }

                    dataGridView1.DataSource = updatedTable;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int idToDelete = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID Договора"].Value);

                string connectionString = "Server=localhost;Port=5432;Database=bank;User ID=postgres;Password=123";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM \"Договор\" WHERE \"ID Договора\" = @idToDelete";
                    using (NpgsqlCommand command = new NpgsqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idToDelete", idToDelete);
                        command.ExecuteNonQuery(); // Удаление записи

                        MessageBox.Show("Запись удалена из таблицы 'Договор'.");

                        // Повторное выполнение запроса SELECT
                        DataTable updatedTable = new DataTable();
                        string selectQuery = "SELECT * FROM \"Договор\"";
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(selectQuery, connection))
                        {
                            adapter.Fill(updatedTable);
                        }

                        // Обновление источника данных DataGridView
                        dataGridView1.DataSource = updatedTable;
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int idToUpdate = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID Договора"].Value);

                string connectionString = "Server=localhost;Port=5432;Database=bank;User ID=postgres;Password=123";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE \"Договор\" SET \"Номер счёта\" = @номерСчета, \"Дата договора\" = @датаДоговора, \"Процент первоначального взноса\" = @процентВзноса, \"Стоимость товара\" = @стоимостьТовара, \"ID Договора\" = @idДоговора, \"ID Клиента\" = @idКлиента WHERE \"ID Договора\" = @idToUpdate";

                    using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idДоговора", int.Parse(textBox1.Text));
                        command.Parameters.AddWithValue("@idКлиента", int.Parse(textBox2.Text));
                        command.Parameters.AddWithValue("@номерСчета", int.Parse(textBox3.Text));
                        command.Parameters.AddWithValue("@процентВзноса", int.Parse(textBox4.Text));
                        command.Parameters.AddWithValue("@стоимостьТовара", int.Parse(textBox5.Text));
                        DateTime dateValue;
                        if (DateTime.TryParse(textBox6.Text, out dateValue))
                        {
                            command.Parameters.AddWithValue("@датаДоговора", dateValue);
                        }
                        else
                        {
                            MessageBox.Show("Неверный формат даты!");
                            return;
                        }
                        command.Parameters.AddWithValue("@idToUpdate", idToUpdate);

                        command.ExecuteNonQuery(); 

                        MessageBox.Show("Запись обновлена в таблице 'Договор'.");

                        DataTable updatedTable = new DataTable();
                        string selectQuery = "SELECT * FROM \"Договор\"";
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(selectQuery, connection))
                        {
                            adapter.Fill(updatedTable);
                        }

                        dataGridView1.DataSource = updatedTable;
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string searchText = textBox7.Text;

            string connectionString = "Server=localhost;Port=5432;Database=bank;User ID=postgres;Password=123";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string searchQuery = "SELECT * FROM \"Договор\" WHERE CAST(\"ID Договора\" AS TEXT) LIKE @searchText OR CAST(\"ID Клиента\" AS TEXT) LIKE @searchText OR CAST(\"Номер счёта\" AS TEXT) LIKE @searchText OR CAST(\"Процент первоначального взноса\" AS TEXT) LIKE @searchText OR CAST(\"Стоимость товара\" AS TEXT) LIKE @searchText OR CAST(\"Дата договора\" AS TEXT) LIKE @searchText";

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(searchQuery, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    DataTable searchResult = new DataTable();
                    adapter.Fill(searchResult);

                    dataGridView1.DataSource = searchResult;
                }
            }
        }
    }
}
