using System;
using System.Web;

namespace HUST
{
    public partial class location : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string postStudent = Request.QueryString["student"];
                string postLocation = Request.QueryString["location"];

                string firstName = postStudent.Substring(0, postStudent.IndexOf(" "));
                string lastName = postStudent.Substring(postStudent.IndexOf(" ") + 1);

                if (!String.IsNullOrEmpty(postStudent) && !String.IsNullOrEmpty(postStudent) && !String.IsNullOrWhiteSpace(postLocation) && !String.IsNullOrWhiteSpace(postLocation))
                {
                    if (!SQL_Methods.DoesStudentExist(firstName, lastName))
                        SQL_Methods.AddStudent(firstName, lastName);

                    SQL_Methods.SetStudentCurrentLocation(SQL_Methods.GetStudent(postStudent).UID, Utils.UppercaseFirst(Utils.SqlEscape(postLocation)));
                }
            }
            else if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                string get = Request.QueryString["student"];

                try
                {
                    Location location = SQL_Methods.GetCurrentStudentLocation(Utils.SqlEscape(get).Replace("\"", string.Empty));
                    Response.Write(location.CheckInLocation);
                }
                catch
                { }
                Response.End();
            }
        }
    }
}