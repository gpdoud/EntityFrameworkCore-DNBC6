using EntityFrameworkCoreProject.Models;
using System;
using System.Linq;

namespace EntityFrameworkCoreProject {
    class Program {
        static void Main(string[] args) {

            var context = new AppDbContext();

            //var students = context.Students
            //    .Where(s => s.GPA >= 3.0)
            //    .OrderByDescending(s => s.Lastname)
            //    .ToArray();

            // get a list of students ordered by first name
            //var students = context.Students
            //    .OrderBy(fred => fred.Firstname)
            //    .ToList();

            var studentAverageSat = context.Students
                .Average(s => s.SAT);

            Console.WriteLine($"The average sat score is {studentAverageSat}");
                

            //foreach(var student in students) {
            //    Console.WriteLine($"{student.Firstname} {student.Lastname}");
            //}

        }
    }
}
