using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Automation.Provider;
using System.Windows.Navigation;
using WpfApp1.ViewModel;
using WpfApp1.Models;
using WpfApp1.View;

namespace WpfApp1.View
{
    public partial class ModalWindow : Window
    {
        public ModalWindow()
        {
            InitializeComponent();

            // Пример данных для ComboBox-ов (можно заменить на реальные данные из базы или ViewModel)
            MaterialTypes = new ObservableCollection<string> { "Ткань", "Кожа", "Пленка" };
            ProductTypes = new ObservableCollection<string> { "Одежда", "Обувь", "Сумки" };

            DataContext = this; // Важно, чтобы привязки работали

        }

        public ObservableCollection<string> MaterialTypes { get; set; }
        public ObservableCollection<string> ProductTypes { get; set; }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из полей окна
            string materialType = (string)MaterialTypeComboBox.SelectedItem;
            string productType = (string)ProductTypeComboBox.SelectedItem;
            if (!double.TryParse(WidthTextBox.Text, out double width))
            {
                MessageBox.Show("Неверный формат ширины.");
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Неверный формат количества.");
                return;
            }

            // Здесь должна быть логика расчета необходимого материала
            // Заглушка:
            double requiredMaterial = width * quantity;

            MessageBox.Show($"Необходимо материала: {requiredMaterial} (тип: {materialType}, продукт: {productType})");

            // Закрываем модальное окно
            this.Close();
        }
    }
}