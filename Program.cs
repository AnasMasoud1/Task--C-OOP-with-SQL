using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//````
namespace OOPFinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Course course = new Course();
            Score score = new Score();
            Admin admin = new Admin();

            SqlConnection conn;
            string str = "Data Source=DESKTOP-L03VO9L\\SQLEXPRESS;Initial Catalog=MenuStd;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection(str);

            conn.Open();

            string query = " SELECT * from Admin  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string column3Value = reader["Password"].ToString();

                        do
                        {
                            Console.Clear();
                            int sqlpass = Convert.ToInt32(admin.Password);
                            Console.WriteLine("******** Login Menu ********");
                            Console.WriteLine();
                            Console.WriteLine("Please Enter Username :");
                            admin.Username = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Please Enter Password :");
                            admin.Password = Console.ReadLine();
                        }
                        while (column3Value != admin.Password);

                        Console.Clear();
                        Console.WriteLine($"Hello {admin.Username}!");
                        int MenuSelector;
                        do
                        {
                            Console.WriteLine("[1]    Student Menu :");
                            Console.WriteLine("[2]    Course Menu :");
                            Console.WriteLine("[3]    Score Menu :");
                            Console.WriteLine("[0]    Exit.");
                            Console.WriteLine("Please Select Menu :");
                            MenuSelector = Convert.ToInt32(Console.ReadLine());
                            switch (MenuSelector)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine($"Hello {admin.Username}!");
                                    int MenuSelector2;
                                    do
                                    {
                                        Console.WriteLine("[1]    Add New Student :");
                                        Console.WriteLine("[2]    Remove a Student :");
                                        Console.WriteLine("[3]    Edit Student information :");
                                        Console.WriteLine("[4]    Information for All Student :");
                                        Console.WriteLine("[5]    Search a Student by ID :");
                                        Console.WriteLine("[6]    Display statics Student :");
                                        Console.WriteLine("[0]    Exit.");
                                        Console.WriteLine("Please Select Operation :");
                                        MenuSelector2 = Convert.ToInt32(Console.ReadLine());

                                        switch (MenuSelector2)
                                        {
                                            case 1: student.AddStudent(); break;
                                            case 2: student.RemoveStudent(); break;
                                            case 3: student.EditStudent(); break;
                                            case 4: student.DisplayStudent(); break;
                                            case 5: student.SearchStudentByID(); break;
                                            case 6: student.GetStaticStudent(); ; break;
                                        }
                                    } while (MenuSelector2 != 0);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine($"Hello {admin.Username}!");
                                    int MenuSelector3;
                                    do
                                    {
                                        Console.WriteLine("[1]    Add New Course :");
                                        Console.WriteLine("[2]    Remove Course :");
                                        Console.WriteLine("[3]    Edit Course information :");
                                        Console.WriteLine("[4]    Print All Courses in file :");
                                        Console.WriteLine("[0]    Exit.");
                                        Console.WriteLine("Please Select Operation :");
                                        MenuSelector3 = Convert.ToInt32(Console.ReadLine());

                                        switch (MenuSelector3)
                                        {
                                            case 1: course.AddCourse(); break;
                                            case 2: course.RemoveCourse(); break;
                                            case 3: course.EditCourse(); break;
                                            case 4: course.DisplayCourses(); break;
                                        }
                                    } while (MenuSelector3 != 0);
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine($"Hello {admin.Username}!");
                                    int MenuSelector4;
                                    do
                                    {
                                        Console.WriteLine("[1]    Display score Average for Course :");
                                        Console.WriteLine("[2]    Print scores in file: :");
                                        Console.WriteLine("[3]    Remove Score :");
                                        Console.WriteLine("[4]    Manage the student scores :");
                                        Console.WriteLine("[0]    Exit.");
                                        Console.WriteLine("Please Select Operation :");
                                        MenuSelector4 = Convert.ToInt32(Console.ReadLine());

                                        switch (MenuSelector4)
                                        {
                                            case 1: score.DisplayAverageScoreByCourse(); break;
                                            case 2: score.DisplayScores(); break;
                                            case 3: score.RemoveScore(); break;
                                            case 4: score.EditScore(); break;
                                        }
                                    } while (MenuSelector4 != 0);
                                    break;
                            }
                        } while (MenuSelector != 0);
                    }
                }
            }
        }

    }
}
