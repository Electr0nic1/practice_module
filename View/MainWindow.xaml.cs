﻿using System.Text;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public enum Pages
        {
            PartnerList,
            CreatePartner
        }
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(Pages.PartnerList);
        }
        public void OpenPage(Pages page, Partner partner = null)
        {
            if (page == Pages.PartnerList)
            {
                MainFrame.Navigate(new PartnerList(this, new PartnerViewModel()));
            }
            else if (page == Pages.CreatePartner)
            {
                MainFrame.Navigate(new CreatePartner(this, new PartnerViewModel(), partner));
            }
        }

    }

    
}