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
        private string[] namesOfGroupBox = new string[] { "Новый постоялец", "Редактирование постояльца" };
        private int bufIdOfAvaibleRooms = 0;

        public EditingGuestsForm()
        {
            InitializeComponent();
            UpdateListBoxes();
            CheckingTypeOfUser();
            buttonSaveNewGuest.Enabled = false;
            groupBox1.Text = namesOfGroupBox[0];
        }

        private void CheckingTypeOfUser()
        {
            if (InternalData.User.TypeOfUser != 0)
            {
                textBoxFullName.ReadOnly = true;
                textBoxGender.ReadOnly = true;
                textBoxPassportID.ReadOnly = true;
                textBoxPassportID.UseSystemPasswordChar = true;
                textBoxArrivalDate.ReadOnly = true;
                textBoxArrivalDate.UseSystemPasswordChar = true;
                textBoxLengthOfStay.ReadOnly = true;
                textBoxLengthOfStay.UseSystemPasswordChar = true;
            }
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
                    Room selectedRoom = (Room)listBoxShowAvaibleRooms.SelectedItem;
                    if (CheckFreePlacesOfRoom(selectedRoom))
                    {
                        InternalData.AddRoomAllocation(new RoomAllocation(InternalData.GetGuestID(newGuest),
                            selectedRoom.Number));
                        InternalData.EditRoom(selectedRoom, new Room(selectedRoom.Number, selectedRoom.NumberOfPlaces,
                            selectedRoom.OccupiedPlaces + 1, selectedRoom.Price));
                    }
                    else
                    {
                        MessageBox.Show("Выбранная комната заполнена");
                    }
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
                        if (bufIdOfAvaibleRooms != listBoxShowAvaibleRooms.SelectedIndex)
                        {
                            Room selectedRoom = (Room)listBoxShowAvaibleRooms.Items[listBoxShowAvaibleRooms.SelectedIndex];
                            Room bufRoom = (Room)listBoxShowAvaibleRooms.Items[bufIdOfAvaibleRooms];
                            if (CheckFreePlacesOfRoom(selectedRoom))
                            {
                                RoomAllocation oldRoomAllocation = new RoomAllocation(InternalData.GetGuestID(newGuest),
                                    bufRoom.Number);
                                RoomAllocation newRoomAllocation = new RoomAllocation(InternalData.GetGuestID(newGuest),
                                    selectedRoom.Number);
                                InternalData.EditRoomAllocation(oldRoomAllocation, newRoomAllocation);
                                InternalData.EditRoom(selectedRoom, new Room(selectedRoom.Number, selectedRoom.NumberOfPlaces,
                                    selectedRoom.OccupiedPlaces + 1, selectedRoom.Price));
                                InternalData.EditRoom(bufRoom, new Room(bufRoom.Number, bufRoom.NumberOfPlaces,
                                    bufRoom.OccupiedPlaces - 1, bufRoom.Price));
                            }
                            else
                            {
                                MessageBox.Show("Выбранная комната заполнена");
                            }
                        }
                    }
                    else
                    {
                        Room selectedRoom = (Room)listBoxShowAvaibleRooms.Items[listBoxShowAvaibleRooms.SelectedIndex];
                        if (CheckFreePlacesOfRoom(selectedRoom))
                        {
                            InternalData.AddRoomAllocation(new RoomAllocation(InternalData.GetGuestID(newGuest),
                                selectedRoom.Number));
                            InternalData.EditRoom(selectedRoom, new Room(selectedRoom.Number, selectedRoom.NumberOfPlaces,
                                selectedRoom.OccupiedPlaces + 1, selectedRoom.Price));
                        }
                        else
                        {
                            MessageBox.Show("Выбранная комната заполнена");
                        }
                    }
                }
                else
                {
                    if (bufIdOfAvaibleRooms != 0)
                    {
                        Room selectedRoom = (Room)listBoxShowAvaibleRooms.Items[bufIdOfAvaibleRooms];
                        InternalData.RemoveRoomAllocation(new RoomAllocation(InternalData.GetGuestID(newGuest),
                            selectedRoom.Number));
                        InternalData.EditRoom(selectedRoom, new Room(selectedRoom.Number, selectedRoom.NumberOfPlaces,
                            selectedRoom.OccupiedPlaces - 1, selectedRoom.Price));
                    }
                }
            }

            buttonCancel_Click(sender, e);
        }

        private bool CheckFreePlacesOfRoom(Room room)
        {
            if (room.FreePlaces > 0)
            {
                return true;
            }

            return false;
        }

        private void listBoxShowGuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowGuests.SelectedIndex != -1)
            {
                groupBox1.Text = namesOfGroupBox[1];
                if (InternalData.User.TypeOfUser == 0)
                {
                    buttonRemoveGuest.Enabled = true;
                }
                
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
            if (bufIdOfAvaibleRooms != 0)
            {
                Room bufRoom = (Room)listBoxShowAvaibleRooms.Items[bufIdOfAvaibleRooms];
                InternalData.EditRoom(bufRoom, new Room(bufRoom.Number, bufRoom.NumberOfPlaces,
                    bufRoom.OccupiedPlaces - 1, bufRoom.Price));
            }
            
            buttonCancel_Click(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxFullName.Text = string.Empty;
            textBoxGender.Text = string.Empty;
            textBoxPassportID.Text = string.Empty;
            textBoxArrivalDate.Text = string.Empty;
            textBoxLengthOfStay.Text = string.Empty;
            listBoxShowAvaibleRooms.SelectedIndex = 0;
            buttonRemoveGuest.Enabled = false;
            buttonSaveNewGuest.Enabled = false;
            groupBox1.Text = namesOfGroupBox[0];
            UpdateListBoxes();
        }

        private void UpdateListBoxes()
        {
            listBoxShowGuests.Items.Clear();
            listBoxShowGuests.Items.AddRange(InternalData.Guests.ToArray());
            listBoxShowAvaibleRooms.Items.Clear();
            listBoxShowAvaibleRooms.Items.AddRange(InternalData.Rooms.ToArray());
            listBoxShowAvaibleRooms.Items.Insert(0, new Room(-1, -1, -1, -1));
            listBoxShowAvaibleRooms.SelectedIndex = 0;
            listBoxShowGuests.SelectedIndex = -1;
        }

        private void buttonRoomInfo_Click(object sender, EventArgs e)
        {
            Room room = (Room)listBoxShowAvaibleRooms.Items[listBoxShowAvaibleRooms.SelectedIndex];
            MessageBox.Show($"Комната:" + $"\nНомер: {room.Number}" +
                $"\nКол-во мест: {room.NumberOfPlaces}" +
                $"\nЗанятые места: {room.OccupiedPlaces}" +
                $"\nСвободные места: {room.FreePlaces}" +
                $"\nЦена: {room.Price}");
        }

        private void listBoxShowAvaibleRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowAvaibleRooms.SelectedIndex == 0)
            {
                buttonRoomInfo.Enabled = false;
            }
            else
            {
                buttonRoomInfo.Enabled = true;
            }
        }

        private void CheckTextBoxes()
        {
            if (textBoxFullName.Text != string.Empty && textBoxGender.Text != string.Empty &&
                textBoxPassportID.Text != string.Empty && textBoxArrivalDate.Text != string.Empty &&
                textBoxLengthOfStay.Text != string.Empty && InternalData.User.TypeOfUser == 0)
            {
                buttonSaveNewGuest.Enabled = true;
            }
            else
            {
                buttonSaveNewGuest.Enabled = false;
            }
        }

        private void textBoxFullName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void textBoxGender_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void textBoxPassportID_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void textBoxArrivalDate_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void textBoxLengthOfStay_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }


    }
}
