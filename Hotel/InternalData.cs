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
        public static List<Room> Rooms = new List<Room>();
        public static List<RoomAllocation> RoomAllocations = new List<RoomAllocation>();

        public static void Initialization()
        {
            GetGuestsFromDB();
            GetRoomsFromDB();
            GetRoomAllocationFromDB();
        }

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

        public static int GetGuestID(Guest guest)
        {
            int guestID = -1;
            try
            {
                string sqlExpression = $"SELECT ID_Guest FROM Guests WHERE " +
                    $"Full_Name = '{guest.FullName}' AND Gender = '{guest.Gender}' AND Passport_ID = '{guest.PassportID}' " +
                    $"AND Arrival_Date = '{guest.ArrivalDate}' AND Length_Of_Stay = '{guest.LengthOfStay}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    
                    
                    while (reader.Read())
                    {
                        guestID = reader.GetInt32(0);
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

            return guestID;
        }

        public static void AddGuest(Guest guest)
        {
            Guests.Add(guest);
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

        public static void RemoveGuest(Guest guest)
        {
            Guests.Remove(guest);
            try
            {
                string sqlExpression = $"DELETE FROM Guests WHERE " +
                    $"Full_Name = '{guest.FullName}' AND Gender = '{guest.Gender}' AND Passport_ID = '{guest.PassportID}' " +
                    $"AND Arrival_Date = '{guest.ArrivalDate}' AND Length_Of_Stay = '{guest.LengthOfStay}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Removed objects: {number}");
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

        public static void EditGuest(Guest oldGuest, Guest newGuest)
        {
            Guests[Guests.IndexOf(oldGuest)] = newGuest;
            try
            {
                string sqlExpression = $"UPDATE Guests SET " +
                    $"Full_Name = '{newGuest.FullName}', Gender = '{newGuest.Gender}', Passport_ID = '{newGuest.PassportID}'" +
                    $", Arrival_Date = '{newGuest.ArrivalDate}', Length_Of_Stay = '{newGuest.LengthOfStay}' WHERE " +
                    $"Full_Name = '{oldGuest.FullName}' AND Gender = '{oldGuest.Gender}' AND Passport_ID = '{oldGuest.PassportID}' " +
                    $"AND Arrival_Date = '{oldGuest.ArrivalDate}' AND Length_Of_Stay = '{oldGuest.LengthOfStay}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Updated {number} objects");
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

        public static void GetRoomsFromDB()
        {
            try
            {
                string sqlExpression = "SELECT * FROM Rooms";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    Rooms.Clear();
                    while (reader.Read())
                    {
                        Rooms.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
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

        public static void GetRoomAllocationFromDB()
        {
            try
            {
                string sqlExpression = "SELECT * FROM RoomAllocation";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    RoomAllocations.Clear();
                    while (reader.Read())
                    {
                        RoomAllocations.Add(new RoomAllocation(reader.GetInt32(0), reader.GetInt32(1)));
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

        public static void AddRoomAllocation(RoomAllocation roomAllocation)
        {
            RoomAllocations.Add(roomAllocation);
            try
            {
                string sqlExpression = $"INSERT INTO RoomAllocation (ID_Guest, Number_Of_Room) VALUES " +
                    $"({roomAllocation.IDGuest}, {roomAllocation.NumberOfRoom})";

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

        public static void RemoveRoomAllocation(RoomAllocation roomAllocation)
        {
            RoomAllocations.Remove(roomAllocation);
            try
            {
                string sqlExpression = $"DELETE FROM RoomAllocation WHERE " +
                    $"ID_Guest = {roomAllocation.IDGuest} AND Number_Of_Room = {roomAllocation.NumberOfRoom}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Removed objects: {number}");
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

        public static void EditRoomAllocation(RoomAllocation oldRoomAllocation, RoomAllocation newRoomAllocation)
        {
            RoomAllocations[RoomAllocations.IndexOf(oldRoomAllocation)] = newRoomAllocation;
            try
            {
                string sqlExpression = $"UPDATE RoomAllocation SET " +
                    $"ID_Guest = {newRoomAllocation.IDGuest}, Number_Of_Room = {newRoomAllocation.NumberOfRoom} WHERE " +
                    $"ID_Guest = {oldRoomAllocation.IDGuest} AND Number_Of_Room = {oldRoomAllocation.NumberOfRoom}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Updated {number} objects");
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
