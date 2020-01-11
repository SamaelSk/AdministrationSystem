using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public int StudentsAmount { get; set; }
        public ICollection<Student> Students { get; set; }

        public Lesson()
        {
            Date = DateTime.Now;
        }
    }
}
