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
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<ProductType> productTypes = new ObservableCollection<ProductType>();

        public ObservableCollection<ProductType> ProductTypes
        {
            get { return productTypes; }
            set
            {
                productTypes = value;
                OnPropertyChanged(nameof(ProductTypes));
            }
        }

        public ProductViewModel()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = DBData.GetProductTypes();
            ProductTypes = new ObservableCollection<ProductType>(products.Distinct().ToList());
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
