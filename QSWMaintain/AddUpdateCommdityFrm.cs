using ComponentFactory.Krypton.Toolkit;
using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class AddUpdateCommdityFrm : KryptonForm
    {
        private CommodityModel commdodityModel;
        private MaintainType maintainType;
        private List<string> hotList;
        private string previousImg;
        private string newImageGUID = "commodity_" + Guid.NewGuid().ToString();
        private bool isReplaceImg = false;
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
            if (this.maintainType == MaintainType.New)
            {
                this.Text = "新建商品";
            }
            else if (this.maintainType == MaintainType.Update)
            {
                this.Text = "更新商品";
            }
            this.cmbBrand.DataSource = MaintainCommodity.BrandModelList;
            this.cmbBrand.DisplayMember = "BrandName";

            this.cmbUnit.DataSource = MaintainCommodity.UnitModelList;
            this.cmbUnit.DisplayMember = "UnitIdName";

            this.cmbCommodityType.DataSource = MaintainCommodity.CommodityTypeList;
            this.cmbCommodityType.DisplayMember = "TypeName";

            hotList = new List<string>();
            hotList.Add("正常");
            hotList.Add("首页");

            this.cmbHot.DataSource = hotList;
            this.tbName.Text = this.commdodityModel.CommodityName;
            this.tbImg.Text = this.commdodityModel.CommodityImg;
            this.tbGeneral.Text = this.commdodityModel.CommodityGeneral;
            this.tbPrice.Text = this.commdodityModel.CommodityPrice.ToString();
            this.tbSpec.Text = this.commdodityModel.CommoditySpec.ToString();
            this.cmbBrand.SelectedItem = MaintainCommodity.BrandModelList.Find(p => p.BrandName == this.commdodityModel.BrandName);
            this.cmbCommodityType.SelectedItem = MaintainCommodity.CommodityTypeList.Find(p => p.TypeName == this.commdodityModel.TypeName);
            this.tbIndex.Text = this.commdodityModel.CommodityIndex;
            this.tbCode.Text = this.commdodityModel.CommodityCode;
            switch (this.commdodityModel.CommoditySuper)
            {
                case 0:
                    this.cmbHot.SelectedItem = "正常";
                    break;
                case 1:
                    this.cmbHot.SelectedItem = "首页";
                    break;
            }
            //this.tbState.Text = "0";
            this.tbRH.Text = this.commdodityModel.CommodityRH;
            this.tbFL.Text = this.commdodityModel.CommodityFL;
            //this.tbRM.Text = this.commdodityModel.CommodityRM;
            //this.rtbRemark.Text = this.commdodityModel.CommodityRemark;

        }

        private void save()
        {
            this.commdodityModel.CommodityName = this.tbName.Text;
            if (this.isReplaceImg)
            {
                this.commdodityModel.CommodityImg = this.commdodityModel.CommodityId + "1" + Path.GetExtension(this.tbImg.Text); //当前图片数量加1
            }

            this.commdodityModel.CommodityGeneral = this.tbGeneral.Text;
            this.commdodityModel.CommodityPrice = double.Parse(this.tbPrice.Text);
            this.commdodityModel.UnitIdName = this.cmbUnit.SelectedText;
            this.commdodityModel.CommodityUnitId = (this.cmbUnit.SelectedItem as UnitModel).UnitIdId;
            this.commdodityModel.CommoditySpec = int.Parse(this.tbSpec.Text);
            this.commdodityModel.BrandName = this.cmbBrand.SelectedText;
            this.commdodityModel.CommodityBrandId = (this.cmbBrand.SelectedItem as BrandModel).BrandId;
            this.commdodityModel.CommodityFamilyId = (this.cmbCommodityType.SelectedItem as CommodityTypeModel).TypeId;
            this.commdodityModel.CommodityIndex = this.tbIndex.Text;
            this.commdodityModel.CommodityCode = this.tbCode.Text;
            // this.commdodityModel.CommodityHOT = int.Parse(this.cmbHot.SelectedItem.ToString());
            this.commdodityModel.CommodityRH = this.tbRH.Text;
            //this.commdodityModel.CommodityRM = this.tbRM.Text;
            this.commdodityModel.CommodityFL = this.tbFL.Text;
            this.commdodityModel.CommodityRemark = string.Empty;
            switch (this.cmbHot.SelectedItem.ToString())
            {
                case "正常":
                    this.commdodityModel.CommoditySuper = 0;
                    break;
                case "首页":
                    this.commdodityModel.CommoditySuper = 1;
                    break;
            }
            if (this.maintainType == MaintainType.New)
            {
                var addResult = WebRequestUtil.AddCommodity(JsonUtil.Serialize(this.commdodityModel));
                if (addResult == null || addResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("新建商品失败");
                }
                else
                {
                    var data = JsonUtil.Deserialize<QSWResponse<CommodityModel>>(addResult.Content).Data;
                    this.commdodityModel.CommodityId = data.CommodityId;
                    this.commdodityModel.CommodityImg = data.CommodityImg;
                }
            }
            else
            {
                var updateResult = WebRequestUtil.UpdateCommodity(this.commdodityModel.CommodityId, JsonUtil.Serialize(this.commdodityModel));
                if (updateResult == null || updateResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("更新商品失败");
                }
            }
            //replace image
            if (this.isReplaceImg)
            {
                this.ReplaceImge();
            }
        }

        private void ReplaceImge()
        {
            string imgName = this.commdodityModel.CommodityImg; //当前图片数量加1
            var contentBytes = File.ReadAllBytes(this.tbImg.Text);
            string imgContent = Convert.ToBase64String(contentBytes);
            var replaceRes = WebRequestUtil.ReplaceCommodityImg(this.previousImg, imgName, imgContent);
            if (replaceRes != null)
            {
                LogUtil.Info("AddUpdateCommodityFrm.ReplaceImage successfully!");
            }
            else
            {
                LogUtil.Error("AddUpdateCommodityFrm.ReplaceImage failed!replaceRes is null!");
            }
        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            fileDialog.Title = "请选择商品图片";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                this.tbImg.Text = filePath;
                this.isReplaceImg = true;
            }
        }

        private void btnSaves_Click(object sender, EventArgs e)
        {
            save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCanle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBrows frm = new FrmBrows(this.commdodityModel.CommodityName, this.commdodityModel.CommodityId);
            frm.ShowDialog();
        }
    }
}
