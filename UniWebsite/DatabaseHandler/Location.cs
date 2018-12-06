using System;

namespace UniWebsite
{
    public class Location
    {
        public int LocationUID { get; private set; }
        public string CheckInLocation { get; private set; }
        public DateTime CheckIn { get; private set; }

        public Location(int locationUID, string location, DateTime checkIn)
        {
            this.LocationUID = locationUID;
            this.CheckInLocation = location;
            this.CheckIn = checkIn;
        }

        public string getLocation()
        {
            return CheckInLocation;
        }

        public DateTime getCheckInTime()
        {
            return CheckIn;
        }

        public string getCheckInString()
        {
            if (CheckIn != null)
                return CheckIn.ToString("dd/MM/yyyy hh:mm:ss tt");
            else
                return "No Check-In Time";
        }

        public override string ToString()
        {
            return String.Format("Latest Location: {0}, Check-In Time: {1}", CheckInLocation, getCheckInString());
        }
    }
}