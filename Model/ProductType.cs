using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal Ratio { get; set; }
        public List<Product> ProductEntities { get; set; }

        public ProductType(int productTypeId, string typeName, decimal ratio)
        {
            ProductTypeId = productTypeId;
            TypeName = typeName;
            Ratio = ratio;
        }
    }
}
