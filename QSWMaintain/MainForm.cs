using Framework.Common.Utils;
using QSWMaintain.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            InitializeComponent();
            AddUserControl(this.maintainADPic);
            int i = 0;
            int t = 100 / i;
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
