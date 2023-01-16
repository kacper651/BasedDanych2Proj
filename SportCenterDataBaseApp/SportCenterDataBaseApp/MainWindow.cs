using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SportCenterDataBaseApp
{
    public partial class MainWindow : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=sport_center";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addSportComplex()
        {

        }

        private void editSportComplex()
        {

        }

        private void deleteSportComplex()
        {

        }

        private void addSportFacility()
        {

        }

        private void editSportFacilityx()
        {

        }

        private void deleteSportFacility()
        {

        }

        private void makeReservation()
        {

        }

        private void editReservation()
        {

        }

        private void deleteReservation()
        {

        }

        private void showCustomers()
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Query Successful");
                GridFill();
            }
        }

        void GridFill()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM customer;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewCustomers.DataSource = dt;
                dataGridViewCustomers.Columns[0].Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GridFill();
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "";
                if(buttonAddCustomer.Text == "Dodaj klienta")
                {
                    query = "INSERT INTO customer (customer_phone, customer_name, customer_surname, customer_email) " +
                               $"VALUES('{textBoxPhoneNr.Text}', '{textBoxName.Text}', '{textBoxSurname.Text}', '{textBoxEmail.Text}');";
                }
                else
                {
                    query = "UPDATE customer " +
                           $"SET customer_phone = '{textBoxPhoneNr.Text}', customer_name = '{textBoxName.Text}', customer_surname = '{textBoxSurname.Text}', customer_email = '{textBoxEmail.Text}' " +
                           $"WHERE customer_id = {dataGridViewCustomers.CurrentRow.Cells[0].Value}";
                }
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                if (textBoxPhoneNr.Text != "" || textBoxName.Text != "" || textBoxSurname.Text != "" || textBoxEmail.Text != "")
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Query Successful");
                    GridFill();
                    ClearCustomerTextBoxes();
                    buttonAddCustomer.Text = "Dodaj klienta";
                }
                else
                {
                    MessageBox.Show("Uzupełnij dane");
                }
            }
        }


        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM customer " +
                               $"WHERE customer_id = {dataGridViewCustomers.CurrentRow.Cells[0].Value}";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                var confirmResult = MessageBox.Show("Na pewno chcesz usunąć tego klienta?", "Potwierdź usuwanie",MessageBoxButtons.YesNo);
                if(confirmResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Query Successful");
                }
                else
                {
                    MessageBox.Show("Query dropped");
                    return;
                }
                GridFill();
            }
        }

        void ClearCustomerTextBoxes()
        {
            textBoxPhoneNr.Clear();
            textBoxName.Clear();
            textBoxSurname.Clear();
            textBoxEmail.Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridViewCustomers_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridViewCustomers.CurrentRow.Index != -1)
            {
                textBoxPhoneNr.Text = dataGridViewCustomers.CurrentRow.Cells[1].Value.ToString();
                textBoxName.Text = dataGridViewCustomers.CurrentRow.Cells[2].Value.ToString();
                textBoxSurname.Text = dataGridViewCustomers.CurrentRow.Cells[3].Value.ToString();
                textBoxEmail.Text = dataGridViewCustomers.CurrentRow.Cells[4].Value.ToString();
                buttonAddCustomer.Text = "Zaktualizuj dane";
            }
        }
    }
}
