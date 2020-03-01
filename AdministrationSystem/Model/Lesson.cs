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
    public class Lesson
    {
        [Key]
        [HideColumn]
        public int Id { get; set; }

        [ShowColumn]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        [ForeignKey("Group")]
        [HideColumn]
        public int? GroupId { get; set; }

        [HideColumn]
        public Group Group { get; set; }

        [DisplayName("Учеников на занятии")]
        public int StudentsAmount { get; set; }

        [HideColumn]
        public ICollection<Student> Students { get; set; }

        public Lesson()
        {
            Date = DateTime.Now;
        }
    }
}
