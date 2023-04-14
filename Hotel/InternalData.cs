using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal static class InternalData
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=HotelDB;Integrated Security=true";

        public static List<Guest> Guests = new List<Guest>();

        public static void GetGuestsFromDB()
        {
            try
            {
                string sqlExpression = "SELECT * FROM Guests";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    Guests.Clear();
                    while (reader.Read())
                    {
                        Guests.Add(new Guest(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }

        public static void AddGuestToDB(Guest guest)
        {
            try
            {
                string sqlExpression = $"INSERT INTO Guests (Full_Name, Gender, Passport_ID, Arrival_Date, Length_Of_Stay) VALUES " +
                    $"('{guest.FullName}', '{guest.Gender}', '{guest.PassportID}', '{guest.ArrivalDate}', '{guest.LengthOfStay}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Added {number} objects");
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string error = string.Empty;

                foreach (SqlError err in ex.Errors)
                {
                    error += "Message: "
                    + err.Message
                    + "\n"
                    + "Level: "
                    + err.Class
                    + "\n"
                    + "Procedure: "
                    + err.Procedure
                    + "\n"
                    + "Line Number: "
                    + err.LineNumber
                    + "\n";
                    MessageBox.Show(error);
                }
            }
        }
    }
}
