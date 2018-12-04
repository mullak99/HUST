using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class GetAllStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Student> allStudents = SQL_Methods.GetAllStudents();

            try
            {
                SetTable(allStudents.Select(i => i.getFullName()).ToList(), allStudents.Select(i => i.LatestLocation.getLocation()).ToList(), allStudents.Select(i => i.LatestLocation.getCheckInString()).ToList());
            }
            catch
            {
                SetTable(allStudents.Select(i => i.getFullName()).ToList());
            }
        }

        protected void SetTable(List<string> studentNames, List<string> studentLocations = null, List<string> times = null)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Student Name", typeof(string));
                dt.Columns.Add("Student Location", typeof(string));
                dt.Columns.Add("Check-In Time", typeof(string));
            }

            for (int i = 0; i < studentNames.Count; i++)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = studentNames[i];

                if (studentLocations != null && !String.IsNullOrEmpty(studentLocations[i]))
                    NewRow[1] = studentLocations[i];
                else
                    NewRow[1] = "No Location";


                if (times != null && !String.IsNullOrEmpty(times[i]))
                    NewRow[2] = times[i];
                else
                    NewRow[2] = "No Check-In Time";

                dt.Rows.Add(NewRow);
            }
            allStudentsTable.DataSource = dt;
            allStudentsTable.DataBind();
        }
    }
}