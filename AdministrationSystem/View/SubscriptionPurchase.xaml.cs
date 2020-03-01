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
    /// Interaction logic for SubscriptionPurchase.xaml
    /// </summary>
    public partial class SubscriptionPurchase : Window
    {
        GroupHandler groupHandler = new GroupHandler();
        LessonCreator lessonCreator = new LessonCreator();
        StudentCreator studentCreator = new StudentCreator();
        SubscriptionHandler subscriptionHandler = new SubscriptionHandler();
        public SubscriptionPurchase()
        {
            InitializeComponent();
            GroupComboBox.ItemsSource = groupHandler.GetGroups();
            SubscriptionComboBox.ItemsSource = subscriptionHandler.GetSubscriptionsTypes();
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var group = (Group)GroupComboBox.SelectedItem;
            StudentComboBox.ItemsSource = studentCreator.GetStudentsByGroup(group.Id);
            LinkedSubscriptionComboBox.ItemsSource = studentCreator.GetStudentsByGroup(group.Id);
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)StudentComboBox.SelectedItem;
            var subscription = (Subscription)SubscriptionComboBox.SelectedItem;
            var startDate = StartDatePicker.SelectedDate;
            var linkedStudent = (Student)LinkedSubscriptionComboBox.SelectedItem;
            int linkedStudentId = 0;
            if (linkedStudent != null)
            {
                linkedStudentId = linkedStudent.Id;
            }

            if (GroupComboBox.SelectedItem == null ||
                SubscriptionComboBox.SelectedItem == null ||
                StudentComboBox.SelectedItem == null ||
                startDate == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                subscriptionHandler.CreateStudentSubscription(subscription, 
                                                              startDate.Value, 
                                                              student.Id, 
                                                              linkedStudentId);
                MessageBox.Show("Абонемент оформлен");
            }

        }
    }
}
