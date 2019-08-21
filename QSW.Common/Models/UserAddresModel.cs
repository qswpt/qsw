using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common.Models
{
    public class UserAddresModel
    {
        public int id { get; set; }
        public int Uid { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Contacts { get; set; }
        public int DefaultAddress { get; set; }
        public int CityId { get; set; }
    }
}
