using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class StudentSubscription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        [ShowColumn]
        [DisplayName("Стоимость покупки")]
        public decimal Price { get; set; }

        [ShowColumn]
        [DisplayName("Дата покупки")]
        public DateTime? PurchaseDate { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? DateOfExpire { get; set; }

        [ShowColumn]
        [DisplayName("Использованых занятий")]
        public int CurrentLessonsUsed { get; set; }
        public int LinkedSubscription { get; set; }
    }
}
