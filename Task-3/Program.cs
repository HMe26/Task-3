using System;
using System.Collections.Generic;
namespace StudentManagement
{
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
        public Student()
        {
            Courses = new List<Course>();
        }
        public bool Enroll(Course course)
        {
            if (course != null)
            {
                Courses.Add(course);
                return true;
            }
            return false;
        }
        public string PrintDetails()
        {
            string text = "";

            for (int i = 0; i < Courses.Count; i++)
            {
                text += Courses[i].Title + " ";
            }
            return "ID: " + StudentId + " Name: " + Name + " Age: " + Age + " Courses: " + text;
        }
    }
    class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string PrintDetails()
        {
            return "ID: " + InstructorId + " Name: " + Name + " Specialization: " + Specialization;
        }
    }
    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }
        public string PrintDetails()
        {
            string name = "No Instructor";
            if (Instructor != null)
            {
                name = Instructor.Name;
            }
            return "ID: " + CourseId + " Title: " + Title + " Instructor: " + name;
        }
    }
    class SchoolStudentManager
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }
        public SchoolStudentManager()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }
        public bool AddStudent(Student student)
        {
            Students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }
        public Student FindStudentByName(string name)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Name == name)
                {
                    return Students[i];
                }
            }
            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }
        public Course FindCourseByName(string title)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == title)
                {
                    return Courses[i];
                }
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }

            return null;
        }
        public bool UpdateStudent(int id, string n, int a)
        {
            Student st = FindStudent(id);
            if (st != null)
            {
                st.Name = n;
                st.Age = a;
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            Student st = FindStudent(id);
            if (st != null)
            {
                Students.Remove(st);
                return true;
            }
            return false;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
            {
                return student.Enroll(course);
            }

            return false;
        }
        public bool IsEnrolled(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            if (student != null)
            {
                for (int i = 0; i < student.Courses.Count; i++)
                {
                    if (student.Courses[i].CourseId == courseId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string GetInstructorByCourse(string courseName)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == courseName)
                {
                    if (Courses[i].Instructor != null)
                    {
                        return Courses[i].Instructor.Name;
                    }
                }
            }
            return "Not Found";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SchoolStudentManager manager = new SchoolStudentManager();
            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Fine the course by id or name");
                Console.WriteLine("10. Exit");
                Console.WriteLine("11. Check if the student enrolled in specific course");
                Console.WriteLine("12 Return the instructor name by course name");
                Console.WriteLine("13. Update Student Information");
                Console.WriteLine("14. Delete a Student");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Student s = new Student();
                    Console.Write("Enter ID: ");
                    s.StudentId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    s.Name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    s.Age = Convert.ToInt32(Console.ReadLine());
                    manager.AddStudent(s);
                    Console.WriteLine("Student Added");
                }
                else if (choice == 2)
                {
                    Instructor i = new Instructor();
                    Console.Write("Enter ID: ");
                    i.InstructorId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    i.Name = Console.ReadLine();
                    Console.Write("Enter Specialization: ");
                    i.Specialization = Console.ReadLine();
                    manager.AddInstructor(i);
                    Console.WriteLine("Instructor Added");
                }
                else if (choice == 3)
                {
                    Course c = new Course();
                    Console.Write("Enter Course ID: ");
                    c.CourseId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Title: ");
                    c.Title = Console.ReadLine();
                    Console.Write("Enter Instructor ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    c.Instructor = manager.FindInstructor(id);
                    if (c.Instructor != null)
                    {
                        manager.AddCourse(c);
                        Console.WriteLine("Course Added");
                    }
                    else
                    {
                        Console.WriteLine("Instructor Not Found");
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Student ID: ");
                    int sid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Course ID: ");
                    int cid = Convert.ToInt32(Console.ReadLine());
                    if (manager.EnrollStudentInCourse(sid, cid))
                    {
                        Console.WriteLine("Enrolled");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
                else if (choice == 5)
                {
                    for (int i = 0; i < manager.Students.Count; i++)
                    {
                        Console.WriteLine(manager.Students[i].PrintDetails());
                    }
                }
                else if (choice == 6)
                {
                    for (int i = 0; i < manager.Courses.Count; i++)
                    {
                        Console.WriteLine(manager.Courses[i].PrintDetails());
                    }
                }

                else if (choice == 7)
                {
                    for (int i = 0; i < manager.Instructors.Count; i++)
                    {
                        Console.WriteLine(manager.Instructors[i].PrintDetails());
                    }
                }
                else if (choice == 8)
                {
                    Console.Write("Enter Student ID or Name: ");
                    string input = Console.ReadLine();
                    int id;
                    Student student = null;
                    if (int.TryParse(input, out id))
                    {
                        student = manager.FindStudent(id);
                    }
                    else
                    {
                        student = manager.FindStudentByName(input);
                    }

                    if (student != null)
                    {
                        Console.WriteLine(student.PrintDetails());
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found");
                    }
                }
                else if (choice == 9)
                {
                    Console.Write("Enter Course ID or Title: ");
                    string input = Console.ReadLine();

                    int id;
                    Course course = null;
                    if (int.TryParse(input, out id))
                    {
                        course = manager.FindCourse(id);
                    }
                    else
                    {
                        course = manager.FindCourseByName(input);
                    }

                    if (course != null)
                    {
                        Console.WriteLine(course.PrintDetails());
                    }
                    else
                    {
                        Console.WriteLine("Course Not Found");
                    }
                }
                else if (choice == 10)
                {
                    break;
                }
                else if (choice == 11)
                {
                    Console.Write("Enter Student ID: ");
                    int sid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Course ID: ");
                    int cid = Convert.ToInt32(Console.ReadLine());
                    if (manager.IsEnrolled(sid, cid))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                }
                else if (choice == 12)
                {
                    Console.Write("Enter Course Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine(manager.GetInstructorByCourse(name));
                }
                else if (choice == 13)
                {
                    Console.Write("Enter Student ID to update: ");
                    int stdId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Age: ");
                    int newAge = Convert.ToInt32(Console.ReadLine());
                    if (manager.UpdateStudent(stdId, newName, newAge))
                    {
                        Console.WriteLine("Student Updated");
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found");
                    }
                }
                else if (choice == 14)
                {
                    Console.Write("Enter Student ID to delete: ");
                    int stdId = Convert.ToInt32(Console.ReadLine());
                    if (manager.DeleteStudent(stdId))
                    {
                        Console.WriteLine("Student Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Choice");
                }
            }
        }
    }
}