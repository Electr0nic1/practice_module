using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class Partner
    {
        public int PartnerId { get; set; }
        public string CompanyName { get; set; }
        public string DirectorName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RegisteredAddress { get; set; }
        public string Inn { get; set; }
        public decimal? Rating { get; set; }
        public int PartnerTypeId { get; set; }
        public PartnerType PartnerTypeEntity { get; set; }
        public List<PartnerProducts> PartnerProductsEntities { get; set; }

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

        public Partner(int partnerId, string companyName, string directorName, string email, string phone, string registeredAddress, string inn, decimal? rating, int partnerTypeId)
        {
            PartnerId = partnerId;
            CompanyName = companyName;
            DirectorName = directorName;
            Email = email;
            Phone = phone;
            RegisteredAddress = registeredAddress;
            Inn = inn;
            Rating = rating;
            PartnerTypeId = partnerTypeId;
        }
    }
}
