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
                using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
                {
                    var query = "SELECT UID, CONCAT(FirstName, ' ', LastName) AS FullName FROM students";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        DataSet ds = new DataSet();
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        connection.Open();
                        da.Fill(ds, "Students");

                        selectStudentList.DataSource = ds.Tables[0];
                        selectStudentList.DataTextField = "FullName";
                        selectStudentList.DataValueField = "UID";
                        selectStudentList.DataBind();
                    }
                }

                selectStudentList_SelectedIndexChanged(sender, e);
            }
        }

        DataTable dt = new DataTable();

        protected void selectStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentName = "";
            string studentLocation = "";
            DateTime time = new DateTime();

            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                var query = "SELECT CONCAT(FirstName, ' ', LastName) AS FullName, Location, Time FROM students WHERE UID = " + selectStudentList.SelectedValue;

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentName = reader[0].ToString();
                            studentLocation = reader[1].ToString();
                            time = Utils.UnixTimeStampToDateTime(Convert.ToDouble(reader[2].ToString()));
                        }
                    }
                }
            }

            dt.Clear();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Student Name", typeof(string));
                dt.Columns.Add("Student Location", typeof(string));
                dt.Columns.Add("Check-In Time", typeof(string));
            }

            DataRow NewRow = dt.NewRow();
            NewRow[0] = studentName;
            NewRow[1] = studentLocation;
            NewRow[2] = time.ToString("dd/MM/yyyy hh:mm:ss tt");
            dt.Rows.Add(NewRow);
            StudentGrid.DataSource = dt;
            StudentGrid.DataBind();
        }
    }
}