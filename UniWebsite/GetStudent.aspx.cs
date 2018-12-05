using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class GetStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Student> allStudents = SQL_Methods.GetAllStudents();

                Utils.PopulateStudentDropDown(allStudents, ref selectStudentList);
                selectStudentList_SelectedIndexChanged(sender, e);
            }
        }

        DataTable studentTable = new DataTable();
        DataTable locationHistory = new DataTable();

        protected void selectStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStudentTable();
            UpdateLocationTable();
        }

        private void UpdateStudentTable()
        {
            Student student = SQL_Methods.GetStudent(Convert.ToInt32(selectStudentList.SelectedValue));
            studentTable.Clear();

            if (studentTable.Columns.Count == 0)
            {
                studentTable.Columns.Add("Student Name", typeof(string));
                studentTable.Columns.Add("Current Student Location", typeof(string));
                studentTable.Columns.Add("Location Check-In Time", typeof(string));
            }

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
            StudentGrid.DataSource = studentTable;
            StudentGrid.DataBind();
        }

        private void UpdateLocationTable()
        {
            try
            {
                

                List<Location> allLocations = SQL_Methods.GetStudentsLocationHistory(Convert.ToInt32(selectStudentList.SelectedValue));

                DateTime now = DateTime.UtcNow;

                List<Location> past24Locations = allLocations.Where(i => i.getCheckInTime() > now.AddDays(-1)).ToList();

                locationHistory.Clear();

                if (locationHistory.Columns.Count == 0)
                {
                    locationHistory.Columns.Add("Student Location", typeof(string));
                    locationHistory.Columns.Add("Location Check-In Time", typeof(string));
                }

                foreach (Location loc in past24Locations)
                {
                    DataRow NewRow = locationHistory.NewRow();
                    NewRow[0] = loc.getLocation();
                    NewRow[1] = loc.getCheckInString();
                    locationHistory.Rows.Add(NewRow);
                }

                LocationGrid.DataSource = locationHistory;
                LocationGrid.DataBind();
            }
            catch
            {
                locationHistory.Clear();
            }

            if (locationHistory.Rows.Count > 0)
                locationHistoryLabel.Visible = true;
            else
                locationHistoryLabel.Visible = false;
        }
    }
}