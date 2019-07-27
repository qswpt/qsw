using Framework.Common.Utils;
using QSW.Common.Models;
using QSW.Web.Controllers;
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
        private CommodityController commodityController = new CommodityController();
        private CommodityModel commdodityModel;
        private MaintainType maintainType;
        public AddUpdateCommdityFrm(MaintainType type, CommodityModel commodity)
        {
            InitializeComponent();
            this.commdodityModel = commodity;
            this.maintainType = type;
            InitControls();
        }

        private void InitControls()
        {
            this.cmbBrand.DataSource = MaintainCommodity.BrandModelList;
            this.cmbBrand.DisplayMember = "BrandName";

            this.cmbUnit.DataSource = MaintainCommodity.UnitModelList;
            this.cmbUnit.DisplayMember = "UnitIdName";

            this.cmbCommodityType.DataSource = MaintainCommodity.CommodityTypeList;
            this.cmbCommodityType.DisplayMember = "TypeName";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void save()
        {
            this.commdodityModel.CommodityName = this.tbName.Text;
            this.commdodityModel.CommodityImg = this.tbImg.Text;
            this.commdodityModel.CommodityGeneral = this.tbGeneral.Text;
            this.commdodityModel.CommodityPrice = double.Parse(this.tbPrice.Text);
            this.commdodityModel.UnitIdName = this.cmbUnit.SelectedText;
            this.commdodityModel.CommodityUnitId = (this.cmbUnit.SelectedItem as UnitModel).UnitIdId;
            this.commdodityModel.CommoditySpec = int.Parse(this.tbSpec.Text);
            this.commdodityModel.BrandName = this.cmbBrand.SelectedText;
            this.commdodityModel.CommodityBrandId = (this.cmbBrand.SelectedItem as BrandModel).BrandId;
            this.commdodityModel.CommodityIndex = this.tbIndex.Text;
            this.commdodityModel.CommodityCode = this.tbCode.Text;
            this.commdodityModel.CommodityHOT = int.Parse(this.cmbHot.SelectedText);
            this.commdodityModel.CommodityRH = this.tbRH.Text;
            this.commdodityModel.CommodityRM = this.tbRM.Text;
            this.commdodityModel.CommodityFL = this.tbFL.Text;
            this.commdodityModel.CommodityRemark = this.rtbRemark.Text;
            if (this.maintainType == MaintainType.New)
            {
                this.commodityController.AddCommodity(JsonUtil.Serialize(this.commdodityModel));
            }
            else
            {
                this.commodityController.UpdateCommodity(this.commdodityModel.CommodityId,JsonUtil.Serialize(this.commdodityModel));
            }
            //replace image
            //...
        }
    }
}
