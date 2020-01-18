using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class SubscriptionHandler
    {
        public void CreateSubscription(decimal price, int daysToExpire, int amountOfLessons)
        {
            Subscription subscription = new Subscription
            {
                Price = price,
                DaysToExpire = daysToExpire,
                AmountOfLessons = amountOfLessons
            };
            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.Subscriptions.Add(subscription);
                adminContext.SaveChanges();
            }
        }

        public void CreateStudentSubscription(decimal price, int currentLessonUsed, DateTime dateOfExpire,
            DateTime purchaseDate, int studentId, int subscriptionId)
        {
            StudentSubscription studentSubscription = new StudentSubscription
            {
                Price = price,
                CurrentLessonsUsed = currentLessonUsed,
                DateOfExpire = dateOfExpire,
                PurchaseDate = purchaseDate,
                StudentId = studentId,
                SubscriptionId = subscriptionId
            };
            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.StudentSubscriptions.Add(studentSubscription);
                adminContext.SaveChanges();
            }
        }
    }
}
