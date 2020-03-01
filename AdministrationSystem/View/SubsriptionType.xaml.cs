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
    /// Interaction logic for SubsriptionType.xaml
    /// </summary>
    public partial class SubsriptionType : Window
    {
        bool EditFlag = false;
        int subscriptionId;
        public SubsriptionType()
        {
            InitializeComponent();
            Active_checkBox.IsChecked = true;

        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {

            var name = NameTextBox.Text;
            var price = PriceTextBox.Text;
            var daysToExpire = DaysToExpireTextBox.Text;
            var amountOfLessons = AmountOfLessonsTextBox.Text;
            var isActive = Active_checkBox.IsChecked.Value;
            SubscriptionHandler subscriptionHandler = new SubscriptionHandler();

            if (string.IsNullOrEmpty(price) ||
                string.IsNullOrEmpty(daysToExpire) ||
                string.IsNullOrEmpty(amountOfLessons) ||
                string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {
                if (decimal.TryParse(price, out decimal convertedPrice) &&
                     int.TryParse(daysToExpire, out int convertedDays) &&
                     int.TryParse(amountOfLessons, out int convertedAmount))
                {
                    if (!EditFlag)
                    {
                        subscriptionHandler.CreateSubscription(name, convertedPrice, convertedDays, convertedAmount, isActive);
                        MessageBox.Show("Абонемент успешно создан");

                    }
                    else
                    {
                        subscriptionHandler.EditSubscription(subscriptionId, name, convertedPrice, convertedDays, convertedAmount, isActive);
                        MessageBox.Show("Абонемент успешно создан");

                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат данных");
                    return;
                }
            }

        }

        public void Edit(Subscription subscription)
        {
            NameTextBox.Text = subscription.Name;
            PriceTextBox.Text = subscription.Price.ToString();
            AmountOfLessonsTextBox.Text = subscription.AmountOfLessons.ToString();
            DaysToExpireTextBox.Text = subscription.DaysToExpire.ToString();
            Active_checkBox.IsChecked = subscription.IsActive;
            subscriptionId = subscription.Id;
            EditFlag = true;
            this.Show();
        }
    }
}
