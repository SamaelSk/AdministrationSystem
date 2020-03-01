using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdministrationSystem
{
    /// <summary>
    /// Interaction logic for LessonModification.xaml
    /// </summary>
    public partial class LessonModification : Window
    {
        GroupHandler groupHandler = new GroupHandler();
        LessonCreator LessonCreator = new LessonCreator();
        StudentCreator studentCreator = new StudentCreator();
       
        public LessonModification()
        {
            InitializeComponent();
            GroupComboBox.ItemsSource = groupHandler.GetGroups();
        }


        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var date = DatePicker.SelectedDate.Value;

            var lessonCreator = new LessonCreator();
            if (GroupComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите группу");
                return;
            }
            else
            {
                var selectedItem = (Group)GroupComboBox.SelectedItem;
                var groupId = selectedItem.Id;

                List<Student> studentsList = new List<Student>();

                foreach (Student item in StudentsListBox.SelectedItems)
                {
                    studentsList.Add(item);
                }

                lessonCreator.AddLesson(date, groupId, studentsList);
                MessageBox.Show("Занятие успешно добавлено");
            }
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Group)GroupComboBox.SelectedItem;

            StudentsListBox.ItemsSource = studentCreator.GetStudentsByGroup(selectedItem.Id);
        }

        //public void Edit(Lesson lesson)
        //{
        //    this.Show();
        //}
    }
}
