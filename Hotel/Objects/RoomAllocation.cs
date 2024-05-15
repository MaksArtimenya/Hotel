namespace Hotel.Objects
{
    internal class RoomAllocation
    {
        public int IDGuest { get; set; }
        public int NumberOfRoom { get; set; }
        public int TypeOfPayment { get; set; }
        public RoomAllocation(int idGuest, int numberOfRoom, int typeOfPayment)
        {
            IDGuest = idGuest;
            NumberOfRoom = numberOfRoom;
            TypeOfPayment = typeOfPayment;
        }

        public static RoomAllocation GetRoomAllocation(string roomAllocationString)
        {
            string[] strings = roomAllocationString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            return new RoomAllocation(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]));
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != typeof(RoomAllocation))
            {
                return false;
            }
            else
            {
                if (((RoomAllocation)obj).IDGuest == IDGuest && ((RoomAllocation)obj).NumberOfRoom == NumberOfRoom)
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
