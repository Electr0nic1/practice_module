using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class PartnerType
    {
        public int PartnerTypeId { get; set; }
        public string TypeName { get; set; }
        public List<Partner> PartnerEntities { get; set; }

        public PartnerType(int partnerTypeId, string typeName)
        {
            PartnerTypeId = partnerTypeId;
            TypeName = typeName;
        }

        
    }
}
