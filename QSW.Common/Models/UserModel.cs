using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSW.Common.Models
{
    public class UserModel
    {
        public int Uid { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Nickname { get; set; }
        public string Sex { get; set; }
        public string EntName { get; set; }
        public string Phones { get; set; }
        public string EntPhone { get; set; }
        public string EntAddres { get; set; }
        public string UserImg { get; set; }
        public string key { get; set; }
    }
}
