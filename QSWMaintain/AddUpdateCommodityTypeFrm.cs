using ComponentFactory.Krypton.Toolkit;
using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateCommodityTypeFrm : KryptonForm
    {
        private CommodityTypeModel commodityTypeModel;
        private MaintainType maintainType;
        public AddUpdateCommodityTypeFrm(MaintainType type, CommodityTypeModel model)
        {
            InitializeComponent();
            this.commodityTypeModel = model;
            this.maintainType = type;
            InitControls();
        }

        private void InitControls()
        {
            if (this.maintainType == MaintainType.New)
            {
                this.Text = "新建商品类型";
            }
            else if (this.maintainType == MaintainType.Update)
            {
                this.Text = "更新商品类型";

            }
            this.tbCommodityTypeName.Text = this.commodityTypeModel.TypeName;
            this.tbOrder.Text = this.commodityTypeModel.OderSart.ToString();
        }

        private void save()
        {
            this.commodityTypeModel.TypeName = this.tbCommodityTypeName.Text;
            int order = 0;
            int.TryParse(this.tbOrder.Text, out order);
            this.commodityTypeModel.OderSart = order;
            if (this.maintainType == MaintainType.New)
            {
                var addResult = WebRequestUtil.AddCommodityType(JsonUtil.Serialize(this.commodityTypeModel));
                if (addResult == null || addResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("新建商品类型失败");
                }
            }
            else
            {
                var updateResult = WebRequestUtil.UpdateCommodityType(this.commodityTypeModel.TypeId, JsonUtil.Serialize(this.commodityTypeModel));
                if (updateResult == null || updateResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("更新商品类型失败");
                }
            }
        }

        private void btnSaves_Click(object sender, EventArgs e)
        {
            this.save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
