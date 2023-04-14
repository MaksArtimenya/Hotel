using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class Guest
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string PassportID { get; set; }
        public string ArrivalDate { get; set; }
        public string LengthOfStay { get; set; }

        public Guest(string fullName, string gender, string passportID, string arrivalDate, string lengthOfStay)
        {
            FullName = fullName;
            Gender = gender;
            PassportID = passportID;
            ArrivalDate = arrivalDate;
            LengthOfStay = lengthOfStay;
        }

        public override string ToString()
        {
            return FullName;
        }

    }
}
