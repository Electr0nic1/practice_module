using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    internal class PartnerData
    {
        public static List<Partner> GetPartnerForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.Partners.ToList();
            }
        }
    }
}
