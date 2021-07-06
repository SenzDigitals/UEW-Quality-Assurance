using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEW_Quality_Assurance.Models;

namespace UEW_Quality_Assurance.Data
{
    public class GetData
    {

        public List<Student> getStudent(string id)
        {
            //Retrieve student list from database
            var connectionString = "server = localhost; port = 3306; database = UEW_QUALITY_ASSURANCE; user = root; password = ";
            //var students = new StudentViewModel();
            List<Student> students = new List<Student>();
            Prog program = new Prog();

            var query = "SELECT * FROM student JOIN program ON student.programID=program.programID WHERE studentID='" + id +"'";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    con.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student stu = new Student();
                        


                        stu.studentID = Convert.ToString(reader["studentID"]);
                        stu.lname = Convert.ToString(reader["lname"]);
                        stu.fname = Convert.ToString(reader["fname"]);

                        //program.name = Convert.ToString(reader["name"]);


                        students.Add(stu);
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
                      

            return students;
        }

       
        //Retrieve enrollment list from database
        public List<Enrollment> getEnrollment(string id)
        {
            var connectionString = "server = localhost; port = 3306; database = UEW_QUALITY_ASSURANCE; user = root; password = ";
            //var students = new StudentViewModel();
            List<Course> courses = new List<Course>();
            List<Enrollment> enrollments = new List<Enrollment>();

            var query = "Select * from enrollment  WHERE studentID='" + id + "'";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    con.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Enrollment enrollment = new Enrollment();
                        Course course = new Course();


                        enrollment.courseID = Convert.ToString(reader["courseID"]);


                        enrollments.Add(enrollment);
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return enrollments;
        }

        //Get courseID from enrollment and pass to getCourse method
        

        //Get all courses enrolled by student
        public List<Course> getCourse()
        {
            var connectionString = "server = localhost; port = 3306; database = UEW_QUALITY_ASSURANCE; user = root; password = ";
            //var students = new StudentViewModel();
            List<Course> courses = new List<Course>();

            var query = "Select title from course";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    con.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Course course = new Course();



                        course.courseID = Convert.ToString(reader["courseID"]);
                        course.title = Convert.ToString(reader["title"]);

                        courses.Add(course);
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return courses;
        }
    }
}
