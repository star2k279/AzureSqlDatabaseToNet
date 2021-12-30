using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AzureSqlDatabaseToNet.Models;

namespace AzureSqlDatabaseToNet.Services
{
    public class CourseService
    {
        public SqlConnection GetConnection(string connectionString)
        {
           
            return new SqlConnection(connectionString);
        }

        public IEnumerable<Course> GetCourses(string connectionString)
        {
            string query = "Select CourseId, CourseName, Ratings from courses";
            List<Course> _lstCources = new List<Course>();

            SqlConnection _conn = GetConnection(connectionString);
            _conn.Open();
            SqlCommand _cmd = new SqlCommand(query, _conn);

            using (SqlDataReader _reader = _cmd.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course obj = new Course()
                    {

                        CourseId = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };
                    _lstCources.Add(obj);
                }

            }
            _conn.Close();
            return _lstCources;
        }
    }
}
