using System;
using System.Collections.Generic;
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
    /// Interaction logic for StudentModification.xaml
    /// </summary>
    public partial class StudentModification : Window
    {
        GroupHandler groupHandler = new GroupHandler();
        bool EditFlag = false;
        int studentId;
        public StudentModification()
        {
            InitializeComponent();
            GroupsListBox.ItemsSource = groupHandler.GetGroups();
            Active_checkBox.IsChecked = true;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var fullName = FullNameTextBox.Text;
            var phoneNumber = PhoneNumberTextBox.Text;
            var email = EmailTextBox.Text;
            var dateOfBirth = BirthDatePicker.SelectedDate.Value;
            var isActive = Active_checkBox.IsChecked.Value;

            var studentCreator = new StudentCreator();
            if (GroupsListBox.SelectedItems == null ||
                string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) ||
                dateOfBirth == null)

            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                //var groups = GroupsListBox.SelectedItems;
                List<Group> groups = new List<Group>();
                foreach (Group item in GroupsListBox.SelectedItems)
                {
                    groups.Add(item);
                }
                if (!EditFlag)
                {
                    studentCreator.AddStudent(email, dateOfBirth, fullName, groups, isActive, phoneNumber);
                    MessageBox.Show("Ученик успешно добавлен");
                }
                else
                {
                    studentCreator.EditStudent(studentId, email, dateOfBirth, fullName, groups, isActive, phoneNumber);
                    MessageBox.Show("Ученик успешно изменен");
                }
            }

        }

        public void Edit(Student student)
        {
           // GroupComboBox.SelectedItem = student.Group;
            FullNameTextBox.Text = student.FullName;
            PhoneNumberTextBox.Text = student.PhoneNumber;
            EmailTextBox.Text = student.Email;
            BirthDatePicker.SelectedDate = student.DateOfBirth;
            EditFlag = true;
            studentId = student.Id;
            Active_checkBox.IsChecked = student.IsActive;
            this.Show();
        }
    }
}

