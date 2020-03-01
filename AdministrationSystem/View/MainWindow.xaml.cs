using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministrationSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GroupHandler groupHandler = new GroupHandler();
        LessonCreator lessonCreator = new LessonCreator();
        StudentCreator studentCreator = new StudentCreator();
        SubscriptionHandler subscriptionHandler = new SubscriptionHandler();
        const string lessons = "Уроки";
        const string students = "Ученики";
        const string subscriptions = "Абонементы";



        public MainWindow()
        {
            InitializeComponent();
            GroupComboBox.ItemsSource = groupHandler.GetGroups();
            GroupComboBox2.ItemsSource = groupHandler.GetGroups();
            TypeComboBox.Items.Add(lessons);
            TypeComboBox.Items.Add(students);
            TypeComboBox2.Items.Add(lessons);
            TypeComboBox2.Items.Add(subscriptions);
            StartDatePicker.SelectedDate = DateTime.Today.AddDays(-7);
            EndDatePicker.SelectedDate = DateTime.Today;
            StartDatePicker2.SelectedDate = DateTime.Today.AddMonths(-1);
            EndDatePicker2.SelectedDate = DateTime.Today;
            Subscription_listView.ItemsSource = subscriptionHandler.GetSubscriptionsTypes();
        }
        #region MENU
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentModification studMod = new StudentModification();
            studMod.Show();
        }

        private void AddLesson_Click(object sender, RoutedEventArgs e)
        {
            LessonModification lessMod = new LessonModification();
            lessMod.Show();
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            GroupModification groupMod = new GroupModification();
            groupMod.Show();
        }
        private void AddAbonType_Click(object sender, RoutedEventArgs e)
        {
            SubsriptionType subsriptionType = new SubsriptionType();
            subsriptionType.Show();
        }

        private void AddSub_Click(object sender, RoutedEventArgs e)
        {
            SubscriptionPurchase subscriptionPurchase = new SubscriptionPurchase();
            subscriptionPurchase.Show();
        }

        private void Debt_Click(object sender, RoutedEventArgs e)
        {
            Debt debt = new Debt();
            debt.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GroupComboBox.ItemsSource = groupHandler.GetGroups();
            GroupComboBox2.ItemsSource = groupHandler.GetGroups();
            Subscription_listView.ItemsSource = subscriptionHandler.GetSubscriptionsTypes();
        }

        #endregion
        #region UPDATEgrid
        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillMainDataGrid();
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillMainDataGrid();
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillMainDataGrid();
        }

        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillMainDataGrid();
        }

        

        #endregion

        private void MainDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                foreach (var item in descriptor.Attributes)
                {
                    if (item.GetType() == typeof(HideColumn))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
        }

        private void FillMainDataGrid()
        {
            var type = (string)TypeComboBox.SelectedItem;
            var group = (Group)GroupComboBox.SelectedItem;
            MainListView.ItemsSource = null;

            if (StartDatePicker.SelectedDate != null &&
                EndDatePicker.SelectedDate != null &&
                GroupComboBox.SelectedItem != null)
            {
                switch (type)
                {
                    case "Уроки":

                        {
                            var startDate = (DateTime)StartDatePicker.SelectedDate;
                            var endDate = (DateTime)EndDatePicker.SelectedDate;
                            MainDataGrid.ItemsSource = lessonCreator.GetLessonsByGroup(group.Id, startDate, endDate);
                        }
                        break;
                    case "Ученики":
                        MainDataGrid.ItemsSource = studentCreator.GetStudentsByGroup(group.Id);
                        break;
                    default:
                        break;
                }
            }
        }

        private void MainDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            FillListView();
        }

        private void FillListView()
        {
            var type = (string)TypeComboBox.SelectedItem;
            var cell = (DataGridCellInfo)MainDataGrid.SelectedCells.FirstOrDefault();

            switch (type)
            {
                case "Уроки":
                    if (cell.Item is Lesson)
                    {
                        var lesson = (Lesson)cell.Item;
                        MainListView.ItemsSource = studentCreator.GetStudentsByLesson(lesson.Id);
                    }
                    break;
                case "Ученики":
                    if (cell.Item is Student)
                    {
                        var student = (Student)cell.Item;
                        MainListView.ItemsSource = new List<Student> { student };
                    }
                    break;
                default:
                    break;
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            var cell = (DataGridCellInfo)MainDataGrid.SelectedCells.FirstOrDefault();
            var type = cell.Item;
            if (type is Student)
            {
                StudentModification studMod = new StudentModification();
                studMod.Edit(type as Student);
            }

            FillMainDataGrid();

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var cell = (DataGridCellInfo)MainDataGrid.SelectedCells.FirstOrDefault();
            var type = cell.Item;
            if (type is Lesson)
            {
                Lesson lesson = type as Lesson;
                lessonCreator.DeleteLesson(lesson.Id);
            }
            else if (type is Student)
            {
                Student student = type as Student;
                studentCreator.DeleteStudent(student.Id);
            }

            FillMainDataGrid();

        }

        private void GroupEdit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (GroupComboBox.SelectedItem != null)
            {
                GroupModification groupModification = new GroupModification();
                groupModification.Edit((Group)GroupComboBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }

        



        private void FillSecondDataGrid()
        {
            var type = TypeComboBox2.SelectedItem as string;
            var student = StudentComboBox2.SelectedItem as Student;
            var startDate = (DateTime)StartDatePicker2.SelectedDate;
            var endDate = (DateTime)EndDatePicker2.SelectedDate;

            if (type != null && student != null && GroupComboBox2.SelectedItem != null)
            {
                switch (type)
                {
                    case "Уроки":

                        SecondDataGrid.ItemsSource = studentCreator.GetLessonsByStudent(student.Id, startDate, endDate);
                        break;

                    case "Абонементы":

                        SecondDataGrid.ItemsSource = studentCreator.GetStudentSubscriptionsByStudent(student.Id, startDate, endDate);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void SecondDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                e.Cancel = true;
                foreach (var item in descriptor.Attributes)
                {
                    if (item.GetType() == typeof(ShowColumn))
                    {
                        e.Cancel = false;
                        continue;
                    }
                }
                e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
        }
        private void GroupComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var group2 = (Group)GroupComboBox2.SelectedItem;
            if (group2 != null)
            {
                StudentComboBox2.ItemsSource = studentCreator.GetStudentsByGroup(group2.Id);
                SecondDataGrid.ItemsSource = null;
            }
        }

        private void StudentComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillSecondDataGrid();
        }

        private void TypeComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillSecondDataGrid();
        }

        private void SubscriptionEdit_button_Click(object sender, RoutedEventArgs e)
        {
            var item = Subscription_listView.SelectedItem;
            if (item is Subscription)
            {
                SubsriptionType subsriptionType = new SubsriptionType();
                subsriptionType.Edit(item as Subscription);
            }
        }

        private void Subscription_listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Subscription_listView.SelectedItem != null)
            {
                SubscriptionDataGrid.ItemsSource = new List<Subscription> {(Subscription)Subscription_listView.SelectedItem };
            }
        }
    }
}
