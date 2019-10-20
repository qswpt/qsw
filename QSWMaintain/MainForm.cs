using ComponentFactory.Krypton.Toolkit;
using Framework.Common.Utils;
using QSWMaintain.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class MainForm : KryptonForm
    {
        public MainForm()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            InitializeComponent();
            AddUserControl(this.maintainADPic.Value);
            this.btnMaintainADs.Checked = true;
        }

        private Lazy<MaintainADs> maintainADPic = new Lazy<MaintainADs>();

        private Lazy<MaintainBrands> maintainBrands = new Lazy<MaintainBrands>();

        private Lazy<MaintainCommodity> maintainCommodity = new Lazy<MaintainCommodity>();

        private Lazy<MaintainCommodityType> maintainCommodityType = new Lazy<MaintainCommodityType>();

        private Lazy<MaintainCity> maintainCity = new Lazy<MaintainCity>();

        private Lazy<MaintainEx> maintainEx = new Lazy<MaintainEx>();

        private Lazy<MaintainCityExAmount> maintainCityExAmount = new Lazy<MaintainCityExAmount>();
        private void BtnMaintainADs_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainADPic.Value);
        }

        private void BtnMaintaindBrand_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainBrands.Value);
        }

        private void BtnMaintainCommodity_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainCommodity.Value);
        }

        private void BtnMaintainCommodityType_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainCommodityType.Value);
        }

        private void AddUserControl(UserControl control)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        #region Exception Handle
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            LogUtil.Error(ex.Message);
            LogUtil.Error(ex.StackTrace);
            string dateStr = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss");
            var option = MiniDump.Option.WithFullMemory | MiniDump.Option.WithHandleData |
                MiniDump.Option.WithUnloadedModules | MiniDump.Option.WithProcessThreadData |
                MiniDump.Option.WithThreadInfo;
            MiniDump.TryDump(string.Format("log\\QSWMaintain_{0}.dmp", dateStr), option);
        }
        #endregion

        private void Btn_CheckedChanged(object sender, EventArgs e)
        {
            KryptonCheckButton btn = sender as KryptonCheckButton;
            if (btn.Checked)
            {
                foreach (Control ctr in this.panel2.Controls)
                {
                    if (ctr is KryptonCheckButton && ctr != btn)
                    {
                        var checkBtn = ctr as KryptonCheckButton;
                        checkBtn.Checked = false;
                    }
                }
            }
        }

        private void BtnMaintainEx_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainEx.Value);
        }

        private void BtnMaintainCity_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainCity.Value);
        }

        private void KryptonCheckButton1_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainCityExAmount.Value);
        }

        private void btnOrderManager_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发中....");
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
