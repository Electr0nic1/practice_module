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
using WpfApp1.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;
using WpfApp1.Models;
using System.Runtime.CompilerServices;

namespace WpfApp1.View
{
    public partial class ModalWindow : Window
    {
        private MaterialViewModel materialViewModel;
        private ProductViewModel productViewModel;
        private MainWindow mainWindow;

        public ModalWindow(MaterialViewModel materialVM, ProductViewModel producVM)
        {
            InitializeComponent();

            materialViewModel = materialVM;
            productViewModel = producVM;

            DataContext = this;

            MaterialTypeComboBox.DataContext = materialViewModel;
            ProductTypeComboBox.DataContext = productViewModel;

            MaterialTypes = new ObservableCollection<MaterialType>(materialViewModel.MaterialTypes);
            ProductTypes = new ObservableCollection<ProductType>(productViewModel.ProductTypes);
        }

        public ObservableCollection<MaterialType> MaterialTypes { get; set; }
        public ObservableCollection<ProductType> ProductTypes { get; set; }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            MaterialType materialType = (MaterialType)MaterialTypeComboBox.SelectedItem;
            ProductType productType = (ProductType)ProductTypeComboBox.SelectedItem;

            if (MaterialTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип материала");
                return;
            }

            if (ProductTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип продукта");
                return;
            }

            if (!decimal.TryParse(WidthTextBox.Text, out decimal width))
            {
                MessageBox.Show("Неверный формат ширины.");
                return;
            }

            if (!decimal.TryParse(LengthTextBox.Text, out decimal length))
            {
                MessageBox.Show("Неверный формат длины.");
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Неверный формат количества.");
                return;
            }

            MessageBox.Show($"Необходимо материала: {CalculateMaterial(productType, materialType, quantity, width, length)} (тип: {materialType.TypeName}, продукт: {productType.TypeName})");

            this.Close();
        }

        private int CalculateMaterial(ProductType productType, MaterialType materialType, int quantity, decimal width, decimal length)
        {
            decimal materialProductRatio = width * length * productType.Ratio;
            decimal materialsCount = (Math.Round((materialProductRatio * quantity) + (materialProductRatio * quantity * materialType.Ratio), 2));

            if (materialsCount % 10 != 0)
            {
                materialsCount += 1;
            }
            return (int)materialsCount;
        }
    }
}