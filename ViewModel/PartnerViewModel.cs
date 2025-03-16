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


namespace WpfApp1.ViewModel
{
    public class PartnerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<PartnerWithDiscount> partners = new ObservableCollection<PartnerWithDiscount>();

        public ObservableCollection<PartnerWithDiscount> Partners
        {
            get { return partners; }
            set
            {
                partners = value;
                OnPropertyChanged(nameof(Partners));
            }
        }

        private ObservableCollection<string> partnerTypes = new ObservableCollection<string>();

        public ObservableCollection<string> PartnerTypes
        {
            get { return partnerTypes; }
            set
            {
                partnerTypes = value;
                OnPropertyChanged(nameof(PartnerTypes));
            }
        }

        private ObservableCollection<string> partnerNames;

        public ObservableCollection<string> PartnerNames
        {
            get { return partnerNames; }
            set
            {
                partnerNames = value;
                OnPropertyChanged(nameof(PartnerNames));
            }
        }

        private PartnerWithDiscount selectedPartner;

        public PartnerWithDiscount SelectedPartner
        {
            get { return selectedPartner; }
            set
            {
                selectedPartner = value;
                OnPropertyChanged(nameof(SelectedPartner));
            }
        }

        private string pageTitle;

        public string PageTitle
        {
            get { return pageTitle; }
            set 
            { 
                pageTitle = value;
                OnPropertyChanged(nameof(PageTitle));
            }
        }

        private string buttonText;
        public string ButtonText
        {
            get { return buttonText; }
            set 
            { 
                buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

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

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
