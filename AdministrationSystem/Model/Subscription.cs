using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class Subscription
    {
        [Key]
        [HideColumn]
        public int Id { get; set; }

        [DisplayName("Тип")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Длительность (дней)")]
        public int DaysToExpire { get; set; }

        [DisplayName("Количество занятий")]
        public int AmountOfLessons { get; set; }

        [HideColumn]
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
