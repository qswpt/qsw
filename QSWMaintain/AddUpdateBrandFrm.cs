using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateBrandFrm : Form
    {
        private BrandModel brandModel;
        private MaintainType maintainType;
        private string previousImg;
        private string newImageGUID = "brand_" + Guid.NewGuid().ToString();
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
            if (string.IsNullOrEmpty(this.tbName.Text) ||
               string.IsNullOrEmpty(this.tbImage.Text))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }

            Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Save()
        {
            this.brandModel.BrandName = this.tbName.Text;
            this.brandModel.BrandImg = this.newImageGUID+Path.GetExtension(this.tbImage.Text);
            this.brandModel.BrandTypeId = 0;
            this.brandModel.BrandState = 0;
            this.brandModel.OderSart = int.Parse(this.tbOrder.Text);
            if (this.maintainType == MaintainType.New)
            {
                WebRequestUtil.AddBrand(JsonUtil.Serialize(this.brandModel));
            }
            else
            {
                WebRequestUtil.UpdateBrand(this.brandModel.BrandId, JsonUtil.Serialize(this.brandModel));
            }
            //replace image
            //...
            this.ReplaceImge();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            fileDialog.Title = "请选择品牌图片";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                this.tbImage.Text = filePath;
            }
        }

        private void ReplaceImge()
        {
            string imgName = this.newImageGUID + Path.GetExtension(this.tbImage.Text);
            var contentBytes= File.ReadAllBytes(this.tbImage.Text);
           string imgContent = Convert.ToBase64String(contentBytes);
            WebRequestUtil.ReplaceBrandImg(this.previousImg, imgName, imgContent);
        }
    }
}
