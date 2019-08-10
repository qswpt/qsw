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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AddUserControl(this.maintainADPic);
        }

        private MaintainADs maintainADPic = new MaintainADs();

        private MaintainBrands maintainBrands = new MaintainBrands();

        private MaintainCommodity maintainCommodity = new MaintainCommodity();

        private MaintainCommodityType maintainCommodityType = new MaintainCommodityType();

        private void BtnMaintainADs_Click(object sender, EventArgs e)
        {
            AddUserControl(this.maintainADPic);
        }

        private void BtnMaintaindBrand_Click(object sender, EventArgs e)
        {
            AddUserControl(this.maintainBrands);
        }

        private void BtnMaintainCommodity_Click(object sender, EventArgs e)
        {
            AddUserControl(this.maintainCommodity);
        }

        private void BtnMaintainCommodityType_Click(object sender, EventArgs e)
        {
            AddUserControl(this.maintainCommodityType);
        }

        private void AddUserControl(UserControl control)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
    }

    public enum MaintainType
    {
        //新建
        New,
        //更新
        Update,
        //删除
        Delete
    }
}
