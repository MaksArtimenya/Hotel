using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class RoomAllocation
    {
        public int IDGuest { get; set; }
        public int NumberOfRoom { get; set; }
        public RoomAllocation(int idGuest, int numberOfRoom)
        {
            IDGuest = idGuest;
            NumberOfRoom = numberOfRoom;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null ||  obj.GetType() != typeof(RoomAllocation))
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
