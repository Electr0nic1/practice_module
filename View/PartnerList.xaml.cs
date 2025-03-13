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
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PartnerList : Page
    {
        private MainWindow mainWindow;
        public PartnerList(MainWindow mainWindow, PartnerViewModel viewModel)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;

            DataContext = viewModel;
        }

        private void CreatePartner_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.CreatePartner);
        }

    }

    
}