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

            SetTable(allStudents);
        }

        protected void SetTable(List<Student> allStudents)
        {
            DataTable studentTable = new DataTable();

            if (studentTable.Columns.Count == 0)
            {
                studentTable.Columns.Add("Student Name", typeof(string));
                studentTable.Columns.Add("Current Student Location", typeof(string));
                studentTable.Columns.Add("Location Check-In Time", typeof(string));
            }

            foreach (Student student in allStudents)
            {
                DataRow NewRow = studentTable.NewRow();
                NewRow[0] = student.getFullName();

                try
                {
                    if (!String.IsNullOrEmpty(student.LatestLocation.getLocation()))
                        NewRow[1] = student.LatestLocation.getLocation();
                    else
                        NewRow[1] = "No Location";

                    NewRow[2] = student.LatestLocation.getCheckInString();
                }
                catch
                {
                    NewRow[1] = "No Location";
                    NewRow[2] = "No Check-In Time";
                }

                studentTable.Rows.Add(NewRow);
            }

            allStudentsTable.DataSource = studentTable;
            allStudentsTable.DataBind();
        }
    }
}