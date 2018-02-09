using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_051_StdntCoursesChallenge_final
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            //var courses = new List<Course>()
            List<Course> courses = new List<course>()
            {
                new Course
                { CourseId = 101, Name="Claw Sharpening", Students = new List<Student>()  {
                        new Student() { StudentId = 1010, Name = "Mittens" },
                        new Student() { StudentId = 1011, Name = "Fluffy" }               }
                },

                new Course
                { CourseId = 101, Name="Catnip Tasting", Students = new List<Student>()  {
                        new Student() { StudentId = 1012, Name = "Boots" },
                        new Student() { StudentId = 1014, Name = "Kitty-Girl" }               }
                },

                new Course
                { CourseId = 101, Name="Quality Naps", Students = new List<Student>()  {
                        new Student() { StudentId = 1015, Name = "Tom" },
                        new Student() { StudentId = 1016, Name = "Bob" }               }
                }
            };

            foreach (var course in courses)
            {
                result += string.Format("<br/><br/><b>Course: {0}</b> ({1})", course.Name, course.CourseId);
                foreach (var student in course.Students)
                {
                    result += string.Format("<br/>&nbsp;&nbsp;Student: {0} ({1})", student.Name, student.StudentId);
                }
            }

            resultLabel.Text = result;

        }




        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */


        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
            * We need to keep track of each Student's grade (0 to 100) in a 
            * particular Course.  This means at a minimum, you'll need to add 
            * another class, and depending on your implementation, you will 
            * probably need to modify the existing classes to accommodate this 
            * new requirement.  Give each Student a grade in each Course they
            * are enrolled in (make up the data).  Then, for each student, 
            * print out each Course they are enrolled in and their grade.
            */



        }
    }
}