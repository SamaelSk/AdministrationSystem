using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public int PaidLessons { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public bool IsActive { get; set; }
       
    }
}
