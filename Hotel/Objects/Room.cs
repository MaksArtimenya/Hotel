namespace Hotel.Objects
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

        public static Room GetRoom(string roomString)
        {
            string[] strings = roomString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return new Room(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), int.Parse(strings[3]));
        }

        public override string ToString()
        {
            if (Number != -1)
            {
                return Number + $" (Свободно: {FreePlaces} из {NumberOfPlaces})";
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
