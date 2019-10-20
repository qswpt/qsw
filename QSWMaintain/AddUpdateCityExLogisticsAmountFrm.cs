using ComponentFactory.Krypton.Toolkit;
using Framework.Common.Utils;
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
    public partial class AddUpdateCityExLogisticsAmountFrm : KryptonForm
    {
        private CityExLogisticsAmountModel advModel;
        private MaintainType maintainType;
        public AddUpdateCityExLogisticsAmountFrm(MaintainType type, CityExLogisticsAmountModel model)
        {
            InitializeComponent();
            this.advModel = model;
            this.maintainType = type;
            InitControls();
        }

        private void InitControls()
        {
            if (this.maintainType == MaintainType.New)
            {
                this.Text = "新建地区快递物流金额";
            }
            else if (this.maintainType == MaintainType.Update)
            {
                this.Text = "更新地区快递物流金额";
            }

            this.cmbCity.DataSource = MaintainCityExAmount.CityList;
            this.cmbCity.DisplayMember = "CityName";
            this.cmbEx.DataSource = MaintainCityExAmount.ExLogisticList;
            this.cmbEx.DisplayMember = "ExName";
            if (this.maintainType == MaintainType.Update)
            {
                this.cmbCity.SelectedIndex = MaintainCityExAmount.CityList.IndexOf(MaintainCityExAmount.CityList.FirstOrDefault(p => p.CityId == this.advModel.CityId));
                this.cmbEx.SelectedIndex = MaintainCityExAmount.ExLogisticList.IndexOf(MaintainCityExAmount.ExLogisticList.FirstOrDefault(p => p.ExId == this.advModel.ExId));
                this.tbAmount.Text = this.advModel.Amount.ToString();
            }
        }

        private void Save()
        {
            this.advModel.CityId = (this.cmbCity.SelectedItem as CityModel).CityId;
            this.advModel.ExId = (this.cmbEx.SelectedItem as ExLogisticModel).ExId;
            double amount = 0;
            double.TryParse(this.tbAmount.Text, out amount);
            this.advModel.Amount = amount;
            if (this.maintainType == MaintainType.New)
            {
                var addResult = WebRequestUtil.AddCityExLogisticsAmount(JsonUtil.Serialize(this.advModel));
                if (addResult == null || addResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("新建地区快递物流金额失败！");
                }
            }
            else
            {
                var updateResult = WebRequestUtil.UpdateCityExLogisticsAmount(this.advModel.id, JsonUtil.Serialize(this.advModel));
                if (updateResult == null || updateResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("更新地区快递物流金额！");
                }
            }
        }

        private void btnSaves_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cmbCity.Text) ||
                  string.IsNullOrEmpty(this.cmbEx.Text))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }
            double amount = 0;
            bool res = double.TryParse(this.tbAmount.Text, out amount);
            if (!res)
            {
                MessageBox.Show("输入金额不正确，请重新输入！");
                return;
            }

            Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancels_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
