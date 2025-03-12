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
    internal class PartnerData
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
    }
}
