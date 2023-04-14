using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class Room
    {
        public int Number { get; set; }
        public int NumberOfPlaces { get; set; }
        public int OccupiedPlaces { get; set; }
        public int Price { get; set; }
        public int FreePlaces
        {
            get { return NumberOfPlaces - OccupiedPlaces; }
        }

        public Room(int number, int numberOfPlaces, int occupiedPlaces, int price)
        {
            Number = number;
            NumberOfPlaces = numberOfPlaces;
            OccupiedPlaces = occupiedPlaces;
            Price = price;
        }

        public override string ToString()
        {
            return Number + $" ({FreePlaces})";
        }
    }
}
