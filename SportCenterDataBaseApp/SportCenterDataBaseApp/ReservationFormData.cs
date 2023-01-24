using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportCenterDataBaseApp
{
    internal class ReservationFormData
    {
        readonly MainWindow mainWindow;
        public string customerId;
        public string reservationTime;
        public string startHour;
        public string endHour;
        public string sportFacilityId;

        public ReservationFormData(MainWindow mainWindow) 
        {
            this.mainWindow = mainWindow;
            CollectFormData();
        }

        private void CollectFormData()
        {
            customerId = FetchCustomerId();
            reservationTime = FetchReservationTime();
            startHour = FetchStartHour();
            endHour = FetchEndHour();
            sportFacilityId = FetchSportFacilityId();
        }

        private string FetchCustomerPhoneNumber()
        {
            return mainWindow.GetTextBoxReservationCustomerPhone().Text;
        }

        private string FetchCustomerId()
        {
            string cId = "";
            using (MySqlConnection connection = mainWindow.GetConnection())
            {
                connection.Open();
                var query = $"SELECT customer_id FROM customer WHERE customer_phone = '{FetchCustomerPhoneNumber()}';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Prepare();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    cId = dataReader.GetInt32(0).ToString();
                }
            }
            return cId;
        }

        private string FetchReservationTime()
        {
            return mainWindow.GetDateTimePickerReservation().Value.ToString("yyyy-MM-dd");
        }

        private string FetchStartHour()
        {
            return mainWindow.GetComboBoxReservationStart().SelectedItem.ToString();
        }

        private string FetchEndHour()
        {
            return mainWindow.GetComboBoxReservationEnd().SelectedItem.ToString();
        }

        private string FetchSportFacilityId()
        {
            ComboBox sportFacilityComboBox = mainWindow.GetComboBoxSportFacility();
            return ((KeyValuePair<int, string>)sportFacilityComboBox.SelectedItem).Key.ToString();
        }
    }
}
