using System.Data.SqlClient;

namespace Hotel
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data Source=(local);Initial Catalog=HotelDB;Integrated Security=true";

        public MainForm()
        {
            InitializeComponent();
            try
            {
                string sqlExpression = "SELECT * FROM Rooms";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    dataGridViewShowRooms.Rows.Clear();
                    while (reader.Read())
                    {
                        dataGridViewShowRooms.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
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
    }
}