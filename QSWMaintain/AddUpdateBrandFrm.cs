using ComponentFactory.Krypton.Toolkit;
using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateBrandFrm : KryptonForm
    {
        private BrandModel brandModel;
        private MaintainType maintainType;
        private string previousImg;
        private string newImageGUID = "brand_" + Guid.NewGuid().ToString();
        private bool isReplaceImg = false;

        public AddUpdateBrandFrm(MaintainType type, BrandModel model)
        {
            InitializeComponent();
            this.brandModel = model;
            this.maintainType = type;
            this.previousImg = this.brandModel.BrandImg;
            InitControls();
        }

        private void InitControls()
        {
            if (this.maintainType == MaintainType.New)
            {
                this.Text = "新建品牌";
            }
            else if (this.maintainType == MaintainType.Update)
            {
                this.Text = "更新品牌";
            }

            this.tbName.Text = brandModel.BrandName;
            this.tbImage.Text = brandModel.BrandImg;
            this.tbOrder.Text = brandModel.OderSart.ToString();
        }

        private void Save()
        {
            this.brandModel.BrandName = this.tbName.Text;
            if (this.isReplaceImg)
            {
                this.brandModel.BrandImg = this.brandModel.BrandId + "1" + Path.GetExtension(this.tbImage.Text);
            }

            this.brandModel.BrandTypeId = 0;
            this.brandModel.BrandState = 0;
            int order = 0;
            int.TryParse(this.tbOrder.Text, out order);
            this.brandModel.OderSart = order;
            if (this.maintainType == MaintainType.New)
            {
                var addResult = WebRequestUtil.AddBrand(JsonUtil.Serialize(this.brandModel));
                if (addResult == null || addResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("新建品牌失败！");
                }
            }
            else
            {
                var updateResult = WebRequestUtil.UpdateBrand(this.brandModel.BrandId, JsonUtil.Serialize(this.brandModel));
                if (updateResult == null || updateResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("更新品牌失败！");
                }
            }

            //replace image
            if (this.isReplaceImg)
            {
                this.ReplaceImage();
            }
        }

        private void ReplaceImage()
        {
            string imgName = this.brandModel.BrandId + "1" + Path.GetExtension(this.tbImage.Text);
            var contentBytes = File.ReadAllBytes(this.tbImage.Text);
            string imgContent = Convert.ToBase64String(contentBytes);
            var replaceRes = WebRequestUtil.ReplaceBrandImg(this.previousImg, imgName, imgContent);
            if (replaceRes != null)
            {
                LogUtil.Info("AddUpdateBrandFrm.ReplaceImage successfully!");
            }
            else
            {
                LogUtil.Error("AddUpdateBrandFrm.ReplaceImage failed!replaceRes is null!");
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
                this.tbImage.Text = filePath;
                this.isReplaceImg = true;
            }
        }

        private void btnSaves_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbName.Text) ||
               string.IsNullOrEmpty(this.tbImage.Text) ||
               string.IsNullOrEmpty(this.tbOrder.Text))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }

            Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
