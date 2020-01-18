using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdministrationSystem.Test
{
    [TestClass]
    public class SubscriptionHandlerTest
    {
        [TestMethod]
        public void CreateSubscriptionTest()
        {
            SubscriptionHandler subscriptionHandler = new SubscriptionHandler();
            subscriptionHandler.CreateSubscription(10, 9, 8);
            subscriptionHandler.CreateStudentSubscription(100, 0, DateTime.Now,
            DateTime.Now, 1, 1);
        }
    }
}
