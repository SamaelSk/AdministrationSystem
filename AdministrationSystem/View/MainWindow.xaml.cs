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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministrationSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddAbonType_Click(object sender, RoutedEventArgs e)
        {
            SubsriptionType subsriptionType = new SubsriptionType();
            subsriptionType.Show();
        }
    }
}
