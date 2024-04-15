using Hotel.Internal;

namespace Hotel
{
    public partial class MainForm : Form
    {
        private bool checkConnection = true;

        public MainForm()
        {
            InitializeComponent();
            ChangeLabelWelcomeText();
            CheckingTypeOfUser();

            Task.Run(CheckingConnection);
        }

        private void CheckingTypeOfUser()
        {
            switch (InternalData.User.TypeOfUser)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    buttonToEditingGuests.Enabled = false;
                    radioButtonGuest.Enabled = false;
                    break;
            }
        }

        private void ChangeLabelWelcomeText()
        {
            switch (InternalData.User.TypeOfUser)
            {
                case 0:
                    labelWelcome.Text = $"Вы вошли как: {InternalData.User.Name.Trim()} (Администратор)";
                    break;
                case 1:
                    labelWelcome.Text = $"Вы вошли как: {InternalData.User.Name.Trim()} (Постоялец)";
                    break;
                case 2:
                    labelWelcome.Text = $"Вы вошли как: {InternalData.User.Name.Trim()} (Гость)";
                    break;
            }
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
                    if (InternalData.Guests[i].FullName.Trim().Contains(desired))
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].Gender.Trim() == desired)
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].PassportID.Trim() == desired && InternalData.User.TypeOfUser == 0)
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].ArrivalDate.Trim() == desired && InternalData.User.TypeOfUser == 0)
                    {
                        found = true;
                    }

                    if (InternalData.Guests[i].LengthOfStay.Trim() == desired && InternalData.User.TypeOfUser == 0)
                    {
                        found = true;
                    }

                    if (found && InternalData.User.TypeOfUser == 0)
                    {
                        dataGridViewShowGuests.Rows.Add(InternalData.Guests[i].FullName, InternalData.Guests[i].Gender,
                            InternalData.Guests[i].PassportID, InternalData.Guests[i].ArrivalDate, InternalData.Guests[i].LengthOfStay);
                    }
                    else if (found)
                    {
                        dataGridViewShowGuests.Rows.Add(InternalData.Guests[i].FullName, InternalData.Guests[i].Gender,
                            "*****", "*****", "*****");
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkConnection = false;
            InternalData.DisconnectFromServer();
        }

        private void timerForErrorLabel_Tick(object sender, EventArgs e)
        {
            if (InternalData.IsConnected)
            {
                labelError.Visible = false;
                progressBarReconnect.Visible = false;
            }
            else
            {
                labelError.Visible = true;
                progressBarReconnect.Visible = true;
            }
        }

        private async Task CheckingConnection()
        {
            while (checkConnection)
            {
                InternalData.TestingConnection();
                if (!InternalData.IsConnected)
                {
                    InternalData.ReconnectToServer();
                }

                await Task.Delay(3000);
            }
        }
    }
}