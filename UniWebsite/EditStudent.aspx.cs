using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class EditStudent : System.Web.UI.Page
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

            studentFirstName.Text = student.FirstName;
            studentLastName.Text = student.LastName;
        }

        protected void editStudentButton_Click(object sender, EventArgs e)
        {
            SQL_Methods.EditStudent(Convert.ToInt32(selectStudentList.SelectedValue), studentFirstName.Text, studentLastName.Text);
        }

        protected void deleteStudentButton_Click(object sender, EventArgs e)
        {
            SQL_Methods.DeleteStudent(Convert.ToInt32(selectStudentList.SelectedValue));
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}