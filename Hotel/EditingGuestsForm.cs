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
        public EditingGuestsForm()
        {
            InitializeComponent();
            InternalData.GetGuestsFromDB();
            listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());
        }

        private void buttonSaveNewGuest_Click(object sender, EventArgs e)
        {
            Guest newGuest = new Guest(textBoxFullName.Text, textBoxGender.Text,
                textBoxPassportID.Text, textBoxArrivalDate.Text, textBoxLengthOfStay.Text);
            InternalData.Guests.Add(newGuest);
            listBoxShowGuests.Items.Clear();
            listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());
            InternalData.AddGuestToDB(newGuest);
        }
    }
}
