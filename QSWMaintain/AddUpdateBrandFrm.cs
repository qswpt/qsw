using Framework.Common.Utils;
using KJW.Web.Controllers;
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
    public partial class AddUpdateBrandFrm : Form
    {
        private BrandModel brandModel;
        private BrandController brandController = new BrandController();
        private MaintainType maintainType;
        public AddUpdateBrandFrm(MaintainType type, BrandModel model)
        {
            InitializeComponent();
            this.brandModel = model;
            this.maintainType = type;
            InitControls();
        }

        private void InitControls()
        {
            this.tbName.Text = brandModel.BrandName;
            this.tbImage.Text = brandModel.BrandImg;
            this.tbOrder.Text = brandModel.OderSart.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Save()
        {
            this.brandModel.BrandName = this.tbName.Text;
            this.brandModel.BrandImg = this.tbImage.Text;
            this.brandModel.BrandTypeId = 0;
            this.brandModel.BrandState = 0;
            this.brandModel.OderSart = int.Parse(this.tbOrder.Text);
            if (this.maintainType == MaintainType.New)
            {
                this.brandController.AddBrand(JsonUtil.Serialize(this.brandModel));
            }
            else
            {
                this.brandController.UpdateBrand(this.brandModel.BrandId,JsonUtil.Serialize(this.brandModel));
            }
            //replace image
            //...
        }
    }
}
