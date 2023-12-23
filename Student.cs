using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public partial class Student
    {
        public void StdMenu()
        {

        }

        public void AddStudent()
        {

            Student std = new Student();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();
            Console.WriteLine("Enter First Name :");
            std.FirstName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Last Name :");
            std.LastName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Email :");
            std.Email = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Gemder :");
            std.Gender = Convert.ToString(Console.ReadLine());
            string query = " insert into Student (FirstName,LastName,Email,Gender) values('" + std.FirstName + "','" + std.LastName + "','" + std.Email + "','" + std.Gender + "') ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Student Added");
        }
        public void EditStudent()
        {

            Student std = new Student();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();
            Console.WriteLine("Enter Student ID :");
            std.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First Name :");
            std.FirstName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Last Name :");
            std.LastName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Email :");
            std.Email = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Gemder :");
            std.Gender = Convert.ToString(Console.ReadLine());
            string query = " update Student set FirstName='" + std.FirstName + "' where ID='" + std.ID + "' ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Student information updated");
        }
        public void RemoveStudent()
        {

            Student std = new Student();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();
            Console.WriteLine("Enter Student ID :");
            std.ID = Convert.ToInt32(Console.ReadLine());
            string query = " DELETE FROM Student where ID='" + std.ID + "' ";

           SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Student Removed");
        }

        public void DisplayStudent()
        {

            Student std = new Student();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            string query = "select * from Student ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string column1Value = reader["ID"].ToString();
                        string column2Value = reader["FirstName"].ToString();
                        string column3Value = reader["LastName"].ToString();
                        string column4Value = reader["Email"].ToString();
                        string column5Value = reader["Gender"].ToString();

                     
                        Console.WriteLine($"Stuent ID: {column1Value}\nName: {column2Value} {column3Value}, Email:{column4Value}, Gender:{column5Value}");
                    }
                }
            }
        }
        public void SearchStudentByID()
        {

            Student std = new Student();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();
            Console.WriteLine("Enter Student ID :");
            std.ID = Convert.ToInt32(Console.ReadLine());
            //string query = " select * from Student where ID= '" + std.ID + "' ";
            //string query = " select (ID,FirstName,LastName,Email,Gender) from Student where ID= '" + std.ID + "' ";
            string query = "SELECT ID, FirstName, LastName, Email, Gender FROM Student WHERE ID = '" + std.ID + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@StudentID", std.ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Student Details:");
                        while (reader.Read())
                        {
                            string column1Value = reader["ID"].ToString();
                            string column2Value = reader["FirstName"].ToString();
                            string column3Value = reader["LastName"].ToString();
                            string column4Value = reader["Email"].ToString();
                            string column5Value = reader["Gender"].ToString();

                            Console.WriteLine($"ID: {column1Value},\n Name: {column2Value} {column3Value}, Email: {column4Value}, Gender: {column5Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found for the given Student ID.");
                    }
                }
            }

            conn.Close();
        }

        public void GetStaticStudent()
        {
            Student std = new Student();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();
            using (SqlCommand command = new SqlCommand("GetStaticStudent", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string column1Value = reader["Gender"].ToString();
                        string column2Value = reader["GenderCount"].ToString();


                        Console.WriteLine($"Gender {column1Value}: {column2Value}");
                    }
                }
            }
        }

    }
}
