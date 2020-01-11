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
    /// Interaction logic for GroupModification.xaml
    /// </summary>
    public partial class GroupModification : Window
    {
        Group group1 = new Group();
        public GroupModification()
        {
            InitializeComponent();
        }

        private bool CheckExistingGroup(string name, AdminContext adminContext)
        {
            var isChecked = adminContext.Groups.Count(group => group.Name.Equals(name));
            if (isChecked > 0) return true;
                return false;
        }
        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            group1.Name = textBox.Text;
        }
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                if (!CheckExistingGroup(group1.Name, adminContext))
                {
                adminContext.Groups.Add(group1);
                adminContext.SaveChanges();
                MessageBox.Show("Группа успешно добавлена");
                }
                MessageBox.Show("Группа уже существует");
            }
        }
    }
}
