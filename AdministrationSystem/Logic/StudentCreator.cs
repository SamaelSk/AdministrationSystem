using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class StudentCreator
    {
        public void AddStudent(string email, DateTime dateOfBirth, string fullName, List<Group> groups,
            bool isActive, string phoneNumber)
        {
            Student student = new Student
            {
                Email = email,
                DateOfBirth = dateOfBirth,
                FullName = fullName,
                Groups = groups,
                IsActive = isActive,
                PaidLessons = 0,
                PhoneNumber = phoneNumber,
            };

            using (AdminContext adminContext = new AdminContext())
            {
                groups.ForEach(s => adminContext.Groups.Attach(s));
                adminContext.Students.Add(student);
                adminContext.SaveChanges();
            }
        }

        public void EditStudent(int studentId, string email, DateTime dateOfBirth, string fullName, List<Group> groups,
            bool isActive, string phoneNumber)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                groups.ForEach(s => adminContext.Groups.Attach(s));
                Student student = adminContext.Students.Include("Groups").FirstOrDefault(s => s.Id == studentId);
                student.Groups.Clear();
                student.Email = email;
                student.DateOfBirth = dateOfBirth;
                student.FullName = fullName;
                student.Groups = groups;
                student.IsActive = isActive;
                student.PhoneNumber = phoneNumber;
                adminContext.SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                Student student = adminContext.Students.FirstOrDefault(s => s.Id == studentId);
                adminContext.Students.Remove(student);
                adminContext.SaveChanges();
            }

        }

        public List<Student> GetStudentsByGroup(int id)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                return adminContext.Groups.Include("Students").FirstOrDefault(g => g.Id.Equals(id)).Students.ToList();
               // return adminContext.Students.Include("Groups").Where(s => s.Group.Id.Equals(id)).ToList();
            }
        }

        public List<Student> GetStudentsByLesson(int id)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                var lessons = adminContext.Lessons.Include("Students").Where(l => l.Id.Equals(id));
                var students = new List<Student>();
                foreach (var lesson in lessons)
                {
                    students.AddRange(lesson.Students);
                }
                return students;
            }
        }

        public List<Lesson> GetLessonsByStudent(int id, DateTime startDate, DateTime endDate)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                return adminContext.Students.Include("Lessons").FirstOrDefault(s => s.Id.Equals(id))
                                   .Lessons.Where(l => l.Date >= startDate &&
                                                       l.Date <= endDate).ToList();
            }
        }

        public List<StudentSubscription> GetStudentSubscriptionsByStudent(int id, DateTime startDate, DateTime endDate)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                return adminContext.StudentSubscriptions.Where(ss => ss.StudentId.Equals(id) &&
                                                                     ss.PurchaseDate >= startDate &&
                                                                     ss.PurchaseDate <= endDate).ToList();
            }
        }
    }
}
