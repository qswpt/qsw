using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateCommdityFrm : Form
    {
        private CommodityModel commdodityModel;
        private MaintainType maintainType;
        private List<int> hotList;
        private string previousImg;
        private string newImageGUID = "commodity_" + Guid.NewGuid().ToString();
        public AddUpdateCommdityFrm(MaintainType type, CommodityModel commodity)
        {
            InitializeComponent();
            this.commdodityModel = commodity;
            this.maintainType = type;
            this.previousImg = this.commdodityModel.CommodityImg;
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

            hotList = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                this.hotList.Add(i);
            }

            this.cmbHot.DataSource = hotList;
            this.tbName.Text = this.commdodityModel.CommodityName;
            this.tbImg.Text = this.commdodityModel.CommodityImg;
            this.tbGeneral.Text = this.commdodityModel.CommodityGeneral;
            this.tbPrice.Text = this.commdodityModel.CommodityPrice.ToString();
            this.tbSpec.Text = this.commdodityModel.CommoditySpec.ToString();
            this.cmbBrand.SelectedItem = MaintainCommodity.BrandModelList.Find(p=>p.BrandName== this.commdodityModel.BrandName);
            this.cmbCommodityType.SelectedItem = MaintainCommodity.CommodityTypeList.Find(p=>p.TypeName== this.commdodityModel.TypeName);
            this.tbIndex.Text = this.commdodityModel.CommodityIndex;
            this.tbCode.Text = this.commdodityModel.CommodityCode;
            this.cmbHot.SelectedItem = this.commdodityModel.CommodityHOT;
            this.tbState.Text = "0";
            this.tbRH.Text = this.commdodityModel.CommodityRH;
            this.tbFL.Text = this.commdodityModel.CommodityFL;
            this.tbRM.Text = this.commdodityModel.CommodityRM;
            this.rtbRemark.Text = this.commdodityModel.CommodityRemark;
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
            this.commdodityModel.CommodityImg = this.newImageGUID+Path.GetExtension(this.tbImg.Text);
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
                WebRequestUtil.AddCommodity(JsonUtil.Serialize(this.commdodityModel));
            }
            else
            {
                WebRequestUtil.UpdateCommodity(this.commdodityModel.CommodityId,JsonUtil.Serialize(this.commdodityModel));
            }
            //replace image
            //...
            this.ReplaceImge();
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            fileDialog.Title = "请选择商品图片";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                this.tbImg.Text = filePath;
            }
        }

        private void ReplaceImge()
        {
            string imgName = this.newImageGUID + Path.GetExtension(this.tbImg.Text);
            var contentBytes = File.ReadAllBytes(this.tbImg.Text);
            string imgContent = Convert.ToBase64String(contentBytes);
            WebRequestUtil.ReplaceCommodityImg(this.previousImg, imgName, imgContent);
        }
    }
}
