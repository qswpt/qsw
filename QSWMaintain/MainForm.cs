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
            AddUserControl(this.maintainADPic);
            this.btnMaintainADs.Checked = true;
        }

        private MaintainADs maintainADPic = new MaintainADs();

        private MaintainBrands maintainBrands = new MaintainBrands();

        private MaintainCommodity maintainCommodity = new MaintainCommodity();

        private MaintainCommodityType maintainCommodityType = new MaintainCommodityType();

        private void BtnMaintainADs_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainADPic);
        }

        private void BtnMaintaindBrand_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainBrands);
        }

        private void BtnMaintainCommodity_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainCommodity);
        }

        private void BtnMaintainCommodityType_Click(object sender, EventArgs e)
        {
            ((KryptonCheckButton)sender).Checked = true;
            AddUserControl(this.maintainCommodityType);
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
