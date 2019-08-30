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
    public partial class AddUpdateCityFrm : KryptonForm
    {
        private MaintainType maintainType;
        private CityModel cityModel;
        public AddUpdateCityFrm(MaintainType type, CityModel model)
        {
            InitializeComponent();
            this.maintainType = type;
            if (this.maintainType == MaintainType.New)
            {
                this.cityModel = new CityModel();
            }
            else
            {
                this.cityModel = model;
            }
            InitControls();
        }

        private void InitControls()
        {
            this.tbCityName.Text = this.cityModel.CityName;
            if (this.maintainType == MaintainType.New)
            {
                this.Text = "新建省份";
            }
            else
            {
                this.Text = "更新省份";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbCityName.Text))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }

            IRestResponse response;
            if (this.maintainType == MaintainType.New)
            {
                response = WebRequestUtil.AddCity(this.tbCityName.Text);
            }
            else
            {
                response = WebRequestUtil.UpdateCity(this.cityModel.CityId, this.tbCityName.Text);
            }

            if (response == null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (maintainType == MaintainType.New)
                    MessageBox.Show("新增省份失败！");
                else
                    MessageBox.Show("更新省份失败！");
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
