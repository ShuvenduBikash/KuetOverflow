﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KuetOverflow.Models;

namespace KuetOverflow.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Shuvendu",   LastName = "Roy",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Tushar", LastName = "Pranto",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Mehedi",   LastName = "Hasan",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Tawhid",    LastName = "Jwader",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "AbuSaleh",      LastName = "Asif",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Dibbendu",    LastName = "Sapto",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Arapn",    LastName = "Bhoumic",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Monoarul",     LastName = "Amit",
                    EnrollmentDate = DateTime.Parse("2015-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("2015-03-11") },
                new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2015-07-06") },
                new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("2016-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2016-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2014-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "CSE",     Budget = 350000,
                    StartDate = DateTime.Parse("2015-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "EEE", Budget = 100000,
                    StartDate = DateTime.Parse("2015-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "ECE", Budget = 350000,
                    StartDate = DateTime.Parse("2015-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "IEM",   Budget = 100000,
                    StartDate = DateTime.Parse("2015-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseNo = "1050", Title = "Web Lab",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "ECE").DepartmentID
                },
                new Course {CourseNo = "4022", Title = "Database", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "IEM").DepartmentID
                },
                new Course {CourseNo = "4041", Title = "Database", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "IEM").DepartmentID
                },
                new Course {CourseNo = "1045", Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "EEE").DepartmentID
                },
                new Course {CourseNo = "3141", Title = "Theory of computation",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "EEE").DepartmentID
                },
                new Course {CourseNo = "2021", Title = "Machine Learning",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "CSE").DepartmentID
                },
                new Course {CourseNo = "2042", Title = "Artificial Intelligence",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "CSE").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Object oriented Programming" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Web Lab" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Database" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Networking" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Artificial Intelligence" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Theory of computation" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Machine Learning" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Artificial Intelligence" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Roy").ID,
                    CourseID = courses.Single(c => c.Title == "Web Lab" ).CourseID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Roy").ID,
                    CourseID = courses.Single(c => c.Title == "Database" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Roy").ID,
                    CourseID = courses.Single(c => c.Title == "Database" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Pranto").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Pranto").ID,
                    CourseID = courses.Single(c => c.Title == "Theory of computation" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Pranto").ID,
                    CourseID = courses.Single(c => c.Title == "Machine Learning" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Hasan").ID,
                    CourseID = courses.Single(c => c.Title == "Web Lab" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Hasan").ID,
                    CourseID = courses.Single(c => c.Title == "Database").CourseID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Jwader").ID,
                    CourseID = courses.Single(c => c.Title == "Web Lab").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Asif").ID,
                    CourseID = courses.Single(c => c.Title == "Machine Learning").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Sapto").ID,
                    CourseID = courses.Single(c => c.Title == "Artificial Intelligence").CourseID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
