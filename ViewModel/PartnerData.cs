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
        public static List<Partner> GetPartners()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Partners
                    .Include(p => p.PartnerTypeEntity)
                    .Include(p => p.PartnerProductsEntities)
                    .ToList();
            }
        }
    }
}
