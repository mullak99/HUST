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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void addStudent_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {

                string LastName = studentLastName.Text;
                string FirstName = studentFirstName.Text;
                string Location = studentLocation.Text;
                int Time = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                var query = "INSERT INTO students (LastName, FirstName, Location, Time) VALUES (@lastName, @firstName, @location, @time)";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    // Add your parameters
                    command.Parameters.AddWithValue("@lastName", LastName);
                    command.Parameters.AddWithValue("@firstName", FirstName);
                    command.Parameters.AddWithValue("@location", Location);
                    command.Parameters.AddWithValue("@time", Time);
                    // Execute your query
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}