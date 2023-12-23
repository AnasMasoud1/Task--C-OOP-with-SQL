using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject
{
    public partial class Score
    {
        public void DisplayAverageScoreByCourse()
        {
            Score score = new Score();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();
            using (SqlCommand command = new SqlCommand("GetAverageScoreByCourse", conn))
            {
                command.CommandType = CommandType.StoredProcedure; // Specify that it's a stored procedure
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Access columns by name or index
                        string column1Value = reader["CourseID"].ToString();
                        string column2Value = reader["AverageScore"].ToString();

                        // Display the retrieved data
                        Console.WriteLine($"Course ID: {column1Value}, Average Score: {column2Value}");
                        Console.WriteLine();
                    }
                }
            }
        }


        public void EditScore()
        {
            Score score = new Score();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            Console.WriteLine("Enter Score ID :");
            score.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Course ID :");
            score.CourseID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student ID :");
            score.StudentID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Score :");
            score.Score1 = Convert.ToInt32(Console.ReadLine());
            //string query = " update Score set Score='" + score.Score1 + "' where ID='" + score.ID + "' ";
            string query = " update Score set Score='" + score.Score1 + "' where StudentID='" + score.StudentID + "' AND CourseID='" + score.CourseID + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Score Updated");
        }
        public void RemoveScore()
        {
            Score score = new Score();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            Console.WriteLine("Enter Score ID :");
            score.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Course ID :");
            score.CourseID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student ID :");
            score.StudentID = Convert.ToInt32(Console.ReadLine());
            string query = " DELETE from Score where StudentID='" + score.StudentID + "' AND CourseID='" + score.CourseID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Score Removed");
        }

        public void DisplayScores()
        {
            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";

            conn = new SqlConnection(str);
            conn.Open();

            string query = "select * from Score ";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Access columns by name or index
                        string column1Value = reader["ID"].ToString();
                        string column2Value = reader["CourseID"].ToString();
                        string column3Value = reader["StudentID"].ToString();
                        string column4Value = reader["Score"].ToString();

                        // Display the retrieved data
                        string outputString = $"Score ID: {column1Value}, Course ID: {column2Value}, Student ID: {column3Value}, Score : {column4Value}";
                        Console.WriteLine(outputString);

                        // Append to text file
                        string inputFileName = @"C:\courses\ScoreFi.txt";
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
