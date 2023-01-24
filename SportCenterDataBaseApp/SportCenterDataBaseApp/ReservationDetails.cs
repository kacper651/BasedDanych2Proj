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
    public partial class ReservationDetails : Form
    {
        MySqlConnection connection;
        int reservation_id;
        int sport_complex_id;
        List<int> invalidComboboxValues = new List<int> { 0, -1 };
        //List<int> rental_facility_ids = new List<int>();
        public ReservationDetails()
        {
            InitializeComponent();
        }

        public ReservationDetails(MySqlConnection conn, int reservation_id)
        {
            InitializeComponent();
            this.connection = conn;
            this.reservation_id = reservation_id;
            GetReservationData();
            LoadRentalFacilities();
        }

        private void GetReservationData()
        {
            using (this.connection)
            {
                MySqlCommand cmd;
                connection.Open();

                var query = "SELECT reservation.reservation_id, customer.customer_phone, " +
                            "customer.customer_id, customer.customer_name, customer.customer_surname, " +
                            "customer.customer_email, reservation.reservation_time, reservation.start_hour, reservation.end_hour, sport_complex.sport_complex_name, " +
                            "sport_facility.sport_facility_name, sport_complex.sport_complex_id " +
                            "FROM reservation " +
                            "JOIN customer ON reservation.customer_id = customer.customer_id " +
                            "JOIN sport_facility ON reservation.reservation_facility_id = sport_facility.sport_facility_id " +
                            "JOIN sport_complex ON sport_facility.sport_complex_id = sport_facility.sport_complex_id ";
                query += "WHERE reservation.reservation_id = " + this.reservation_id.ToString() + " ";
                query += "GROUP BY reservation.reservation_id;";
                cmd = new MySqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string customer_phoneNumber = dataReader.GetString(1);
                    int customer_id = dataReader.GetInt32(2);
                    string customer_name = dataReader.GetString(3);
                    string customer_lastName = dataReader.GetString(4);
                    string customer_email = dataReader.GetString(5);
                    string reservation_time = dataReader.GetString(6).Split(' ')[0];
                    int start_hour = dataReader.GetInt32(7);
                    int end_hour = dataReader.GetInt32(8);

                    string complex_name = dataReader.GetString(9);
                    string facility_name = dataReader.GetString(10);
                    this.sport_complex_id = dataReader.GetInt32(11);

                    this.label_CustomerId.Text += customer_id.ToString();
                    this.label_CustomerName.Text = customer_name + " " + customer_lastName;
                    this.label_ComplexName.Text += complex_name;
                    this.label_FacilityName.Text += facility_name;
                    this.label_ReservationId.Text += reservation_id.ToString();
                    this.label_CustomerEmail.Text += customer_email;
                    this.label_CustomerPhone.Text += customer_phoneNumber;
                    this.label_ReservationDate.Text += reservation_time;
                    this.label_StartHour.Text += start_hour.ToString();
                    this.label_EndHour.Text += end_hour.ToString();

                }
            }
        }

        private void LoadRentalFacilities()
        {
            using (this.connection)
            {
                connection.Open();
                string query = "SELECT * FROM rental_facility WHERE sport_complex_id = " + this.sport_complex_id.ToString() + ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                Dictionary<int, string> itemsDictionary = new Dictionary<int, string>
                {
                    { 0, "Wybierz" }
                };

                while (dataReader.Read())
                {
                    int rental_facility_id = dataReader.GetInt32(0);
                    itemsDictionary.Add(rental_facility_id, dataReader.GetString(2));
                    Console.WriteLine(rental_facility_id);
                    //this.rental_facility_ids.Append(rental_facility_id);
                }

                this.comboBox_RentalFacilities.DataSource = new BindingSource(itemsDictionary, null);
                this.comboBox_RentalFacilities.DisplayMember = "Value";
                this.comboBox_RentalFacilities.ValueMember = "Key";
            }
        }

        private void ComboBox_RentalFacilities_onChange(object sender, System.EventArgs e)
        {
            if (!invalidComboboxValues.Contains(this.comboBox_RentalFacilities.SelectedIndex))
            {
                using (connection)
                {
                    MySqlCommand cmd;
                    connection.Open();

                    var query = "SELECT * FROM accessory ";
                    query += "WHERE rental_facility_id = " + this.comboBox_RentalFacilities.SelectedIndex.ToString() + ";";

                    cmd = new MySqlCommand(query, connection);
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

                    this.comboBox_Accessories.DataSource = new BindingSource(itemsDictionary, null);
                    this.comboBox_Accessories.DisplayMember = "Value";
                    this.comboBox_Accessories.ValueMember = "Key";
                }
            }
        }
    }
}
