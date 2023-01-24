using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public TextBox GetTextBoxReservationCustomerPhone()
        {
            return this.textBoxReservationCustomerPhone;
        }

        public DateTimePicker GetDateTimePickerReservation()
        {
            return this.dateTimePickerReservation;
        }

        public ComboBox GetComboBoxReservationStart()
        {
            return this.comboBoxReservationStart;
        }

        public ComboBox GetComboBoxReservationEnd()
        {
            return this.comboBoxReservationEnd;
        }

        public ComboBox GetComboBoxSportFacility()
        {
            return this.comboBoxSportFacility;
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

        private void showReservations()
        {
            int selectedComplex = ((KeyValuePair<int, string>)this.comboBoxSportComplex.SelectedItem).Key;
            int selectedFacility = ((KeyValuePair<int, string>)this.comboBoxSportFacility.SelectedItem).Key;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT reservation.reservation_id, customer.customer_phone, " +
                            "customer.customer_id, customer.customer_name, customer.customer_surname, " +
                            "customer.customer_email, reservation.reservation_time, reservation.start_hour, reservation.end_hour, sport_complex.sport_complex_name, " +
                            "sport_facility.sport_facility_name " +
                            "FROM reservation " +
                            "JOIN customer ON reservation.customer_id = customer.customer_id " +
                            "JOIN sport_facility ON reservation.reservation_facility_id = sport_facility.sport_facility_id " +
                            "JOIN sport_complex ON sport_facility.sport_complex_id = sport_facility.sport_complex_id ";
                String dateFilter = String.Format("reservation.reservation_time='{0}' ", this.dateTimePickerReservation.Value.ToString("yyyy-MM-dd"));
                var groupByClause = "GROUP BY reservation.reservation_id";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (selectedComplex == 0 && selectedFacility == 0)
                {
                    if (this.checkBoxFilterReservationByDate.Checked)
                    {
                        query += "WHERE " + dateFilter + groupByClause + ";";
                    }
                    else
                    {
                        query += groupByClause + ";";
                    }
                    cmd = new MySqlCommand(query, connection);
                }
                else if (selectedFacility != 0)
                {
                    var whereClause = "WHERE reservation_facility_id = @reservationFacilityId ";
                    if (this.checkBoxFilterReservationByDate.Checked)
                    {
                        query += whereClause + "AND " + dateFilter + groupByClause + ";";
                    }
                    else
                    { 
                        query += whereClause + groupByClause + ";";
                    }
                    cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@reservationFacilityId", selectedFacility);
                }
                else if (selectedComplex != 0)
                {
                    var whereClause = "WHERE sport_facility.sport_complex_id = @sportComplexId ";
                    if (this.checkBoxFilterReservationByDate.Checked)
                    {
                        query += whereClause + "AND " + dateFilter + groupByClause + ";";
                    }
                    else
                    {
                        query += whereClause + groupByClause + ";";
                    }
                    cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@sportComplexId", selectedComplex);
                }
                cmd.CommandType = CommandType.Text;
                cmd.Prepare();
                Console.WriteLine(cmd.CommandText);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewReservations.DataSource = dt;
            }
        }

        private void loadSportComplexOptions()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM sport_complex";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader dataReader =  cmd.ExecuteReader();

                Dictionary<int, string> itemsDictionary = new Dictionary<int, string>
                {
                    { 0, "Wybierz" }
                };

                while (dataReader.Read())
                {
                    itemsDictionary.Add(dataReader.GetInt32(0), dataReader.GetString(1));
                }

                this.comboBoxSportComplex.DataSource = new BindingSource(itemsDictionary, null);
                this.comboBoxSportComplex.DisplayMember = "Value";
                this.comboBoxSportComplex.ValueMember = "Key";
            }
        }

        private void loadFacilityOptions()
        {
            int selectedValue = ((KeyValuePair<int, string>)this.comboBoxSportComplex.SelectedItem).Key;

            if (this.comboBoxSportComplex.SelectedIndex != -1)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    MySqlCommand cmd;
                    connection.Open();
                    if (selectedValue == 0)
                    {
                        var query = "SELECT * FROM sport_facility";
                        cmd = new MySqlCommand(query, connection);
                    }
                    else
                    {
                        var query = "SELECT * FROM sport_facility WHERE sport_complex_id = @sportComplexId";
                        cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@sportComplexId", selectedValue);
                        cmd.Prepare();
                    }

                    cmd.CommandType = CommandType.Text;
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    Dictionary<int, string> itemsDictionary = new Dictionary<int, string>
                    {
                        { 0, "Wybierz" }
                    };
                    while (dataReader.Read())
                    {
                        itemsDictionary.Add(dataReader.GetInt32(0), dataReader.GetString(2));
                    }

                    this.comboBoxSportFacility.DataSource = new BindingSource(itemsDictionary, null);
                    this.comboBoxSportFacility.DisplayMember = "Value";
                    this.comboBoxSportFacility.ValueMember = "Key";
                }
            }
        }

        private void loadStartEndComboBoxes()
        {
            for (int i=6; i<=21; i++)
            {
                this.comboBoxReservationStart.Items.Add(i);
                this.comboBoxReservationEnd.Items.Add(i);
            }
            this.comboBoxReservationEnd.Items.Add(22);
        }

        private void Combobox1_onChange(object sender, EventArgs e)
        {
            loadFacilityOptions();
            showReservations();
        }

        private void Combobox2_onChange(object sender, EventArgs e)
        {
            showReservations();
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
            loadSportComplexOptions();
            loadFacilityOptions();
            loadStartEndComboBoxes();
            showReservations();
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxFilterReservationByDate_CheckedChanged(object sender, EventArgs e)
        {
            showReservations();
        }

        private void dateTimePicker1_TextChanged(object sender, EventArgs e)
        {
            showReservations();
        }

        private void comboBoxReservationStart_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedValue = (int)cmb.SelectedItem;
            // enable reservation end if this is valid
            if (selectedValue >= 6)
            {
                this.comboBoxReservationEnd.Enabled = true;
                // clear old and add valid hours (> start_hour)
                this.comboBoxReservationEnd.Items.Clear();
                for (int i = selectedValue + 1; i <= 22; i++)
                {
                    this.comboBoxReservationEnd.Items.Add(i);
                }
                // next hour by default
                this.comboBoxReservationEnd.SelectedIndex = 0;
            }
        }

        private bool ReservationFormValid()
        {
            // validate all fields
            // sport_facility
            // customer.customer_phone
            // date
            // start_hour
            // end_hour

            List<ComboBox> comboBoxes = new List<ComboBox>
            {
               this.comboBoxSportFacility,
               // TODO check if period from start to end is valid
               this.comboBoxReservationStart,
               this.comboBoxReservationEnd
            };
            foreach (var comboBox in comboBoxes)
            {
                if (comboBox.SelectedIndex == -1) return false;
            }
            // TODO validate customer.customer_phone if exists in DB
            if (this.textBoxReservationCustomerPhone.Text == "") return false;
            // TODO validate if date is valid
            if (this.dateTimePickerReservation.Value.ToString("yyyy-MM-dd") == "") return false;
            return true;
        }

        private void Button_SaveReservation_Click(object sender, EventArgs e)
        {
            if (this.ReservationFormValid())
            {
                // save record to DB
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    ReservationFormData formData = new ReservationFormData(this);
                    var query = "INSERT INTO reservation (reservation_id, customer_id, reservation_time, start_hour, end_hour, reservation_facility_id) " +
                            $"VALUES(NULL, '{formData.customerId}', '{formData.reservationTime}', '{formData.startHour}', '{formData.endHour}', '{formData.sportFacilityId}');";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pomyślnie zapisano rezerwację");
                    showReservations();
                }
            }
            else
            {
                MessageBox.Show("Formularz rezerwacji zawiera błędy!");
            }
        }

        private void dataGridViewReservations_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("DOUBLE CLICK!");
            int reservation_id;
            string customer_phone;
            int customer_id;
            string customer_name;
            string customer_surname;
            string customer_email;
            string reservation_time;
            int start_hour;
            int end_hour;
            string sport_complex_name;
            string sport_facility_name;

            if (dataGridViewReservations.CurrentRow.Index != -1)
            {
                reservation_id = int.Parse(dataGridViewReservations.CurrentRow.Cells[0].Value.ToString());
                Console.WriteLine(reservation_id);
                ReservationDetails reservationDetails= new ReservationDetails(this.GetConnection(), reservation_id);
                reservationDetails.Show();
                //textBoxPhoneNr.Text = dataGridViewCustomers.CurrentRow.Cells[1].Value.ToString();
                //textBoxName.Text = dataGridViewCustomers.CurrentRow.Cells[2].Value.ToString();
                //textBoxSurname.Text = dataGridViewCustomers.CurrentRow.Cells[3].Value.ToString();
                //textBoxEmail.Text = dataGridViewCustomers.CurrentRow.Cells[4].Value.ToString();
                //buttonAddCustomer.Text = "Zaktualizuj dane";
            }
        }
    }
}
