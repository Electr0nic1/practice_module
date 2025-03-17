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
                PartnerTypeComboBox.SelectedItem = existingPartner.PartnerTypeEntity.TypeName;
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

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) &&
                   phoneNumber.Length == 10 &&
                   phoneNumber.All(char.IsDigit);
        }

        private bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Length <= 30;
        }

        public void SavePartner(object sender, RoutedEventArgs e)
        {
            if(PartnerTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип партнера");
                return;
            }

            string companyName = CompanyNameTextBox.Text;
            string directorName = DirectorNameTextBox.Text;
            string email = EmailTextBox.Text;
            string phoneNumber = PhoneTextBox.Text;
            string registeredAddress = RegisteredAddressTextBox.Text;
            string ratingString = RatingTextBox.Text;

     
            if (string.IsNullOrWhiteSpace(companyName))
            {
                MessageBox.Show("Пожалуйста, введите название компании.");
                return;
            }

            if (companyName.Length > 50)
            {
                MessageBox.Show("Название компании не должно превышать 50 символов.");
                return;
            }

        
            if (string.IsNullOrWhiteSpace(directorName))
            {
                MessageBox.Show("Пожалуйста, введите ФИО директора.");
                return;
            }

          
            if (string.IsNullOrWhiteSpace(registeredAddress))
            {
                MessageBox.Show("Пожалуйста, введите адрес регистрации.");
                return;
            }

     
            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Неверный формат номера телефона. Введите 10 цифр.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Неверный формат email. Введите email до 30 символов.");
                return;
            }

            int rating;
            if (int.TryParse(ratingString, out rating))
            {
                if (rating < 0 || rating > 100)
                {
                    MessageBox.Show("Рейтинг не в диапазоне 0-100");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверный формат рейтинга. Введите число.");
                return;
            }

            if (existingPartner == null)
            {
                Partner newPartner = new Partner
                {
                    CompanyName = companyName,
                    DirectorName = directorName,
                    Email = email,
                    Phone = phoneNumber,
                    RegisteredAddress = registeredAddress,
                    Rating = rating,
                    PartnerTypeId = DBData.GetPartnerId(PartnerTypeComboBox.SelectedItem.ToString())
                };

                DBData.AddPartner(newPartner);
                MessageBox.Show("Партнер добавлен успешно");
            } else
            {
                existingPartner.CompanyName = CompanyNameTextBox.Text;
                existingPartner.DirectorName = DirectorNameTextBox.Text;
                existingPartner.Email = email;
                existingPartner.Phone = phoneNumber;
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