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
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp1.View
{
    public partial class PartnerSales : Page
    {
        private MainWindow mainWindow;
        private PartnerViewModel viewModel;

        public PartnerSales(MainWindow mainWindow, PartnerViewModel viewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = viewModel;

            viewModel.PageTitle = "История реализации";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.PartnerList);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var partner = DBData.GetPartnerByName(PartnerNameComboBox.SelectedItem.ToString());

            if (partner == null)
            {
                MessageBox.Show("Партнер не найден");
                return;
            }

            var partnerSales = DBData.GetPartnerProducts().Where(p => p.PartnerId == partner.PartnerId).ToList();
            PartnerViewModel viewModel = (PartnerViewModel)DataContext;
            viewModel.PartnerSales = new ObservableCollection<PartnerProducts>(partnerSales);
        }

        private void CalculateMaterialButton_Click(object sender, RoutedEventArgs e)
        {
            var materialViewModel = new MaterialViewModel();
            var productViewModel = new ProductViewModel();

            ModalWindow modalWindow = new ModalWindow(materialViewModel, productViewModel);
            modalWindow.Owner = Window.GetWindow(this);
            modalWindow.ShowDialog();
        }
    }
}