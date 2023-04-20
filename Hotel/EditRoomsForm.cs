using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class EditRoomsForm : Form
    {
        private string[] namesOfGroupBox = new string[] { "New room", "Editing room" };
        private string nameOfLabel = "Occupied places: {0}/{1}";

        public EditRoomsForm()
        {
            InitializeComponent();
            listBoxShowRooms.Items.AddRange(InternalData.Rooms.ToArray());
            groupBox1.Text = namesOfGroupBox[0];
            label4.Text = string.Format(nameOfLabel, "-", "-");
        }

        private void buttonSaveRoom_Click(object sender, EventArgs e)
        {
            Room newRoom = new Room(int.Parse(textBoxNumber.Text), int.Parse(textBoxNumberOfPlaces.Text), 0, int.Parse(textBoxPrice.Text));
            if (groupBox1.Text == namesOfGroupBox[0])
            {
                InternalData.AddRoom(newRoom);
            }
            else
            {
                Room oldRoom = (Room)listBoxShowRooms.SelectedItem;
                InternalData.EditRoom(oldRoom, newRoom);
            }

            listBoxShowRooms.Items.Clear();
            listBoxShowRooms.Items.AddRange(InternalData.Rooms.ToArray());
            buttonCancel_Click(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            listBoxShowRooms.SelectedIndex = -1;
            listBoxShowPlacesOfRoom.SelectedIndex = -1;
            textBoxNumber.Text = string.Empty;
            textBoxNumberOfPlaces.Text = string.Empty;
            textBoxPrice.Text = string.Empty;
            buttonRemoveRoom.Enabled = false;
            buttonGuestInfo.Enabled = false;
            buttonSaveRoom.Enabled = false;
            groupBox1.Text = namesOfGroupBox[0];
            label4.Text = string.Format(nameOfLabel, "-", "-");
            listBoxShowPlacesOfRoom.Items.Clear();
        }

        private void listBoxShowRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowRooms.SelectedIndex != -1)
            {
                Room room = (Room)listBoxShowRooms.SelectedItem;
                textBoxNumber.Text = room.Number.ToString();
                textBoxNumberOfPlaces.Text = room.NumberOfPlaces.ToString();
                textBoxPrice.Text = room.Price.ToString();
                buttonRemoveRoom.Enabled = true;
                groupBox1.Text = namesOfGroupBox[1];
                label4.Text = string.Format(nameOfLabel, room.OccupiedPlaces, room.NumberOfPlaces);
                List<Guest> guests = InternalData.GetGuestsByRoom(room);
                listBoxShowPlacesOfRoom.Items.Clear();
                if (guests.Count > 0)
                {
                    listBoxShowPlacesOfRoom.Items.AddRange(guests.ToArray());
                }
            }
        }

        private void buttonRemoveRoom_Click(object sender, EventArgs e)
        {
            Room room = (Room)listBoxShowRooms.SelectedItem;
            InternalData.RemoveRoom(room);
            listBoxShowRooms.Items.Clear();
            listBoxShowRooms.Items.AddRange(InternalData.Rooms.ToArray());
            buttonCancel_Click(sender, e);
            label4.Text = string.Format(nameOfLabel, "-", "-");
        }

        private void textBoxNumberOfPlaces_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void listBoxShowPlacesOfRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowPlacesOfRoom.SelectedIndex != -1)
            {
                buttonGuestInfo.Enabled = true;
            }
        }

        private void buttonGuestInfo_Click(object sender, EventArgs e)
        {
            Guest guest = (Guest)listBoxShowPlacesOfRoom.SelectedItem;
            MessageBox.Show($"Guest:" + $"\nFull name: {guest.FullName}" +
                $"\nGender: {guest.Gender}" +
                $"\nPassport ID: {guest.PassportID}" +
                $"\nArrival date: {guest.ArrivalDate}" +
                $"\nLength of stay: {guest.LengthOfStay}");
        }

        private void CheckTextBoxes()
        {
            bool check = true;
            try
            {
                int.Parse(textBoxNumber.Text);
                textBoxNumber.ForeColor = Color.Black;
            }
            catch (Exception)
            {
                textBoxNumber.ForeColor = Color.Red;
                check = false;
            }

            try
            {
                label4.Text = string.Format(nameOfLabel, 0, int.Parse(textBoxNumberOfPlaces.Text));
                textBoxNumberOfPlaces.ForeColor = Color.Black;
            }
            catch (Exception)
            {
                textBoxNumberOfPlaces.ForeColor = Color.Red;
                check = false;
                label4.Text = string.Format(nameOfLabel, "-", "-");
            }

            try
            {
                int.Parse(textBoxPrice.Text);
                textBoxPrice.ForeColor = Color.Black;
            }
            catch (Exception)
            {
                textBoxPrice.ForeColor = Color.Red;
                check = false;
            }

            if (check)
            {
                buttonSaveRoom.Enabled = true;
            }
            else
            {
                buttonSaveRoom.Enabled = false;
            }
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }
    }
}
