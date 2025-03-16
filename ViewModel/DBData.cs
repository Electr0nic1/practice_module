using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    internal class DBData
    {
        public static List<PartnerWithDiscount> GetPartners()
        {
            using (DbAppContext ctx = new DbAppContext())
            {

                var partners = ctx.Partners
                    .Include(p => p.PartnerTypeEntity)
                    .Include(p => p.PartnerProductsEntities)
                    .ToList();

                return partners.Select(p => new PartnerWithDiscount(p)).ToList();
            }
        }

        public static void AddPartner(Partner partner)
        {

            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.Partners.Add(partner);
                ctx.SaveChanges();
            }
        }

        public static void UpdatePartner(Partner partner)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                var existingPartner = ctx.Partners.Find(partner.PartnerId);
                if (existingPartner != null)
                {
                    ctx.Entry(existingPartner).CurrentValues.SetValues(partner);
                    ctx.SaveChanges();
                }
            }
        }

        public static int GetPartnerId(string partnerName)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.PartnerTypes.First(t => t.TypeName == partnerName).PartnerTypeId;
            }
        }
    }
}
