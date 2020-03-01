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
        GroupHandler groupHandler = new GroupHandler();
        bool EditFlag = false;
        int groupId = 0;

        public GroupModification()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            if (!EditFlag)
            {
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Задайте имя группы");
                    return;
                }

                if (groupHandler.AddGroup(name))
                {
                    MessageBox.Show("Группа успешно добавлена");
                    return;
                }
                MessageBox.Show("Группа уже существует");
            }
            else
            {
                if (groupHandler.EditGroup(new Group { Id = groupId, Name = name }))
                {
                    MessageBox.Show("Группа успешно изменена");
                }
                else
                {
                    MessageBox.Show("Ошибка изменения группы");
                }
            }
        }

        public void Edit(Group group)
        {
            NameTextBox.Text = group.Name;
            groupId = group.Id;
            EditFlag = true;
            this.Show();

        }
    }
}
