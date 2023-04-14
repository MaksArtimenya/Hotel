using System.Data.SqlClient;

namespace Hotel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < InternalData.Rooms.Count; i++)
            {
                dataGridViewShowRooms.Rows.Add(InternalData.Rooms[i].Number, InternalData.Rooms[i].NumberOfPlaces,
                    InternalData.Rooms[i].OccupiedPlaces, InternalData.Rooms[i].Price);
            }
        }

        private void buttonToEditingGuests_Click(object sender, EventArgs e)
        {
            new EditingGuestsForm().ShowDialog();
        }
    }
}