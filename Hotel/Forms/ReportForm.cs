using Hotel.Internal;
using Hotel.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();

            labelReport.Text = $"ОТЧЕТ О ЗАНЯТОСТИ КОМНАТ\nот {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}\n\n\n";
            int allPlaces = 0;
            int allOccupiedPlaces = 0;
            int allFreePlaces = 0;
            foreach (Room room in InternalData.Rooms)
            {
                allPlaces += room.NumberOfPlaces;
                allOccupiedPlaces += room.OccupiedPlaces;
                allFreePlaces += room.FreePlaces;
                labelReport.Text += $"{room.Number} комната" +
                    $"\nВсего мест: {room.NumberOfPlaces}" +
                    $"\nЗанятых мест: {room.OccupiedPlaces}" +
                    $"\nСвободных мест: {room.FreePlaces}" +
                    $"\n\nПостояльцы";
                List<Guest> guests = InternalData.GetGuestsByRoom(room);
                foreach (Guest guest in guests)
                {
                    labelReport.Text += $"\n+{guest.FullName.Trim()} (Дата прибытия: {guest.ArrivalDate.Trim()})";
                }

                labelReport.Text += "\n---------------------------------------------------------\n\n";
            }

            labelReport.Text += $"\n---------------------------------------------------------" +
                $"\n---------------------------------------------------------" +
                $"\nВСЕГО КОМНАТ: {InternalData.Rooms.Count}" +
                $"\nВСЕГО МЕСТ: {allPlaces}" +
                $"\nВСЕГО ЗАНЯТЫХ МЕСТ: {allOccupiedPlaces} ({Math.Round(allOccupiedPlaces * 100 / Convert.ToDouble(allPlaces), 2)}%)" +
                $"\nВСЕГО СВОБОДНЫХ МЕСТ: {allFreePlaces} ({Math.Round(allFreePlaces * 100 / Convert.ToDouble(allPlaces), 2)}%)" +
                $"\n---------------------------------------------------------" +
                $"\n---------------------------------------------------------";
        }

        private void buttonSaveReport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Отчет о занятости комнат.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, labelReport.Text);
                    MessageBox.Show("Отчет сохранен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
