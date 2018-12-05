using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public class Utils
    {
        public static int CurrentUnixTimestamp()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static string SqlEscape(string usString)
        {
            if (usString == null)
                return null;

            return Regex.Replace(usString, @"[\r\n\x00\x1a\\'""]", @"\$0");
        }

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static void PopulateStudentDropDown(List<Student> students, ref DropDownList dropDownList)
        {
            dropDownList.DataSource = students;
            dropDownList.DataTextField = "FullName";
            dropDownList.DataValueField = "UID";
            dropDownList.DataBind();
        }

        public static void PopulateLocationDropDown(List<Student> students, ref DropDownList dropDownList)
        {            
            List<string> locations = new List<string>();

            foreach (Student student in students)
            {
                try
                {
                    if (!locations.Contains(student.LatestLocation.CheckInLocation))
                        locations.Add(student.LatestLocation.CheckInLocation);
                }
                catch
                { }
            }

            dropDownList.DataSource = locations;
            dropDownList.DataBind();
        }
    }
}