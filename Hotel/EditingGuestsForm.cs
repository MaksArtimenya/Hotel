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
        private int bufIdOfAvaibleRooms = 0;

        public EditingGuestsForm()
        {
            InitializeComponent();
            InternalData.GetGuestsFromDB();
            InternalData.GetRoomsFromDB();
            InternalData.GetRoomAllocationFromDB();
            listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());
            listBoxShowAvaibleRooms.Items.AddRange(InternalData.Rooms.ToArray());
            listBoxShowAvaibleRooms.Items.Insert(0, new Room(-1, -1, -1, -1));
            listBoxShowAvaibleRooms.SelectedIndex = 0;
            groupBox1.Text = namesOfGroupBox[0];
        }

        private void buttonSaveNewGuest_Click(object sender, EventArgs e)
        {
            Guest newGuest = new Guest(textBoxFullName.Text, textBoxGender.Text,
                textBoxPassportID.Text, textBoxArrivalDate.Text, textBoxLengthOfStay.Text);
            if (groupBox1.Text == namesOfGroupBox[0])
            {
                InternalData.AddGuest(newGuest);
                listBoxShowGuests.Items.Clear();
                listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());

                if (listBoxShowAvaibleRooms.SelectedIndex != 0)
                {
                    InternalData.AddRoomAllocation(new RoomAllocation(InternalData.GetGuestID(newGuest),
                        ((Room)listBoxShowAvaibleRooms.Items[listBoxShowAvaibleRooms.SelectedIndex]).Number));
                    //TODO change count of free rooms
                }
            }
            else
            {
                Guest oldGuest = (Guest)listBoxShowGuests.Items[listBoxShowGuests.SelectedIndex];
                InternalData.EditGuest(oldGuest, newGuest);
                listBoxShowGuests.Items.Clear();
                listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());

                if (listBoxShowAvaibleRooms.SelectedIndex != 0)
                {
                    if (bufIdOfAvaibleRooms != 0)
                    {
                        RoomAllocation oldRoomAllocation = new RoomAllocation(InternalData.GetGuestID(newGuest),
                            ((Room)listBoxShowAvaibleRooms.Items[bufIdOfAvaibleRooms]).Number);
                        RoomAllocation newRoomAllocation = new RoomAllocation(InternalData.GetGuestID(newGuest),
                            ((Room)listBoxShowAvaibleRooms.Items[listBoxShowAvaibleRooms.SelectedIndex]).Number);
                        InternalData.EditRoomAllocation(oldRoomAllocation, newRoomAllocation);
                    }
                    else
                    {
                        InternalData.AddRoomAllocation(new RoomAllocation(InternalData.GetGuestID(newGuest),
                            ((Room)listBoxShowAvaibleRooms.Items[listBoxShowAvaibleRooms.SelectedIndex]).Number));
                    }
                }
                else
                {
                    if (bufIdOfAvaibleRooms != 0)
                    {
                        InternalData.RemoveRoomAllocation(new RoomAllocation(InternalData.GetGuestID(newGuest),
                            ((Room)listBoxShowAvaibleRooms.Items[bufIdOfAvaibleRooms]).Number));
                    }
                }
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

                listBoxShowAvaibleRooms.SelectedIndex = 0;
                int guestID = InternalData.GetGuestID(selectedGuest);
                for (int i = 0; i < InternalData.RoomAllocations.Count; i++)
                {
                    if (guestID == InternalData.RoomAllocations[i].IDGuest)
                    {
                        int numberOfRoom = InternalData.RoomAllocations[i].NumberOfRoom;
                        for (int j = 0; j < listBoxShowAvaibleRooms.Items.Count; j++)
                        {
                            if (numberOfRoom == ((Room)listBoxShowAvaibleRooms.Items[j]).Number)
                            {
                                listBoxShowAvaibleRooms.SelectedIndex = j;
                                break;
                            }
                        }

                        break;
                    }
                }
                bufIdOfAvaibleRooms = listBoxShowAvaibleRooms.SelectedIndex;
            }
        }

        private void buttonRemoveGuest_Click(object sender, EventArgs e)
        {
            Guest guest = (Guest)listBoxShowGuests.Items[listBoxShowGuests.SelectedIndex];
            if (bufIdOfAvaibleRooms != 0)
            {
                InternalData.RemoveRoomAllocation(new RoomAllocation(InternalData.GetGuestID(guest),
                    ((Room)listBoxShowAvaibleRooms.Items[bufIdOfAvaibleRooms]).Number));
            }
            InternalData.RemoveGuest(guest);
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
            listBoxShowAvaibleRooms.SelectedIndex = 0;
            buttonRemoveGuest.Enabled = false;
            groupBox1.Text = namesOfGroupBox[0];
        }
    }
}
