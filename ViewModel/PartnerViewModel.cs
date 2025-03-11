using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;


namespace WpfApp1.ViewModel
{
    internal class PartnerViewModel
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

        private void LoadPartners()
        {
            using (var db = new DbAppContext())
            {
                var partners = db.Partners
                    .Select(p => new PartnerViewModel
                    {
                        CompanyName = p.CompanyName,
                        DirectorName = p.DirectorName,
                        Email = p.Email,
                        Phone = p.Phone,
                        RegisteredAddress = p.RegisteredAddress,
                        Inn = p.Inn,
                        Rating = p.Rating,
                    }).ToList();

                PartnersGrid.ItemSource = partners;
            }
        }

    }
}
