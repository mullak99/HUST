using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class ChangeStudentLocation : System.Web.UI.Page
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

        protected void selectStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student student = SQL_Methods.GetStudent(Convert.ToInt32(selectStudentList.SelectedValue));

            try
            {
                if (!String.IsNullOrEmpty(student.LatestLocation.getLocation()))
                    currentLoc.Text = student.LatestLocation.getLocation();
                else
                    currentLoc.Text = "No Location";

                checkinTime.Text = student.LatestLocation.getCheckInString();
            }
            catch
            {
                currentLoc.Text = "No Location";
                checkinTime.Text = "No Check-In Time";
            }
        }

        protected void editStudentLocButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(changeStudentLoc.Text) && !String.IsNullOrWhiteSpace(changeStudentLoc.Text))
            {
                SQL_Methods.SetStudentCurrentLocation(Convert.ToInt32(selectStudentList.SelectedValue), Utils.UppercaseFirst(changeStudentLoc.Text));
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}