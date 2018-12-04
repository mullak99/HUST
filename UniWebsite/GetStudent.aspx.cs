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
                List<Student> allStudents = new List<Student>();

                allStudents = SQL_Methods.GetAllStudents();
                Utils.PopulateStudentDropDown(allStudents, ref selectStudentList);
                selectStudentList_SelectedIndexChanged(sender, e);
            }
        }

        DataTable dt = new DataTable();

        protected void selectStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student student = SQL_Methods.GetStudent(Convert.ToInt32(selectStudentList.SelectedValue));
            dt.Clear();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Student Name", typeof(string));
                dt.Columns.Add("Student Location", typeof(string));
                dt.Columns.Add("Check-In Time", typeof(string));
            }

            DataRow NewRow = dt.NewRow();
            NewRow[0] = student.getFullName();

            if (!String.IsNullOrEmpty(student.LatestLocation.getLocation()))
                NewRow[1] = student.LatestLocation.getLocation();
            else
                NewRow[1] = "No Location";

            NewRow[2] = student.LatestLocation.getCheckInString();

            dt.Rows.Add(NewRow);
            StudentGrid.DataSource = dt;
            StudentGrid.DataBind();
        }
    }
}