using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class LessonCreator
    {
        public void AddLesson(DateTime date, int? groupId, List<Student> students)
        {

            Lesson lesson = new Lesson
            {
                Date = date,
                GroupId = groupId,
                Students = students,
                StudentsAmount = students.Count
            };

            using (AdminContext adminContext = new AdminContext())
            {
                students.ForEach(s => adminContext.Students.Attach(s));
                adminContext.Lessons.Add(lesson);
                foreach (var student in students)
                {
                    adminContext.Students.FirstOrDefault(s => s.Id == student.Id).PaidLessons -= 1;
                    StudentSubscription studentSubscription = adminContext.StudentSubscriptions.Include("Subscription")
                         .FirstOrDefault(ss => ss.StudentId == student.Id
                    && ss.CurrentLessonsUsed < ss.Subscription.AmountOfLessons
                    && ss.StartingDate <= date
                    && ss.DateOfExpire >= date);
                    if (studentSubscription != null)
                    {
                        if (studentSubscription.LinkedSubscription != 0)
                        {
                            StudentSubscription studentSubscription2 = adminContext.StudentSubscriptions.Include("Subscription")
                                                                      .FirstOrDefault(ss => ss.Id == studentSubscription.LinkedSubscription);
                            if (studentSubscription2 != null)
                            {
                                studentSubscription2.CurrentLessonsUsed += 1;
                            }
                        }
                        studentSubscription.CurrentLessonsUsed += 1;
                    }
                }
                adminContext.SaveChanges();
            }
        }

        public void DeleteLesson(int lessonId)
        {
 
            using (AdminContext adminContext = new AdminContext())
            {
                Lesson lesson = adminContext.Lessons.Include("Students").FirstOrDefault(l => l.Id == lessonId);
                List<Student> students = lesson.Students.ToList();
                foreach (var student in students)
                {
                    StudentSubscription studentSubscription = adminContext.StudentSubscriptions.Include("Subscription").FirstOrDefault(ss => ss.StudentId == student.Id
                    && ss.CurrentLessonsUsed < ss.Subscription.AmountOfLessons
                    && ss.StartingDate <= lesson.Date
                    && ss.DateOfExpire >= lesson.Date
                    && ss.DateOfExpire >= DateTime.Today);
                    if (studentSubscription != null)
                    {
                        adminContext.Students.FirstOrDefault(s => s.Id == student.Id).PaidLessons += 1;
                        if (studentSubscription.LinkedSubscription != 0)
                        {
                            StudentSubscription studentSubscription2 = adminContext.StudentSubscriptions.Include("Subscription")
                                                                      .FirstOrDefault(ss => ss.Id == studentSubscription.LinkedSubscription);
                            if (studentSubscription2 != null)
                            {
                                studentSubscription2.CurrentLessonsUsed -= 1;
                            }
                        }
                        studentSubscription.CurrentLessonsUsed -= 1;
                    }
                }
                adminContext.Lessons.Remove(lesson);
                adminContext.SaveChanges();
            }
        }

        public List<Lesson> GetLessonsByGroup(int id, DateTime startDate, DateTime endDate)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                return adminContext.Lessons.Where(l => l.Group.Id.Equals(id) &&
                l.Date >= startDate &&
                l.Date <= endDate).ToList();
            }
        }

    }
}
