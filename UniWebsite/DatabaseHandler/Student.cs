using System;

namespace HUST
{
    public class Student
    {

        public int UID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        public Location LatestLocation { get; private set; }


        public Student(int UID, string FirstName, string LastName, Location latestLocation)
        {
            this.UID = UID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FullName = FirstName + " " + LastName;
            this.LatestLocation = latestLocation;
        }

        public int getUID()
        {
            return UID;
        }

        public string getFirstName()
        {
            return FirstName;
        }

        public string getLastName()
        {
            return LastName;
        }

        public string getFullName()
        {
            return FullName;
        }

        public Location getLatestLocation()
        {
            return LatestLocation;
        }

        public override string ToString()
        {
            return String.Format("UID: {0}, LastName: {1}, FirstName: {2}, Location: {3}", UID, LastName, FirstName, LatestLocation.ToString());
        }
    }
}