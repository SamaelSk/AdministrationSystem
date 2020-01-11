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
        Lesson lesson1 = new Lesson();
        public ObservableCollection<Group> Groups { get; set; }
        public LessonModification()
        {
            InitializeComponent();
            Groups = new ObservableCollection<Group>();
            List<String> groups = new List<String>();
            GetGroups(groups);
            GroupComboBox.ItemsSource = groups;
        }

        private void GetGroups(List<string> gr)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.Groups.ToList().ForEach(g => { Groups.Add(g); gr.Add(g.Name); });
            }
        }
        private void LessonDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lesson1.Date = LessonDatePicker.SelectedDate.Value;
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            lesson1.GroupId = Groups.FirstOrDefault(x=>x.Name.Equals(comboBox.SelectedItem)).Id;
            //ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            //using (AdminContext adminContext = new AdminContext())
            //{
            //    lesson1.Group = adminContext.Groups.FirstOrDefault(group => group.Name.Equals(selectedItem.Content));
            //}
        }

        private void StudentsAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            try
            {
                lesson1.StudentsAmount = int.Parse(textBox.Text);
            }
            catch
            {
                lesson1.StudentsAmount = 0;
            }
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                adminContext.Lessons.Add(lesson1);
                adminContext.SaveChanges();
            }

            MessageBox.Show("Занятие успешно добавлено");
        }
    }
}
