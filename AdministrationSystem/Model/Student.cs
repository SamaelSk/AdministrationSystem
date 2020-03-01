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
    public class Student
    {
        [Key]
        [HideColumn]
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string FullName { get; set; }

        [HideColumn]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; }

        [HideColumn]
        public string Email { get; set; }

        //[ForeignKey("Group")]
        //[HideColumn]
        //public int? GroupId { get; set; }

        //[HideColumn]
        //public Group Group { get; set; }
        [HideColumn]
        public ICollection<Group> Groups { get; set; }


        [DisplayName("Оплаченых занятий")]
        public int PaidLessons { get; set; }

        [HideColumn]
        public ICollection<Lesson> Lessons { get; set; }

        [HideColumn]
        public bool IsActive { get; set; }

        //[HideColumn]
        //public string GroupName { get; set; } 

        public override string ToString()
        {
            return FullName;
        }
    }
}
