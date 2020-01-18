using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class StudentCreator
    {
        public void AddStudent(string email, DateTime dateOfBirth, string fullName, int? groupId,
            bool isActive, int paidLessons, string phoneNumber, List<Lesson> lessons)
        {
            Student student = new Student
            {
                Email = email,
                DateOfBirth = dateOfBirth,
                FullName = fullName,
                GroupId = groupId,
                IsActive = isActive,
                PaidLessons = paidLessons,
                PhoneNumber = phoneNumber,
                Lessons = lessons
            };

            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.Students.Add(student);
                adminContext.SaveChanges();
            }
        }
        
    }
}
