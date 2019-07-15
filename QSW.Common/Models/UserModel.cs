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
    }
}
