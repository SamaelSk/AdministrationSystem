using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int DaysToExpire { get; set; }
        public int AmountOfLessons { get; set; } 
    }
}
