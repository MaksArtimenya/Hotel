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
            if (Number != -1)
            {
                return Number + $" (Free {FreePlaces} of {NumberOfPlaces})";
            }
            else
            {
                return "-";
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != typeof(Room))
            {
                return false;
            }
            else
            {
                if (((Room)obj).Number == Number && ((Room)obj).NumberOfPlaces == NumberOfPlaces &&
                    ((Room)obj).OccupiedPlaces == OccupiedPlaces && ((Room)obj).Price == Price)
                {
                    return true;
                }

                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
