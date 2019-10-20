using ComponentFactory.Krypton.Toolkit;
using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateADFrm : KryptonForm
    {
        private AdvModel advModel;
        private MaintainType maintainType;
        private string previousImg;
        private string newImageGUID = "adv_" + Guid.NewGuid().ToString();
        private bool isReplaceImg = false;
        private string imagePath = string.Empty;
        public AddUpdateADFrm(MaintainType type, AdvModel model)
        {
            InitializeComponent();
            this.advModel = model;
            this.maintainType = type;
            this.previousImg = this.advModel.AdvImage;
            InitControls();
        }

        private void InitControls()
        {
            if (this.maintainType == MaintainType.New)
            {
                this.Text = "新建广告";
            }
            else if (this.maintainType == MaintainType.Update)
            {
                this.Text = "更新广告";
            }

            this.tbAdvImage.Text = advModel.AdvImage;
            this.cmbAdvType.DataSource = MaintainADs.AdvTypeList;
            this.cmbAdvType.DisplayMember = "AdvTypeName";
            this.tbAdvSart.Text = this.advModel.AdvSart.ToString();
            if (this.maintainType == MaintainType.Update)
            {
                this.cmbAdvType.SelectedIndex = MaintainADs.AdvTypeList.IndexOf(MaintainADs.AdvTypeList.FirstOrDefault(p => p.AdvTypeId == this.advModel.AdvTypeId));
            }
        }

        private void CmbAdvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = this.cmbAdvType.SelectedItem as AdvTypeModel;
            switch (model.AdvTypeId)
            {
                case 1:
                    this.cmbAdvContent.DataSource = MaintainCommodity.BrandModelList;
                    this.cmbAdvContent.DisplayMember = "BrandName";
                    this.cmbAdvContent.SelectedIndex = 0;
                    this.cmbAdvContent.Enabled = true;
                    break;
                case 2:
                    this.cmbAdvContent.DataSource = MaintainADs.CommodityList;
                    this.cmbAdvContent.DisplayMember = "CommodityName";
                    this.cmbAdvContent.SelectedIndex = 0;
                    this.cmbAdvContent.Enabled = true;
                    break;
                case 3:
                    this.cmbAdvContent.Enabled = false;
                    break;
            }
        }

        private void Save()
        {
            if (this.isReplaceImg)
            {
                this.advModel.AdvImage = this.newImageGUID + Path.GetExtension(imagePath);
            }
            else
            {
                this.advModel.AdvImage = this.tbAdvImage.Text;
            }
            this.advModel.AdvTypeId = (this.cmbAdvType.SelectedItem as AdvTypeModel).AdvTypeId;
            if (this.advModel.AdvTypeId == 1)
            {
                this.advModel.AdvInnerId = (this.cmbAdvContent.SelectedItem as BrandModel).BrandId;
            }
            else if (this.advModel.AdvTypeId == 2)
            {
                this.advModel.AdvInnerId = (this.cmbAdvContent.SelectedItem as CommodityModel).CommodityId;
            }
            else
            {
                this.advModel.AdvInnerId = 0;
            }

            int order = 0;
            int.TryParse(this.tbAdvSart.Text, out order);
            this.advModel.AdvSart = order;
            if (this.maintainType == MaintainType.New)
            {
                var addResult = WebRequestUtil.AddAdv(JsonUtil.Serialize(this.advModel));
                if (addResult == null || addResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("新建广告失败！");
                }
            }
            else
            {
                var updateResult = WebRequestUtil.UpdateAdv(this.advModel.AdvId, JsonUtil.Serialize(this.advModel));
                if (updateResult == null || updateResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("更新广告失败！");
                }
            }

            //replace image
            if (this.isReplaceImg)
            {
                this.ReplaceImage();
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {

        }

        private void ReplaceImage()
        {
            string imgName = this.newImageGUID + Path.GetExtension(imagePath);
            var contentBytes = File.ReadAllBytes(imagePath);
            string imgContent = Convert.ToBase64String(contentBytes);
            var replaceRes = WebRequestUtil.ReplaceAdsImg(this.previousImg, imgName, imgContent);
            if (replaceRes != null)
            {
                LogUtil.Info("AddUpdateADFrm.ReplaceImage successfully!");
            }
            else
            {
                LogUtil.Error("AddUpdateADFrm.ReplaceImage failed!replaceRes is null!");
            }
        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            fileDialog.Title = "请选择品牌图片";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                imagePath = filePath;
                this.tbAdvImage.Text = this.newImageGUID + Path.GetExtension(imagePath);
                this.isReplaceImg = true;
            }
        }

        private void btnSaves_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbAdvImage.Text) ||
                          string.IsNullOrEmpty(this.tbAdvSart.Text) ||
                          string.IsNullOrEmpty(this.cmbAdvType.Text) ||
                ((this.cmbAdvType.SelectedItem as AdvTypeModel).AdvTypeId != 3 && string.IsNullOrEmpty(this.cmbAdvContent.Text)))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }

            Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCanle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
