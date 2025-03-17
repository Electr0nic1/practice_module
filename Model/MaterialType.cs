using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class MaterialType
    {
        public int MaterialTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal Ratio { get; set; }

        public MaterialType(int materialTypeId, string typeName, decimal ratio)
        {
            MaterialTypeId = materialTypeId;
            TypeName = typeName;
            Ratio = ratio;
        }
    }
}
