using System;

namespace HUST
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void addStudent_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(studentLastName.Text) && !String.IsNullOrEmpty(studentFirstName.Text) && !String.IsNullOrWhiteSpace(studentLastName.Text) && !String.IsNullOrWhiteSpace(studentFirstName.Text))
            {
                messageLabel.Text = String.Format("Student: '{0} {1}' added to the database.", studentFirstName.Text, studentLastName.Text);
                SQL_Methods.AddStudent(studentFirstName.Text, studentLastName.Text);
            }
            else
            {
                messageLabel.Text = String.Format("Please enter a valid first and last name!");
            }
        }
    }
}