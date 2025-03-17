using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class PartnerType
    {
        [Key]
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
