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
    public class MaterialViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<MaterialType> materialTypes = new ObservableCollection<MaterialType>(); 

        public ObservableCollection<MaterialType> MaterialTypes
        {
            get { return materialTypes; }
            set
            {
                materialTypes = value;
                OnPropertyChanged(nameof(MaterialTypes));
            }
        }

        public MaterialViewModel()
        {
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            var materials = DBData.GetMaterialTypes();
            MaterialTypes = new ObservableCollection<MaterialType>(materials.Distinct().ToList());
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}