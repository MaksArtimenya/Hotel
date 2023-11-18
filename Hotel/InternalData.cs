using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal static class InternalData
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=HotelDB;Integrated Security=true";

        public static TcpClient? Client { get; private set; }
        public static NetworkStream? NetworkStream { get; private set; }
        public static User User { get; private set; } = new User(string.Empty, -1);

        public static List<Guest> Guests { get; set; } = new List<Guest>();
        public static List<Room> Rooms { get; set; } = new List<Room>();
        public static List<RoomAllocation> RoomAllocations { get; set; } = new List<RoomAllocation>();

        public static void Initialization()
        {
            GetGuestsFromServer();
            GetRoomsFromServer();
            GetRoomAllocationFromServer();
        }

        public static void GetUserFromServer(string login, string password, string ipAddress, string port)
        {
            User = new User(string.Empty, -1);
            try
            {
                Client = new TcpClient(ipAddress, int.Parse(port));
                NetworkStream = Client.GetStream();

                string message = $"Connect\nSELECT Name, Type_Of_User FROM Users WHERE Login = '{login}' AND Password = '{password}'";

                byte[] data = Encoding.Unicode.GetBytes(message);
                NetworkStream.Write(data, 0, data.Length);
                data = new byte[256];
                StringBuilder response = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = NetworkStream.Read(data, 0, data.Length);
                    response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (NetworkStream.DataAvailable);

                message = response.ToString();

                User = User.GetUser(message);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Пользователь не найден");
                if (Client is not null && NetworkStream is not null)
                {
                    Client.Close();
                    NetworkStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetGuestsFromServer()
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = "GetGuests";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    Guests.Clear();
                    string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;
                    while (i < strings.Length)
                    {
                        string guestString = string.Empty;
                        for (int j = 0; j < 5; j++)
                        {
                            guestString += strings[i + j] + "\n";
                        }

                        Guests.Add(Guest.GetGuest(guestString));
                        i += 5;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetGuestID(Guest guest)
        {
            int guestID = -1;
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"GetGuestID\nSELECT ID_Guest FROM Guests WHERE " +
                        $"Full_Name = '{guest.FullName}' AND Gender = '{guest.Gender}' AND Passport_ID = '{guest.PassportID}' " +
                        $"AND Arrival_Date = '{guest.ArrivalDate}' AND Length_Of_Stay = '{guest.LengthOfStay}'";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    guestID = int.Parse(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return guestID;
        }

        public static List<Guest> GetGuestsByRoom(Room room)
        {
            List<Guest> guests = new List<Guest>();
            try
            {
                if (NetworkStream is not null)
                {
                    string message = "GuestsByRoom\nSELECT ID_Guest FROM RoomAllocation WHERE " +
                        $"Number_Of_Room = {room.Number}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;
                    while (i < strings.Length)
                    {
                        string guestString = string.Empty;
                        for (int j = 0; j < 5; j++)
                        {
                            guestString += strings[i + j] + "\n";
                        }

                        guests.Add(Guest.GetGuest(guestString));
                        i += 5;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return guests;
        }

        public static void AddGuest(Guest guest)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nINSERT INTO Guests (Full_Name, Gender, Passport_ID, Arrival_Date, Length_Of_Stay) VALUES " +
                        $"('{guest.FullName}', '{guest.Gender}', '{guest.PassportID}', '{guest.ArrivalDate}', '{guest.LengthOfStay}')";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetGuestsFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add guest: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveGuest(Guest guest)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nDELETE FROM Guests WHERE " +
                        $"Full_Name = '{guest.FullName}' AND Gender = '{guest.Gender}' AND Passport_ID = '{guest.PassportID}' " +
                        $"AND Arrival_Date = '{guest.ArrivalDate}' AND Length_Of_Stay = '{guest.LengthOfStay}'";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetGuestsFromServer();
                        GetRoomAllocationFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to remove guest: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void EditGuest(Guest oldGuest, Guest newGuest)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nUPDATE Guests SET " +
                        $"Full_Name = '{newGuest.FullName}', Gender = '{newGuest.Gender}', Passport_ID = '{newGuest.PassportID}'" +
                        $", Arrival_Date = '{newGuest.ArrivalDate}', Length_Of_Stay = '{newGuest.LengthOfStay}' WHERE " +
                        $"Full_Name = '{oldGuest.FullName}' AND Gender = '{oldGuest.Gender}' AND Passport_ID = '{oldGuest.PassportID}' " +
                        $"AND Arrival_Date = '{oldGuest.ArrivalDate}' AND Length_Of_Stay = '{oldGuest.LengthOfStay}'";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetGuestsFromServer();
                        GetRoomAllocationFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to edit guest: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetRoomsFromServer()
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = "GetRooms";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    Rooms.Clear();
                    string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;
                    while (i < strings.Length)
                    {
                        string roomString = string.Empty;
                        for (int j = 0; j < 4; j++)
                        {
                            roomString += strings[i + j] + "\n";
                        }

                        Rooms.Add(Room.GetRoom(roomString));
                        i += 4;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddRoom(Room room)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nINSERT INTO Rooms (Number, Number_Of_Places, Occupied_Places, Price) VALUES " +
                        $"({room.Number}, {room.NumberOfPlaces}, {room.OccupiedPlaces}, {room.Price})";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetRoomsFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add room: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveRoom(Room room)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nDELETE FROM Rooms WHERE " +
                        $"Number = {room.Number} AND Number_Of_Places = {room.NumberOfPlaces} " +
                        $"AND Occupied_Places = {room.OccupiedPlaces} AND Price = {room.Price}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetRoomsFromServer();
                        GetRoomAllocationFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to remove room: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void EditRoom(Room oldRoom, Room newRoom)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nUPDATE Rooms SET " +
                        $"Number = {newRoom.Number}, Number_Of_Places = {newRoom.NumberOfPlaces}," +
                        $" Occupied_Places = {newRoom.OccupiedPlaces}, Price = {newRoom.Price} WHERE " +
                        $"Number = {oldRoom.Number} AND Number_Of_Places = {oldRoom.NumberOfPlaces} AND" +
                        $" Occupied_Places = {oldRoom.OccupiedPlaces} AND Price = {oldRoom.Price}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetRoomsFromServer();
                        GetRoomAllocationFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to edit room: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetRoomAllocationFromServer()
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = "GetRoomAllocation";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();
                    RoomAllocations.Clear();
                    string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;
                    while (i < strings.Length)
                    {
                        string roomAllocationString = string.Empty;
                        for (int j = 0; j < 2; j++)
                        {
                            roomAllocationString += strings[i + j] + "\n";
                        }

                        RoomAllocations.Add(RoomAllocation.GetRoomAllocation(roomAllocationString));
                        i += 2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddRoomAllocation(RoomAllocation roomAllocation)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nINSERT INTO RoomAllocation (ID_Guest, Number_Of_Room) VALUES " +
                        $"({roomAllocation.IDGuest}, {roomAllocation.NumberOfRoom})";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetRoomAllocationFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add room allocation: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveRoomAllocation(RoomAllocation roomAllocation)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nDELETE FROM RoomAllocation WHERE " +
                        $"ID_Guest = {roomAllocation.IDGuest} AND Number_Of_Room = {roomAllocation.NumberOfRoom}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetRoomAllocationFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to remove room allocation: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void EditRoomAllocation(RoomAllocation oldRoomAllocation, RoomAllocation newRoomAllocation)
        {
            try
            {
                if (NetworkStream is not null)
                {
                    string message = $"SqlExpression\nUPDATE RoomAllocation SET " +
                        $"ID_Guest = {newRoomAllocation.IDGuest}, Number_Of_Room = {newRoomAllocation.NumberOfRoom} WHERE " +
                        $"ID_Guest = {oldRoomAllocation.IDGuest} AND Number_Of_Room = {oldRoomAllocation.NumberOfRoom}";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[256];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    if (message == "Complete")
                    {
                        GetRoomAllocationFromServer();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to edit room allocation: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DisconnectFromServer()
        {
            try
            {
                if (NetworkStream is not null && Client is not null)
                {
                    string message = $"Disconnect";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);

                    NetworkStream.Close();
                    Client.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
