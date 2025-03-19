using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Article { get; set; }
        public decimal MinCost { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductTypeEntity { get; set; }
        public List<PartnerProducts> PartnerProductsEntities { get; set; }

        public Product() { }

        public Product(int productId, string productName, string article, decimal minCost, int productTypeId, ProductType productTypeEntity, List<PartnerProducts> partnerProductsEntities)
        {
            ProductId = productId;
            ProductName = productName;
            Article = article;
            MinCost = minCost;
            ProductTypeId = productTypeId;
            ProductTypeEntity = productTypeEntity;
            PartnerProductsEntities = partnerProductsEntities;
        }
    }
}
