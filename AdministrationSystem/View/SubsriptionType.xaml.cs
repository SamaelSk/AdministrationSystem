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
        public SubsriptionType()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {

            var price = PriceTextBox.Text;
            var daysToExpire = DaysToExpireTextBox.Text;
            var amountOfLessons = AmountOfLessonsTextBox.Text;
            SubscriptionHandler subscriptionHandler = new SubscriptionHandler();

            if (string.IsNullOrEmpty(price) ||
                string.IsNullOrEmpty(daysToExpire) ||
                string.IsNullOrEmpty(amountOfLessons))
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
                    subscriptionHandler.CreateSubscription(convertedPrice, convertedDays, convertedAmount);
                    MessageBox.Show("Абонемент успешно создан");
                }
                else
                {
                    MessageBox.Show("Неверный формат данных");
                    return;
                }
            }

        }
    }
}
