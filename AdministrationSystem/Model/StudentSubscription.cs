using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class StudentSubscription
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DateOfExpire { get; set; }
        public int CurrentLessonsUsed { get; set; }
    }
}
