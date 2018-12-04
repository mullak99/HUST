using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniWebsite
{
    public partial class GetAllStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> studentNames = new List<string>();
            List<string> studentLocations = new List<string>();
            List<DateTime> times = new List<DateTime>();

            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                var query = "SELECT CONCAT(FirstName, ' ', LastName) AS FullName, Location, Time FROM students";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentNames.Add(reader[0].ToString());
                            studentLocations.Add(reader[1].ToString());
                            times.Add(Utils.UnixTimeStampToDateTime(Convert.ToDouble(reader[2].ToString())));
                        }
                    }
                }
                SetTable(studentNames, studentLocations, times);
            }
        }

        protected void SetTable(List<string> studentNames, List<string> studentLocations, List<DateTime> times)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Student Name", typeof(string));
                dt.Columns.Add("Student Location", typeof(string));
                dt.Columns.Add("Check-In Time", typeof(string));
            }

            for (int i = 0; i < studentNames.Count; i++)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = studentNames[i];
                NewRow[1] = studentLocations[i];
                NewRow[2] = times[i].ToString("dd/MM/yyyy hh:mm:ss tt");
                dt.Rows.Add(NewRow);
            }
            allStudentsTable.DataSource = dt;
            allStudentsTable.DataBind();
        }
    }
}