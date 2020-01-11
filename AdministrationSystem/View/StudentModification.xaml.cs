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
        Student St1 = new Student();
        public StudentModification()
        {
            InitializeComponent(); 
        }

        private void FullNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            St1.FullName = textBox.Text;
        }

        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            St1.PhoneNumber = textBox.Text;
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            St1.Email = textBox.Text;
        }

        private void PaidLessonsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            try
            {
                St1.PaidLessons = int.Parse(textBox.Text);
            }
            catch 
            {
                St1.PaidLessons = 0;
            }
           
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            St1.DateOfBirth = datePicker1.SelectedDate;
        }

        private void SelectGroupComdoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            using (AdminContext adminContext = new AdminContext())
            {
                St1.GroupId = adminContext.Groups.FirstOrDefault(group => group.Name.Equals(selectedItem.Content)).Id;
            }
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.Students.Add(St1);
                adminContext.SaveChanges();
            }

            MessageBox.Show("Ученик успешно добавлен");
        }
    }
}
