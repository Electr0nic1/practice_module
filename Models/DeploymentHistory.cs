using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class DeploymentHistory
    {
        public int DeploymentHistoryId { get; set; }
        public DateTime Date { get; set; }
        public decimal SalesAmount { get; set; }
        public int PartnerId { get; set; }
        public decimal DiscountAmount { get; set; }
        public Partner PartnerEntity { get; set; }

        public DeploymentHistory(DateTime date, decimal salesAmount, int partnerId, decimal discountAmount)
        {
            Date = date;
            SalesAmount = salesAmount;
            PartnerId = partnerId;
            DiscountAmount = discountAmount;
        }
    }
}
