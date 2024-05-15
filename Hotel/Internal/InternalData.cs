using System.Net.Sockets;
using System.Text;
using Hotel.Objects;

namespace Hotel.Internal
{
    internal static class InternalData
    {
        public static readonly SignInForm signInForm = new SignInForm();
        public static TcpClient? Client { get; private set; }
        public static NetworkStream? NetworkStream { get; private set; }
        public static bool IsConnected { get; private set; }
        public static User User { get; private set; } = new User(string.Empty, -1);

        public static List<Guest> Guests { get; set; } = new List<Guest>();
        public static List<Room> Rooms { get; set; } = new List<Room>();
        public static List<RoomAllocation> RoomAllocations { get; set; } = new List<RoomAllocation>();
        public static List<History> Histories { get; set; } = new List<History>();

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
                IsConnected = true;
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
                if (NetworkStream is not null && IsConnected)
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
                    if (message != "empty")
                    {
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                    if (message != "empty")
                    {
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                    if (message != "empty")
                    {
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nUPDATE Rooms SET " +
                        $"Number = {newRoom.Number}, Number_Of_Places = {newRoom.NumberOfPlaces}," +
                        $" Occupied_Places = {newRoom.OccupiedPlaces}, Price = {newRoom.Price} WHERE " +
                        $"Number = {oldRoom.Number} AND Number_Of_Places = {oldRoom.NumberOfPlaces} AND" +
                        /*$" Occupied_Places = {oldRoom.OccupiedPlaces} AND Price = {oldRoom.Price}";*/
                        $" Price = {oldRoom.Price}";
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                    if (message != "empty")
                    {
                        string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        while (i < strings.Length)
                        {
                            string roomAllocationString = string.Empty;
                            for (int j = 0; j < 3; j++)
                            {
                                roomAllocationString += strings[i + j] + "\n";
                            }

                            RoomAllocations.Add(RoomAllocation.GetRoomAllocation(roomAllocationString));
                            i += 3;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nINSERT INTO RoomAllocation (ID_Guest, Number_Of_Room, Type_Of_Payment) VALUES " +
                        $"({roomAllocation.IDGuest}, {roomAllocation.NumberOfRoom}, {roomAllocation.TypeOfPayment})";
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nUPDATE RoomAllocation SET " +
                        $"ID_Guest = {newRoomAllocation.IDGuest}, Number_Of_Room = {newRoomAllocation.NumberOfRoom}, " +
                        $"Type_Of_Payment = {newRoomAllocation.TypeOfPayment} WHERE " +
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
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetHistoryFromServer()
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = "GetHistory";
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
                    Histories.Clear();
                    if (message != "empty")
                    {
                        string[] strings = message.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        while (i < strings.Length)
                        {
                            string historyString = string.Empty;
                            for (int j = 0; j < 5; j++)
                            {
                                historyString += strings[i + j] + "\n";
                            }

                            Histories.Add(History.GetHistory(historyString));
                            i += 5;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddHistory(History history)
        {
            try
            {
                if (NetworkStream is not null && IsConnected)
                {
                    string message = $"SqlExpression\nINSERT INTO PaymentsHistory (Date, Full_Name, Payment_Method, Payment_Amount, Employee) VALUES " +
                        $"('{history.Date}', '{history.FullName}', '{history.PaymentMethod}', {history.PaymentAmount}, '{history.User}')";
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
                        MessageBox.Show($"Failed to add history: {message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с сервером");
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
                    if (IsConnected)
                    {
                        string message = $"Disconnect";
                        byte[] data = Encoding.Unicode.GetBytes(message);
                        NetworkStream.Write(data, 0, data.Length);
                    }

                    NetworkStream.Close();
                    Client.Close();
                    IsConnected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void TestingConnection()
        {
            try
            {
                if (signInForm.IPEndPoint is null || NetworkStream is null)
                {
                    IsConnected = false;
                }
                else
                {
                    string message = $"Test";

                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                }
            }
            catch
            {
                IsConnected = false;
                if (NetworkStream is not null && Client is not null)
                {
                    NetworkStream.Close();
                    Client.Close();
                }
            }
        }

        public static void ReconnectToServer()
        {
            try
            {
                if (Client is not null && signInForm.IPEndPoint is not null)
                {
                    Client = new TcpClient(signInForm.IPEndPoint.Address.ToString(), signInForm.IPEndPoint.Port);
                    NetworkStream = Client.GetStream();

                    string message = $"Reconnect\n{User.Name}\n{User.TypeOfUser}";

                    byte[] data = Encoding.Unicode.GetBytes(message);
                    NetworkStream.Write(data, 0, data.Length);
                    data = new byte[2048];
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = NetworkStream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (NetworkStream.DataAvailable);

                    message = response.ToString();

                    IsConnected = true;
                }
            }
            catch
            {
                IsConnected = false;
            }
        }
    }
}
