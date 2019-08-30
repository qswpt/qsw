using ComponentFactory.Krypton.Toolkit;
using QSW.Common.Models;
using RestSharp;
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
    public partial class AddUpdateExFrm : KryptonForm
    {
        private MaintainType maintainType;
        private ExLogisticModel exModel;
        public AddUpdateExFrm(MaintainType type, ExLogisticModel model)
        {
            InitializeComponent();
            this.maintainType = type;
            if (this.maintainType == MaintainType.New)
            {
                this.exModel = new ExLogisticModel();
            }
            else
            {
                this.exModel = model;
            }
            InitControls();
        }

        private void InitControls()
        {
            this.tbExName.Text = this.exModel.ExName;
            if (this.maintainType == MaintainType.New)
            {
                this.Text = "新建快递";
            }
            else
            {
                this.Text = "更新快递";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbExName.Text))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }

            IRestResponse response;
            if (this.maintainType == MaintainType.New)
            {
                response = WebRequestUtil.AddExLogistic(this.tbExName.Text);
            }
            else
            {
                response = WebRequestUtil.UpdateExLogistic(this.exModel.ExId, this.tbExName.Text);
            }

            if (response == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (maintainType == MaintainType.New)
                    MessageBox.Show("新增快递信息失败！");
                else
                    MessageBox.Show("更新快递信息失败！");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
