using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;
using WpfApp1.Models;


namespace WpfApp1.ViewModel
{
    internal class PartnerViewModel
    {
        public ObservableCollection<Partner> Partners { get; set; }

        public ObservableCollection<string> PartnerNames { get; set; }

        public PartnerViewModel()
        {
            LoadPartners();
        }

        private void LoadPartners()
        {
            var partners = PartnerData.GetPartners();
            Partners = new ObservableCollection<Partner>(partners);
            PartnerNames = new ObservableCollection<string>(partners
                .Select(p => p.CompanyName)
                .Distinct()
                .ToList());
        }

    }
}
