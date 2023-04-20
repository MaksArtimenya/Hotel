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
            buttonClearSearch_Click(sender, e);
        }

        private void buttonToEditingRooms_Click(object sender, EventArgs e)
        {
            new EditRoomsForm().ShowDialog();
            buttonClearSearch_Click(sender, e);
        }

        private void radioButtonRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRoom.Checked)
            {
                dataGridViewShowRooms.Enabled = true;
                dataGridViewShowRooms.Visible = true;
                dataGridViewShowGuests.Enabled = false;
                dataGridViewShowGuests.Visible = false;
                buttonClearSearch_Click(sender, e);
            }
        }

        private void radioButtonGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGuest.Checked)
            {
                dataGridViewShowGuests.Enabled = true;
                dataGridViewShowGuests.Visible = true;
                dataGridViewShowRooms.Enabled = false;
                dataGridViewShowRooms.Visible = false;
                buttonClearSearch_Click(sender, e);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewShowRooms.Rows.Clear();
            dataGridViewShowGuests.Rows.Clear();
            string desired = textBoxDesiredObject.Text.Trim();
            if (radioButtonRoom.Checked)
            {
                for (int i = 0; i < InternalData.Rooms.Count; i++)
                {
                    bool found = false;
                    if (InternalData.Rooms[i].Number.ToString() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Rooms[i].NumberOfPlaces.ToString() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Rooms[i].OccupiedPlaces.ToString() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Rooms[i].FreePlaces.ToString() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Rooms[i].Price.ToString() == desired)
                    {
                        found = true;
                    }

                    if (found)
                    {
                        dataGridViewShowRooms.Rows.Add(InternalData.Rooms[i].Number, InternalData.Rooms[i].NumberOfPlaces,
                            InternalData.Rooms[i].OccupiedPlaces, InternalData.Rooms[i].FreePlaces, InternalData.Rooms[i].Price);
                    }
                }
            }
            else
            {
                for (int i = 0; i < InternalData.Guests.Count; i++)
                {
                    bool found = false;
                    if (InternalData.Guests[i].FullName.Trim() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].Gender.Trim() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].PassportID.Trim() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].ArrivalDate.Trim() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].LengthOfStay.Trim() == desired)
                    {
                        found = true;
                    }

                    if (found)
                    {
                        dataGridViewShowGuests.Rows.Add(InternalData.Guests[i].FullName, InternalData.Guests[i].Gender,
                            InternalData.Guests[i].PassportID, InternalData.Guests[i].ArrivalDate, InternalData.Guests[i].LengthOfStay);
                    }
                }
            }
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            dataGridViewShowRooms.Rows.Clear();
            dataGridViewShowGuests.Rows.Clear();
            textBoxDesiredObject.Text = string.Empty;
        }
    }
}