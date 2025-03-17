using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class PartnerWithDiscount : Partner
    {
        public double Discount
        {
            get
            {
                if (PartnerProductsEntities == null || PartnerProductsEntities.Count == 0)
                {
                    return 0;
                }

                int totalSales = PartnerProductsEntities.Sum(p => p.ProductAmount);

                return totalSales > 300000 ? .15 :
                    totalSales > 50000 ? .10 :
                    totalSales > 10000 ? .05 :
                    0;
            }
        }

        public PartnerWithDiscount(Partner partner) : base(partner.PartnerId, partner.CompanyName, partner.DirectorName, partner.Email, partner.Phone, partner.RegisteredAddress, partner.Rating, partner.PartnerTypeEntity, partner.PartnerTypeId)
        {
            PartnerTypeEntity = partner.PartnerTypeEntity;
            PartnerProductsEntities = partner.PartnerProductsEntities;
        }
    }
}
