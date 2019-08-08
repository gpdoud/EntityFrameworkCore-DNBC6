using EntityFrameworkCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreProject {
    class Program {
        static void ScheduleInit() {
            // create an instance of the context
            var context = new AppDbContext();
            // get the student
            var student = context.Students.SingleOrDefault(s => s.Lastname == "Rogers");
            // get the courses
            var courses = context.Courses.Where(c => c.Name.Contains("103")).ToArray();
            // schedule the student for all the courses
            foreach(var course in courses) {
                var schedule = new Schedule {
                    StudentId = student.Id, CourseId = course.Id, Grade = -1
                };
                context.Schedules.Add(schedule);
            }
            // save to the database
            context.SaveChanges();
        }
        static void CourseInit() {
            // create an instance of the context
            var context = new AppDbContext();
            //
            // these courses are for the Math major
            //
            // get the major
            var mathMajor = context.Majors.SingleOrDefault(m => m.Description.Contains("Math"));
            // create the courses
            var math101 = new Course {
                Name = "Math 101",
                Instructor = "Beene Kownter",
                Credits = 5,
                MajorId = mathMajor.Id
            };
            context.Courses.Add(math101);
            var math102 = new Course {
                Name = "Math 102",
                Instructor = "Beene Kownter",
                Credits = 5,
                MajorId = mathMajor.Id
            };
            context.Courses.Add(math102);
            var math103 = new Course {
                Name = "Math 103",
                Instructor = "Beene Kownter",
                Credits = 5,
                MajorId = mathMajor.Id
            };
            context.Courses.Add(math103);
            //
            // these courses are for the CS major
            //  
            // get the major
            var csMajor = context.Majors.SingleOrDefault(m => m.Description.Contains("Computer"));
            // create the courses
            var cs101 = new Course {
                Name = "CS 101",
                Instructor = "Tot Algeek",
                Credits = 3,
                MajorId = csMajor.Id
            };
            context.Courses.Add(cs101);
            var cs102 = new Course {
                Name = "CS 102",
                Instructor = "Tot Algeek",
                Credits = 3,
                MajorId = csMajor.Id
            };
            context.Courses.Add(cs102);
            var cs103 = new Course {
                Name = "CS 103",
                Instructor = "Tot Algeek",
                Credits = 3,
                MajorId = csMajor.Id
            };
            context.Courses.Add(cs103);
            // finally save all the changes (don't forget this!)
            context.SaveChanges();
        }
        static void Run() { 
            #region Join
            //var db = new AppDbContext();
            //var studentsForMajor = db.Majors
            //                            .Join(db.Students,
            //                                m => m.Id,
            //                                s => s.MajorId,
            //                                (m, s) => new { m.Description, s.Firstname, s.Lastname });
            ////var studentsForMajor = from m in db.Majors
            ////                       join s in db.Students
            ////                        on m.Id equals s.MajorId
            ////                       select new { m.Description, s.Firstname, s.Lastname };
            //foreach(var m in studentsForMajor) {
            //    Console.WriteLine(m.Description + "=>" + m.Firstname + " " + m.Lastname);
            //}
            //return;


            #endregion

            //var context = new AppDbContext();

            // var nursing = new Major { Id = 0, Description = "Nursing", MinSat = 1100 };
            // var accounting = new Major { Id = 0, Description = "Accounting", MinSat = 1300 };
            // var publicSpeaking = new Major { Id = 0, Description = "Pubic Speaking", MinSat = 5 };
            // var golf = new Major { Id = 0, Description = "Golf Science", MinSat = 1400 };
            // var esports = new Major { Id = 0, Description = "eSports", MinSat = 800 };
            // var socialogy = new Major { Id = 0, Description = "Socialogy", MinSat = 800 };
            // var history = new Major { Id = 0, Description = "History", MinSat = 900 };
            // var polisci = new Major { Id = 0, Description = "Political Science", MinSat = 1000 };
            // var theater = new Major { Id = 0, Description = "Theater", MinSat = 200 };
            // var cs = new Major { Id = 0, Description = "Computer Science", MinSat = 1500 };

            // var majors = new List<Major> { nursing, accounting, publicSpeaking, golf, esports,
            //                                 socialogy, history, polisci, theater, cs };

            // context.Majors.AddRange(majors);

            // context.SaveChanges();

            var context = new AppDbContext();

            var esports = context.Majors
                .SingleOrDefault(m => m.Description == "eSports");
            var pubspk = context.Majors
                .SingleOrDefault(m => m.Description == "Public Speaking");
            var theater = context.Majors
                .SingleOrDefault(m => m.Description == "Theater");
            var golfsci = context.Majors
                .SingleOrDefault(m => m.Description == "Golf Science");
            var socialogy = context.Majors
                .SingleOrDefault(m => m.Description == "Socialogy");

            var bird = new Student {
                Firstname = "J.",
                Lastname = "Bird",
                GPA = 2.8,
                SAT = 1100,
                IsFulltime = true,
                MajorId = context.Majors.SingleOrDefault(m => m.Description == "eSports").Id
            };
            context.Students.Add(bird);
            var star = new Student {
                Firstname = "P.",
                Lastname = "Star",
                GPA = 1.7,
                SAT = 650,
                IsFulltime = false,
                MajorId = pubspk.Id
            };
            context.Students.Add(star);
            var neutron = new Student {
                Firstname = "J.",
                Lastname = "Neutron",
                GPA = 5.0,
                SAT = 2400,
                IsFulltime = true,
                MajorId = theater.Id
            };
            context.Students.Add(neutron);
            var turner = new Student {
                Firstname = "T.",
                Lastname = "Turner",
                GPA = 2.5,
                SAT = 1300,
                IsFulltime = true,
                MajorId = golfsci.Id
            };
            context.Students.Add(turner);
            var rogers = new Student {
                Firstname = "S.",
                Lastname = "Rogers",
                GPA = 4.6,
                SAT = 1000,
                IsFulltime = false,
                MajorId = socialogy.Id
            };
            context.Students.Add(rogers);

            context.SaveChanges();

            //var major = context.Majors.Find(5);
            //context.Remove(major);

            //var major = context.Majors.Find(2);
            //if(major == null) {
            //    throw new Exception("Not found!");
            //}
            //major.Description = "Math";
            //major.MinSat = 1300;

            //var major = new Major();
            //major.Id = 0;
            //major.Description = "Biology";
            //major.MinSat = 1100;

            //context.Majors.Add(major);

            //context.SaveChanges();

            //foreach(var major in context.Majors.ToList()) {
            //    Console.WriteLine(major);
            //}

            //var genStudies = context.Majors.Find(1);
            //Console.WriteLine(genStudies);

            //var students = context.Students
            //    .Where(s => s.GPA >= 3.0)
            //    .OrderByDescending(s => s.Lastname)
            //    .ToArray();

            // get a list of students ordered by first name
            //var students = context.Students
            //    .OrderBy(fred => fred.Firstname)
            //    .ToList();

            //var studentAverageSat = context.Students
            //    .Average(s => s.SAT);
            //Console.WriteLine($"The average sat score is {studentAverageSat}");

            //var students = context.Students
            //                    .Where(student => student.Major != null)
            //                    .OrderBy(student => student.Major.Description)
            //                    .ToList();

            //foreach(var student in students) {
            //    //var major = (student.Major == null) 
            //    //    ? "Undeclared" 
            //    //    : student.Major.Description;
            //    Console.WriteLine(student);
            //}

        }
        static void Main(string[] args) {
            ScheduleInit();
        }
    }
}
