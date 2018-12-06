using System;
using System.Collections.Generic;

namespace HUST
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
            try
            {
                Student student = SQL_Methods.GetStudent(Convert.ToInt32(selectStudentList.SelectedValue));

                studentFirstName.Text = student.FirstName;
                studentLastName.Text = student.LastName;
                messageDeleteLabel.Text = "";
            }
            catch
            {
                editStudentButton.Enabled = false;
                deleteStudentButton.Enabled = false;
                editStudentButton.Visible = false;
                deleteStudentButton.Visible = false;
                selectStudentLabel.Visible = false;
                selectStudentList.Visible = false;
                studentFirstNameLabel.Visible = false;
                studentFirstName.Visible = false;
                studentLastNameLabel.Visible = false;
                studentLastName.Visible = false;
                NoStudentsWarning.Visible = true;
                messageDeleteLabel.Text = "";
            }
        }

        protected void editStudentButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(studentLastName.Text) && !String.IsNullOrEmpty(studentFirstName.Text) && !String.IsNullOrWhiteSpace(studentLastName.Text) && !String.IsNullOrWhiteSpace(studentFirstName.Text))
                SQL_Methods.EditStudent(Convert.ToInt32(selectStudentList.SelectedValue), studentFirstName.Text, studentLastName.Text);
        }

        protected void deleteStudentButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(messageDeleteLabel.Text))
            {
                SQL_Methods.DeleteStudent(Convert.ToInt32(selectStudentList.SelectedValue));
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                messageDeleteLabel.Text = String.Format("Are you sure you want to permanently delete '{0} {1}' from the database? Press 'Delete Student' again to confirm.", studentFirstName.Text, studentLastName.Text);
            }
        }
    }
}