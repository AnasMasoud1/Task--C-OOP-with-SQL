using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public partial class Course
    {
        public void AddCourse()
        {

            Course curs = new Course();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            Console.WriteLine("Enter Course Name :");

            curs.CourseName = Convert.ToString(Console.ReadLine());

            string query = " insert into Course (Coursename) values('" + curs.CourseName + "') ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Course Added");
        }
        public void EditCourse()
        {
            Course curs = new Course();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            Console.WriteLine("Enter Course ID :");
            curs.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Course Name :");
            curs.CourseName = Convert.ToString(Console.ReadLine());

            string query = "  update Course set CourseName='" + curs.CourseName + "' where ID='" + curs.ID + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Course Updated");
        }
        public void RemoveCourse()
        {

            Course curs = new Course();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            Console.WriteLine("Enter Course ID :");

            curs.ID = Convert.ToInt32(Console.ReadLine());
            string query = " DELETE from Course where ID='" + curs.ID + "'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Course Removed");
        }



        public void DisplayCourses()
        {
            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            string query = "select * from Course ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Access columns by name or index
                        string column1Value = reader["ID"].ToString();
                        string column2Value = reader["CourseName"].ToString();

                        // Display the retrieved data
                        string outputString = $"Course ID: {column1Value}, Course Name: {column2Value}";
                        Console.WriteLine(outputString);

                        // Append to text file
                        string inputFileName = @"C:\courses\coursesFi.txt";
                        using (StreamWriter writer = File.AppendText(inputFileName))
                        {
                            writer.WriteLine(outputString);
                        }
                    }
                }
            }

            Console.WriteLine("Data displayed in file");
        }
    }
}
