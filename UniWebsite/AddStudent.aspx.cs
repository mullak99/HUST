using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void addStudent_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(studentLastName.Text) && !String.IsNullOrEmpty(studentFirstName.Text))
            {
                SQL_Methods.AddStudent(studentFirstName.Text, studentLastName.Text);
            }
        }
    }
}