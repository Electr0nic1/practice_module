using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class Partner
    {
        public int PartnerId { get; set; }
        public string CompanyName { get; set; }
        public string DirectorName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RegisteredAddress { get; set; }
        public string? Inn { get; set; }
        public decimal? Rating { get; set; }
        public int PartnerTypeId { get; set; }
        public PartnerType PartnerTypeEntity { get; set; }
        public List<PartnerProducts> PartnerProductsEntities { get; set; }

        public Partner() { 

        }

        public Partner(string companyName, string directorName, string email, string phone, string registeredAddress, PartnerType partnerTypeEntity)
        {
            CompanyName = companyName;
            DirectorName = directorName;
            Email = email;
            Phone = phone;
            RegisteredAddress = registeredAddress;
            PartnerTypeEntity = partnerTypeEntity;
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
