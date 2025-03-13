using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using WpfApp1.Models;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CreatePartner : Page
    {
        private MainWindow mainWindow;
        public CreatePartner(MainWindow mainWindow, PartnerViewModel viewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = viewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        public void AddPartner(object sender, RoutedEventArgs e)
        {
            if(PartnerTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип партнера");
                return;
            }

            var rating = Decimal.Parse(RatingTextBox.Text);
            if (rating < 0 && rating > 100)
            {
                MessageBox.Show("Рейтинг не диапазоне 0-100");
                return;
            }

            Partner partner = new Partner
            {
                CompanyName = CompanyNameTextBox.Text,
                DirectorName = DirectorNameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text,
                RegisteredAddress = RegisteredAddressTextBox.Text,
                Rating = rating,
                PartnerTypeId = DBData.GetPartnerId(PartnerTypeComboBox.SelectedItem.ToString())
            };

            DBData.AddPartner(partner);
            MessageBox.Show("Партнер добавлен успешно");
        }

    }

    
}