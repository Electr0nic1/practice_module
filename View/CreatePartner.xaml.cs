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
    public partial class CreatePartner : Page
    {
        private MainWindow mainWindow;
        private PartnerViewModel viewModel;
        private Partner existingPartner;

        public string PageTitle { get; set; }
        public string ButtonText { get; set; }

        public CreatePartner(MainWindow mainWindow, PartnerViewModel viewModel, Partner partner = null)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = viewModel;
            this.existingPartner = partner;

            if (existingPartner != null)
            {
                viewModel.PageTitle = "Редактирование партнера";
                viewModel.ButtonText = "Сохранить изменения";

                CompanyNameTextBox.Text = existingPartner.CompanyName;
                DirectorNameTextBox.Text = existingPartner.DirectorName;
                EmailTextBox.Text = existingPartner.Email;
                PhoneTextBox.Text = existingPartner.Phone;
                RegisteredAddressTextBox.Text = existingPartner.RegisteredAddress;
                RatingTextBox.Text = existingPartner.Rating.ToString();
                PartnerTypeComboBox.SelectedItem = existingPartner.PartnerTypeId;
            } else
            {
                viewModel.PageTitle = "Добавление партнера";
                viewModel.ButtonText = "Добавить партнера";
            }

            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        public void SavePartner(object sender, RoutedEventArgs e)
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

            if (existingPartner == null)
            {
                Partner newPartner = new Partner
                {
                    CompanyName = CompanyNameTextBox.Text,
                    DirectorName = DirectorNameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    RegisteredAddress = RegisteredAddressTextBox.Text,
                    Rating = rating,
                    PartnerTypeId = DBData.GetPartnerId(PartnerTypeComboBox.SelectedItem.ToString())
                };

                DBData.AddPartner(newPartner);
                MessageBox.Show("Партнер добавлен успешно");
            } else
            {
                existingPartner.CompanyName = CompanyNameTextBox.Text;
                existingPartner.DirectorName = DirectorNameTextBox.Text;
                existingPartner.Email = EmailTextBox.Text;
                existingPartner.Phone = PhoneTextBox.Text;
                existingPartner.RegisteredAddress = RegisteredAddressTextBox.Text;
                existingPartner.Rating = rating;
                existingPartner.PartnerTypeId = DBData.GetPartnerId(PartnerTypeComboBox.SelectedItem.ToString());

                DBData.UpdatePartner(existingPartner);
                MessageBox.Show("Партнер обновлен успешно");
            }

            mainWindow.OpenPage(MainWindow.Pages.PartnerList);

            
        }

    }

    
}