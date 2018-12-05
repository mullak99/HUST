using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniWebsite
{
    public class SQL_Methods
    {
        #region Student SQL Methods
        public static bool DoesStudentExist(string FirstName, string LastName)
        {
            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(1) FROM students WHERE FirstName = @firstname AND LastName = @lastname", connection))
                {
                    connection.Open();
                    sqlCommand.Parameters.AddWithValue("@firstname", FirstName);
                    sqlCommand.Parameters.AddWithValue("@lastname", LastName);

                    Object o = sqlCommand.ExecuteScalar();
                    int userCount = Convert.ToInt32(o);

                    if (userCount > 0)
                        return true;

                    return false;
                }
            }
        }

        public static bool DoesStudentExist(int UID)
        {
            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(1) FROM students WHERE UID = @uid", connection))
                {
                    connection.Open();
                    sqlCommand.Parameters.AddWithValue("@uid", UID);

                    Object o = sqlCommand.ExecuteScalar();
                    int userCount = Convert.ToInt32(o);

                    if (userCount > 0)
                        return true;

                    return false;
                }
            }
        }

        public static Student GetStudent(string StudentFullName)
        {
            try
            {
                string firstName = StudentFullName.Substring(0, StudentFullName.IndexOf(" "));
                string lastName = StudentFullName.Substring(StudentFullName.IndexOf(" ") + 1);

                using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
                {
                    var query = "SELECT UID, FirstName, LastName FROM students WHERE FirstName = @firstName AND LastName = @lastName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Student(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), GetCurrentStudentLocation(Convert.ToInt32(reader[0].ToString())));
                            }
                        }
                    }
                }
                throw new Exception();
            }
            catch
            {
                throw new Exception("Student Not Found");
            }
        }

        public static Student GetStudent(int UID)
        {
            try
            {
                using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
                {
                    var query = "SELECT UID, FirstName, LastName FROM students WHERE UID = @uid";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@uid", UID);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Student(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), GetCurrentStudentLocation(Convert.ToInt32(reader[0].ToString())));
                            }
                        }
                    }
                }
                return null;
            }
            catch
            {
                throw new Exception("SQL DB Error");
            }
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> allStudents = new List<Student>();

            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                var query = "SELECT UID, FirstName, LastName FROM students";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allStudents.Add(new Student(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), GetCurrentStudentLocation(Convert.ToInt32(reader[0].ToString()))));
                        }
                    }
                }
            }
            return allStudents;
        }

        public static void AddStudent(string FirstName, string LastName)
        {
            if (!DoesStudentExist(FirstName, LastName))
            {
                using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
                {

                    var query = "INSERT INTO students (LastName, FirstName) VALUES (@lastName, @firstName)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@lastName", Utils.UppercaseFirst(Utils.SqlEscape(LastName)));
                        command.Parameters.AddWithValue("@firstName", Utils.UppercaseFirst(Utils.SqlEscape(FirstName)));
                        command.ExecuteNonQuery();
                    }

                }
            }
        }

        public static void EditStudent(int UID, string FirstName, string LastName)
        {
            if (!DoesStudentExist(FirstName, LastName))
            {
                using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
                {
                    var query = "UPDATE students SET FirstName = @firstName, LastName = @lastName WHERE students.UID = @uid";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@lastName", Utils.UppercaseFirst(Utils.SqlEscape(LastName)));
                        command.Parameters.AddWithValue("@firstName", Utils.UppercaseFirst(Utils.SqlEscape(FirstName)));
                        command.Parameters.AddWithValue("@uid", UID);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void DeleteStudent(int UID)
        {
            if (DoesStudentExist(UID))
            {
                using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
                {
                    var query = "DELETE FROM students WHERE UID = @uid";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@uid", UID);
                        command.ExecuteNonQuery();
                    }

                    var query2 = "DELETE FROM locations WHERE CheckInUID = @uid";

                    using (MySqlCommand command = new MySqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@uid", UID);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static List<Student> GetStudentsAtLocation(string location)
        {
            List<Student> allStudents = GetAllStudents();
            List<Location> allLocations = new List<Location>();
            List<Student> studentsAtLocation = new List<Student>();

            foreach (Student student in allStudents)
            {
                Location loc = GetCurrentStudentLocation(student.UID);

                try
                {
                    if (loc.getLocation().ToLower() == location.ToLower())
                        studentsAtLocation.Add(student);
                }
                catch
                { }
            }
            return studentsAtLocation;
        }

        #endregion

        #region Location SQL Methods

        public static Location GetCurrentStudentLocation(int studentUID)
        {
            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                var query = "SELECT UID, Location, Time FROM locations WHERE CheckInUID = @uid ORDER BY UID DESC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@uid", studentUID.ToString());

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Location(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), Utils.UnixTimeStampToDateTime(Convert.ToDouble(reader[2].ToString())));
                        }
                    }
                }
            }
            return null;
        }

        public static Location GetCurrentStudentLocation(string fullName)
        {
            return GetCurrentStudentLocation(GetStudent(fullName).UID);
        }

        public static void SetStudentCurrentLocation(int studentUID, string location)
        {
            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                var query = "INSERT INTO locations (Location, Time, CheckInUID) VALUES (@location, @time, @studentUID)";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@location", Utils.UppercaseFirst(Utils.SqlEscape(location)));
                    command.Parameters.AddWithValue("@time", Utils.CurrentUnixTimestamp());
                    command.Parameters.AddWithValue("@studentUID", studentUID.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Location> GetStudentsLocationHistory(int studentUID)
        {
            List<Location> allLocations = new List<Location>();

            using (var connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["sqlDbConnectionString"].ConnectionString))
            {
                var query = "SELECT UID, Location, Time FROM locations WHERE CheckInUID = @uid ORDER BY UID DESC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@uid", studentUID.ToString());

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allLocations.Add(new Location(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), Utils.UnixTimeStampToDateTime(Convert.ToDouble(reader[2].ToString()))));
                        }
                    }
                }
            }
            return allLocations;
        }

        #endregion
    }
}