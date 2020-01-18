using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class LessonCreator
    {
        public void AddLesson(DateTime date, int? groupId, int studentsAmount, List<Student> students)
        {
            Lesson lesson = new Lesson
            {
                Date = date,
                GroupId =groupId,
                StudentsAmount = studentsAmount,
                Students = students                
            };

            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.Lessons.Add(lesson);
                adminContext.SaveChanges();
            }
        }
    }
}
