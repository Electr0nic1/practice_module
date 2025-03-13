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
    public class PartnerViewModel 
    {
        public ObservableCollection<PartnerWithDiscount> Partners { get; set; }

        private ObservableCollection<string> PartnerTypes { get; set; }

        public ObservableCollection<string> PartnerNames { get; set; }

        public PartnerViewModel()
        {
            LoadPartners();
        }

        private void LoadPartners()
        {
            var partners = DBData.GetPartners();
            Partners = new ObservableCollection<PartnerWithDiscount>(partners);
            PartnerTypes = new ObservableCollection<string>(partners.Select(p => p.PartnerTypeEntity.TypeName).Distinct().ToList());
            PartnerNames = new ObservableCollection<string>(partners
                .Select(p => p.CompanyName)
                .Distinct()
                .ToList());
        }

    }
}
