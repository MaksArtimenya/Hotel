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
    public partial class EditingGuestsForm : Form
    {
        private string[] namesOfGroupBox = new string[] { "New guest", "Editing guest" };

        public EditingGuestsForm()
        {
            InitializeComponent();
            InternalData.GetGuestsFromDB();
            InternalData.GetRoomsFromDB();
            listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());
            listBoxShowAvaibleRooms.Items.AddRange(InternalData.Rooms.ToArray());
            groupBox1.Text = namesOfGroupBox[0];
        }

        private void buttonSaveNewGuest_Click(object sender, EventArgs e)
        {
            Guest newGuest = new Guest(textBoxFullName.Text, textBoxGender.Text,
                textBoxPassportID.Text, textBoxArrivalDate.Text, textBoxLengthOfStay.Text);
            if (groupBox1.Text == namesOfGroupBox[0])
            {
                InternalData.Guests.Add(newGuest);
                listBoxShowGuests.Items.Clear();
                listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());
                InternalData.AddGuestToDB(newGuest);
            }
            else
            {
                Guest oldGuest = (Guest)listBoxShowGuests.Items[listBoxShowGuests.SelectedIndex];
                InternalData.EditGuest(oldGuest, newGuest);
                listBoxShowGuests.Items.Clear();
                listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());
            }

            buttonCancel_Click(sender, e);
        }

        private void listBoxShowGuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowGuests.SelectedIndex != -1)
            {
                groupBox1.Text = namesOfGroupBox[1];
                buttonRemoveGuest.Enabled = true;
                Guest selectedGuest = (Guest)listBoxShowGuests.Items[listBoxShowGuests.SelectedIndex];
                textBoxFullName.Text = selectedGuest.FullName;
                textBoxGender.Text = selectedGuest.Gender;
                textBoxPassportID.Text = selectedGuest.PassportID;
                textBoxArrivalDate.Text = selectedGuest.ArrivalDate;
                textBoxLengthOfStay.Text = selectedGuest.LengthOfStay;
            }
        }

        private void buttonRemoveGuest_Click(object sender, EventArgs e)
        {
            InternalData.RemoveGuest((Guest)listBoxShowGuests.Items[listBoxShowGuests.SelectedIndex]);
            listBoxShowGuests.Items.Remove(listBoxShowGuests.Items[listBoxShowGuests.SelectedIndex]);
            buttonCancel_Click(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxFullName.Text = string.Empty;
            textBoxGender.Text = string.Empty;
            textBoxPassportID.Text = string.Empty;
            textBoxArrivalDate.Text = string.Empty;
            textBoxLengthOfStay.Text = string.Empty;
            listBoxShowGuests.SelectedIndex = -1;
            buttonRemoveGuest.Enabled = false;
            groupBox1.Text = namesOfGroupBox[0];
        }
    }
}
