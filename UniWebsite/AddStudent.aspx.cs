using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            if (!String.IsNullOrEmpty(studentLastName.Text) && !String.IsNullOrEmpty(studentFirstName.Text) && !String.IsNullOrEmpty(studentLocation.Text))
            {
                using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
                {

                    string LastName = studentLastName.Text;
                    string FirstName = studentFirstName.Text;
                    string Location = studentLocation.Text;

                    MySqlCommand checkIfExists = new MySqlCommand("SELECT * FROM students WHERE (FirstName = '" + FirstName + "') AND (LastName = '" + LastName + "')", connection);

                    if ((int)checkIfExists.ExecuteScalar() == 0)
                    {
                        int Time = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                        var query = "INSERT INTO students (LastName, FirstName, Location, Time) VALUES (@lastName, @firstName, @location, @time)";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@lastName", LastName);
                            command.Parameters.AddWithValue("@firstName", FirstName);
                            command.Parameters.AddWithValue("@location", Location);
                            command.Parameters.AddWithValue("@time", Time);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}