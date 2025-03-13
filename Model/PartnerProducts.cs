using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class PartnerProducts
    {
        public int PartnerProductsId { get; set; }
        public int ProductAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public int PartnerId { get; set; }
        public Partner PartnerEntity { get; set; }
        public Product ProductEntity { get; set; }


        public PartnerProducts(int partnerProductsId, int productAmount, DateTime saleDate, int productId, int partnerId)
        {
            PartnerProductsId = partnerProductsId;
            ProductAmount = productAmount;
            SaleDate = saleDate;
            ProductId = productId;
            PartnerId = partnerId;
        }
    }
}
