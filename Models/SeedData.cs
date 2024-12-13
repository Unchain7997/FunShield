using FunShield.Models;
using Microsoft.EntityFrameworkCore;

namespace FunShield.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new FunShieldDbContext(serviceProvider.GetRequiredService<DbContextOptions<FunShieldDbContext>>());

            if (context.Sessions?.Any() == true || context.Students?.Any() == true)
            {
                return;
            }

            var courses = new List<Course>
            {
                new Course { Title = "STEM Innovators", Language = "English", Description = "Hands-on science and technology projects." },
                new Course { Title = "STEM Innovators", Language = "Spanish", Description = "Hands-on science and technology projects." },
                new Course { Title = "Creative Crafts", Language = "English", Description = "Artistic activities for skill building." },
                new Course { Title = "Creative Crafts", Language = "Spanish", Description = "Artistic activities for skill building." },
                new Course { Title = "Little Chefs Club", Language = "English", Description = "Basic cooking lessons." },
                new Course { Title = "Little Chefs Club", Language = "Spanish", Description = "Basic cooking lessons." }
            };
            context.Courses!.AddRange(courses);
            context.SaveChanges();

            var sessions = new List<Session>();
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Where(d => d != DayOfWeek.Saturday && d != DayOfWeek.Sunday))
            {
                sessions.Add(new Session
                {
                    SessionType = "A",
                    DayOfWeek = day,
                    StartTime = new TimeSpan(15, 30, 0),
                    EndTime = new TimeSpan(16, 25, 0),
                    Language = "English",
                    CourseID = courses.First(c => c.Title == "STEM Innovators" && c.Language == "English").CourseID
                });

                sessions.Add(new Session
                {
                    SessionType = "A",
                    DayOfWeek = day,
                    StartTime = new TimeSpan(15, 30, 0),
                    EndTime = new TimeSpan(16, 25, 0),
                    Language = "Spanish",
                    CourseID = courses.First(c => c.Title == "STEM Innovators" && c.Language == "Spanish").CourseID
                });

                sessions.Add(new Session
                {
                    SessionType = "B",
                    DayOfWeek = day,
                    StartTime = new TimeSpan(16, 30, 0),
                    EndTime = new TimeSpan(17, 25, 0),
                    Language = "English",
                    CourseID = courses.First(c => c.Title == "Creative Crafts" && c.Language == "English").CourseID
                });

                sessions.Add(new Session
                {
                    SessionType = "B",
                    DayOfWeek = day,
                    StartTime = new TimeSpan(16, 30, 0),
                    EndTime = new TimeSpan(17, 25, 0),
                    Language = "Spanish",
                    CourseID = courses.First(c => c.Title == "Creative Crafts" && c.Language == "Spanish").CourseID
                });

                sessions.Add(new Session
                {
                    SessionType = "C",
                    DayOfWeek = day,
                    StartTime = new TimeSpan(17, 30, 0),
                    EndTime = new TimeSpan(18, 15, 0),
                    Language = "English",
                    CourseID = courses.First(c => c.Title == "Little Chefs Club" && c.Language == "English").CourseID
                });

                sessions.Add(new Session
                {
                    SessionType = "C",
                    DayOfWeek = day,
                    StartTime = new TimeSpan(17, 30, 0),
                    EndTime = new TimeSpan(18, 15, 0),
                    Language = "Spanish",
                    CourseID = courses.First(c => c.Title == "Little Chefs Club" && c.Language == "Spanish").CourseID
                });
            }

            foreach (var session in sessions)
            {
                session.GenerateSessionID();
            }
            context.Sessions!.AddRange(sessions);
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student { FirstName = "Toni", LastName = "Bean", Age = 7, Grade = 4, EnrollmentHistory = "New Student", SessionID = sessions[0].SessionID },
                new Student { FirstName = "Maria", LastName = "Lopez", Age = 8, Grade = 5, EnrollmentHistory = "Returning", SessionID = sessions[1].SessionID },
                new Student { FirstName = "Liam", LastName = "Smith", Age = 9, Grade = 3, EnrollmentHistory = "New Student", SessionID = sessions[2].SessionID },
                new Student { FirstName = "Sophia", LastName = "Johnson", Age = 10, Grade = 4, EnrollmentHistory = "Returning", SessionID = sessions[3].SessionID },
                new Student { FirstName = "Jacob", LastName = "Williams", Age = 6, Grade = 1, EnrollmentHistory = "New Student", SessionID = sessions[4].SessionID },
                new Student { FirstName = "Ella", LastName = "Brown", Age = 7, Grade = 3, EnrollmentHistory = "Returning", SessionID = sessions[5].SessionID },
                new Student { FirstName = "Noah", LastName = "Davis", Age = 8, Grade = 4, EnrollmentHistory = "New Student", SessionID = sessions[6].SessionID },
                new Student { FirstName = "Emma", LastName = "Martinez", Age = 9, Grade = 5, EnrollmentHistory = "Returning", SessionID = sessions[7].SessionID },
                new Student { FirstName = "Oliver", LastName = "Garcia", Age = 6, Grade = 2, EnrollmentHistory = "New Student", SessionID = sessions[8].SessionID },
                new Student { FirstName = "Charlotte", LastName = "Rodriguez", Age = 7, Grade = 3, EnrollmentHistory = "Returning", SessionID = sessions[9].SessionID },
                new Student { FirstName = "James", LastName = "Hernandez", Age = 8, Grade = 4, EnrollmentHistory = "New Student", SessionID = sessions[10].SessionID },
                new Student { FirstName = "Isabella", LastName = "Moore", Age = 9, Grade = 5, EnrollmentHistory = "Returning", SessionID = sessions[11].SessionID },
                new Student { FirstName = "Lucas", LastName = "Taylor", Age = 7, Grade = 3, EnrollmentHistory = "New Student", SessionID = sessions[12].SessionID },
                new Student { FirstName = "Mia", LastName = "Thomas", Age = 6, Grade = 2, EnrollmentHistory = "Returning", SessionID = sessions[13].SessionID },
                new Student { FirstName = "Henry", LastName = "White", Age = 8, Grade = 4, EnrollmentHistory = "New Student", SessionID = sessions[14].SessionID },
                new Student { FirstName = "Amelia", LastName = "Harris", Age = 9, Grade = 5, EnrollmentHistory = "Returning", SessionID = sessions[15].SessionID },
                new Student { FirstName = "Sebastian", LastName = "Martin", Age = 6, Grade = 2, EnrollmentHistory = "New Student", SessionID = sessions[16].SessionID },
                new Student { FirstName = "Harper", LastName = "Clark", Age = 7, Grade = 3, EnrollmentHistory = "Returning", SessionID = sessions[17].SessionID },
                new Student { FirstName = "Evelyn", LastName = "Lewis", Age = 8, Grade = 4, EnrollmentHistory = "New Student", SessionID = sessions[18].SessionID },
                new Student { FirstName = "Avery", LastName = "Robinson", Age = 9, Grade = 5, EnrollmentHistory = "Returning", SessionID = sessions[19].SessionID },
                new Student { FirstName = "William", LastName = "Walker", Age = 7, Grade = 3, EnrollmentHistory = "New Student", SessionID = sessions[20].SessionID },
                new Student { FirstName = "Grace", LastName = "Young", Age = 6, Grade = 2, EnrollmentHistory = "Returning", SessionID = sessions[21].SessionID },
                new Student { FirstName = "Michael", LastName = "King", Age = 8, Grade = 4, EnrollmentHistory = "New Student", SessionID = sessions[22].SessionID },
                new Student { FirstName = "Luna", LastName = "Green", Age = 9, Grade = 5, EnrollmentHistory = "Returning", SessionID = sessions[23].SessionID },
                new Student { FirstName = "Elijah", LastName = "Adams", Age = 7, Grade = 3, EnrollmentHistory = "New Student", SessionID = sessions[24].SessionID }
            };
            context.Students!.AddRange(students);
            context.SaveChanges();
        }
    }
}