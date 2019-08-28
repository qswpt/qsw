using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common.Models
{
    public class CityExLogisticsAmountModel
    {
        public int id { get; set; }
        public int CityId { get; set; }
        public int ExId { get; set; }
        public double Amount { get; set; }
    }
}
