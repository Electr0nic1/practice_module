using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Article { get; set; }
        public decimal MinCost { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductTypeEntity { get; set; }
        public List<PartnerProducts> PartnerProductsEntities { get; set; }

        public Product(int productId, string productName, string article, decimal minCost, int productTypeId)
        {
            ProductId = productId;
            ProductName = productName;
            Article = article;
            MinCost = minCost;
            ProductTypeId = productTypeId;
        }
    }
}
