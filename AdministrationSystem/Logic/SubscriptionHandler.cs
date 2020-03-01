using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class SubscriptionHandler
    {
        public void CreateSubscription(string name,
                                       decimal price,
                                       int daysToExpire,
                                       int amountOfLessons,
                                       bool isActive)
        {
            Subscription subscription = new Subscription
            {
                Name = name,
                Price = price,
                DaysToExpire = daysToExpire,
                AmountOfLessons = amountOfLessons,
                IsActive = isActive
            };
            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.Subscriptions.Add(subscription);
                adminContext.SaveChanges();
            }
        }

        public void EditSubscription(int subscriptionId,
                                     string name,
                                     decimal price,
                                     int daysToExpire,
                                     int amountOfLessons,
                                     bool isActive)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                Subscription subscription = adminContext.Subscriptions.FirstOrDefault(s => s.Id == subscriptionId);
                subscription.Name = name;
                subscription.Price = price;
                subscription.DaysToExpire = daysToExpire;
                subscription.AmountOfLessons = amountOfLessons;
                subscription.IsActive = isActive;
                adminContext.SaveChanges();
            }
        }

        public void CreateStudentSubscription(Subscription subscription,
             DateTime startingDate, int studentId, int linkedStudentId = 0)
        {
            StudentSubscription studentSubscription = new StudentSubscription
            {
                Price = subscription.Price,
                CurrentLessonsUsed = 0,
                DateOfExpire = startingDate.AddDays(subscription.DaysToExpire),
                PurchaseDate = DateTime.Today,
                StartingDate = startingDate,
                StudentId = studentId,
                SubscriptionId = subscription.Id
            };
            using (AdminContext adminContext = new AdminContext())
            {
                var studentSubscription1 = adminContext.StudentSubscriptions.Add(studentSubscription);
                var student = adminContext.Students.FirstOrDefault(s => s.Id == studentId);
                if (student.PaidLessons < 0 && subscription.AmountOfLessons > student.PaidLessons * (-1))
                {
                    studentSubscription1.CurrentLessonsUsed -= student.PaidLessons;
                }
                else
                if (subscription.AmountOfLessons <= student.PaidLessons * (-1))
                {
                    studentSubscription1.CurrentLessonsUsed += subscription.AmountOfLessons;
                }

                student.PaidLessons += subscription.AmountOfLessons;
                adminContext.SaveChanges();
                if (linkedStudentId != 0)
                {
                    StudentSubscription studentSubscription2 = new StudentSubscription
                    {
                        Price = subscription.Price,
                        CurrentLessonsUsed = 0,
                        DateOfExpire = startingDate.AddDays(subscription.DaysToExpire),
                        PurchaseDate = DateTime.Today,
                        StartingDate = startingDate,
                        StudentId = linkedStudentId,
                        SubscriptionId = subscription.Id,
                        LinkedSubscription = studentSubscription1.Id
                    };
                    var studentSubscription3 = adminContext.StudentSubscriptions.Add(studentSubscription2);
                    var linkedStudent = adminContext.Students.FirstOrDefault(s => s.Id == linkedStudentId);
                    if (student.PaidLessons < 0 && subscription.AmountOfLessons > student.PaidLessons * (-1))
                    {
                        studentSubscription3.CurrentLessonsUsed -= linkedStudent.PaidLessons;
                    }
                    else
                    if (subscription.AmountOfLessons <= linkedStudent.PaidLessons * (-1))
                    {
                        studentSubscription3.CurrentLessonsUsed += subscription.AmountOfLessons;
                    }

                    linkedStudent.PaidLessons += subscription.AmountOfLessons;
                    adminContext.SaveChanges();
                    studentSubscription1.LinkedSubscription = studentSubscription3.Id;
                }
                adminContext.SaveChanges();
            }
        }

        public List<Subscription> GetSubscriptionsTypes()
        {
            using (AdminContext adminContext = new AdminContext())
            {
                return adminContext.Subscriptions.ToList();
            }
        }

        public List<Student> CreateDebtList()
        {
            using (AdminContext adminContext = new AdminContext())
            {
                return adminContext.Students.Where(s => s.PaidLessons <= 1 && s.IsActive)
                                                             .OrderBy(g => g.FullName).ToList();
            }
        }
    }
}
