using Framework.Common.Utils;
using QSW.Common.Models;
using QSW.Web.Controllers;
using System;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateCommodityTypeFrm : Form
    {
        private CommodityTypeModel commodityTypeModel;
        private MaintainType maintainType;
        public AddUpdateCommodityTypeFrm(MaintainType type,CommodityTypeModel model)
        {
            InitializeComponent();
            this.commodityTypeModel = model;
            this.maintainType = type;
            InitControls();
        }

        private void InitControls()
        {
            this.tbCommodityTypeName.Text = this.commodityTypeModel.TypeName;
            this.tbOrder.Text = this.commodityTypeModel.OderSart.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save()
        {
            this.commodityTypeModel.TypeName = this.tbCommodityTypeName.Text;
            this.commodityTypeModel.OderSart = this.commodityTypeModel.OderSart;
            if (this.maintainType == MaintainType.New)
            {
                WebRequestUtil.AddCommodityType(JsonUtil.Serialize(this.commodityTypeModel));
            }
            else
            {
                WebRequestUtil.UpdateCommodityType(this.commodityTypeModel.TypeId, JsonUtil.Serialize(this.commodityTypeModel));
            }
        }
    }
}
