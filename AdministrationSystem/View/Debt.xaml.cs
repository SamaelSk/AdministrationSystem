using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    /// Interaction logic for Debt.xaml
    /// </summary>
    public partial class Debt : Window
    {
        SubscriptionHandler subscriptionHandler = new SubscriptionHandler();
        public Debt()
        {
            InitializeComponent();

            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Группа",
                DisplayMemberBinding = new Binding("GroupName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "ФИО",
                DisplayMemberBinding = new Binding("FullName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Номер",
                DisplayMemberBinding = new Binding("PhoneNumber")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Оплаченых занятий",
                DisplayMemberBinding = new Binding("PaidLessons")
            });

            var students = subscriptionHandler.CreateDebtList();

            //foreach (var student in students)
            //{
            //    student.GroupName = student.Group.Name;
            //}

            listView.ItemsSource = students;
        }
       
    }
}
