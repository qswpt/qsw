using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateCommdityFrm : Form
    {
        private CommodityModel commdodityModel;
        public AddUpdateCommdityFrm(MaintainType type,CommodityModel commodity)
        {
            InitializeComponent();
            if (commodity != null)
            {
                this.commdodityModel = commodity;
            }
            else
            {
                this.commdodityModel = new CommodityModel();
            }

            InitControls();
        }

        private void InitControls()
        {
        }
    }
}
