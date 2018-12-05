using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class CurrentLocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Student> allStudents = SQL_Methods.GetAllStudents();

                Utils.PopulateLocationDropDown(allStudents, ref selectLocationList);
                selectLocationList_SelectedIndexChanged(sender, e);
            }
        }

        DataTable studentTable = new DataTable();

        protected void selectLocationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTable(SQL_Methods.GetStudentsAtLocation(selectLocationList.SelectedItem.Value));
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
                NewRow[1] = student.LatestLocation.getLocation();
                NewRow[2] = student.LatestLocation.getCheckInString();

                studentTable.Rows.Add(NewRow);
            }

            StudentGrid.DataSource = studentTable;
            StudentGrid.DataBind();
        }
    }
}