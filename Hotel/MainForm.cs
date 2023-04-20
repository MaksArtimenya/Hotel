using System.Data.SqlClient;

namespace Hotel
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonToEditingGuests_Click(object sender, EventArgs e)
        {
            new EditingGuestsForm().ShowDialog();
        }

        private void buttonToEditingRooms_Click(object sender, EventArgs e)
        {
            new EditRoomsForm().ShowDialog();
        }

        private void radioButtonRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRoom.Checked)
            {
                dataGridViewShowRooms.Enabled = true;
                dataGridViewShowRooms.Visible = true;
                dataGridViewShowGuests.Enabled = false;
                dataGridViewShowGuests.Visible = false;
            }
        }

        private void radioButtonGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGuest.Checked)
            {
                dataGridViewShowRooms.Enabled = false;
                dataGridViewShowRooms.Visible = false;
                dataGridViewShowGuests.Enabled = true;
                dataGridViewShowGuests.Visible = true;
            }
        }
    }
}