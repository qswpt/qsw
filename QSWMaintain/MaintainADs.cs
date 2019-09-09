using Framework.Common.Utils;
using KJW.Web.Controllers;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainADs : UserControl
    {
        private static List<AdvTypeModel> advTypeList;

        private static List<CommodityModel> commodityList;

        private static List<BrandModel> brandList;
        public MaintainADs()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            this.kryptonDataGridView1.Rows.Clear();
            var response = WebRequestUtil.GetAdvList();
            if (response != null)
            {
                var res = JsonUtil.Deserialize<QSWResponse<List<AdvModel>>>(response.Content);
                foreach (var adv in res.Data)
                {
                    int index = this.kryptonDataGridView1.Rows.Add();
                    this.kryptonDataGridView1.Rows[index].Cells[0].Value = this.GetAdvTypeStr(adv.AdvTypeId);
                    this.kryptonDataGridView1.Rows[index].Cells[1].Value = this.GetAdvContentStr(adv.AdvTypeId,adv.AdvInnerId);
                    this.kryptonDataGridView1.Rows[index].Cells[2].Value = adv.AdvSart;
                    this.kryptonDataGridView1.Rows[index].Cells[3].Value = adv.AdvImage;
                    this.kryptonDataGridView1.Rows[index].Tag = adv;
                }

                if (res.Data.Count > 0)
                {
                    this.kryptonDataGridView1.Rows[0].Selected = false;
                    this.kryptonDataGridView1.Rows[0].Selected = true;
                }
            }
        }

        private string GetAdvTypeStr(int advTypeId)
        {
            if (MaintainADs.AdvTypeList != null)
            {
                var findRes = MaintainADs.AdvTypeList.Find(p => p.AdvTypeId == advTypeId);
                if (findRes != null)
                    return findRes.AdvTypeName;
            }

            return string.Empty;
        }

        private string GetAdvContentStr(int advTypeId,int advInnerId)
        {
            if (advTypeId == 1)
            {
                if (MaintainADs.BrandList != null)
                {
                    var findRes = MaintainADs.BrandList.Find(p => p.BrandId == advInnerId);
                    if (findRes != null)
                        return findRes.BrandName;
                }
            }
            else if (advTypeId == 2)
            {
                if (MaintainADs.CommodityList != null)
                {
                    var findRes = MaintainADs.CommodityList.Find(p => p.CommodityId == advInnerId);
                    if (findRes != null)
                        return findRes.CommodityName;
                }
            }

            return string.Empty;
        }
   
        private void PreviewPic(string adsImageName)
        {
            var response = WebRequestUtil.GetAdsImage(adsImageName);
            if (response != null)
            {
                var data = JsonUtil.Deserialize<QSWResponse<string>>(response.Content);
                if (!string.IsNullOrEmpty(data.Data))
                {
                    var imgBytes = Convert.FromBase64String(data.Data);
                    string imageFile = SaveToCache(imgBytes);
                    this.pictureBox1.Image = new Bitmap(imageFile);
                }
                else
                {
                    this.pictureBox1.Image = null;
                }
            }
            else
            {
                this.pictureBox1.Image = null;
            }
        }

        private string SaveToCache(byte[] content)
        {
            try
            {
                string cacheDir = Path.Combine(Environment.CurrentDirectory, ".Cache");
                if (!Directory.Exists(cacheDir))
                {
                    Directory.CreateDirectory(cacheDir);
                }

                string fileName = Guid.NewGuid().ToString();
                string filePath = Path.Combine(cacheDir, fileName);
                File.WriteAllBytes(filePath, content);
                return filePath;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex.Message);
                LogUtil.Error(ex.StackTrace);
                return string.Empty;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            AdvModel newBrandModel = new AdvModel();
            using (AddUpdateADFrm newBrand = new AddUpdateADFrm(MaintainType.New, newBrandModel))
            {
                var dialogResult = newBrand.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    InitControls();
                }
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (this.kryptonDataGridView1.SelectedRows.Count > 0)
            {
                var advModel = this.kryptonDataGridView1.SelectedRows[0].Tag as AdvModel;
                using (AddUpdateADFrm modify = new AddUpdateADFrm(MaintainType.Update, advModel))
                {
                    var dialogResult = modify.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        InitControls();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.kryptonDataGridView1.SelectedRows.Count > 0)
            {
                var adv = this.kryptonDataGridView1.SelectedRows[0].Tag as AdvModel;
                if (adv == null)
                    return;
                var deleteResponse = WebRequestUtil.DeleteAdv(adv.AdvId);
                if (deleteResponse != null)
                {
                    bool res = JsonUtil.Deserialize<QSWResponse<bool>>(deleteResponse.Content).Data;
                    if (res)
                    {
                        this.kryptonDataGridView1.Rows.Remove(this.kryptonDataGridView1.SelectedRows[0]);
                        WebRequestUtil.DeleteAdsImage(adv.AdvImage);
                    }
                }
            }
        }

        public static List<AdvTypeModel> AdvTypeList
        {
            get
            {
                if (advTypeList == null)
                {
                    var response = WebRequestUtil.GetAdvType();
                    if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        advTypeList = JsonUtil.Deserialize<QSWResponse<List<AdvTypeModel>>>(response.Content).Data;
                    }
                }

                return advTypeList;
            }
        }

        public static List<CommodityModel> CommodityList
        {
            get
            {
                if (commodityList == null)
                {
                    var response = WebRequestUtil.GetCommodityList();
                    if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        commodityList = JsonUtil.Deserialize<QSWResponse<List<CommodityModel>>>(response.Content).Data;
                    }
                }

                return commodityList;
            }
        }

        public static List<BrandModel> BrandList
        {
            get
            {
                if (brandList == null)
                {
                    var response = WebRequestUtil.GetBrandHome();
                    if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        brandList = JsonUtil.Deserialize<QSWResponse<List<BrandModel>>>(response.Content).Data;
                    }
                }

                return brandList;
            }
        }

        private void KryptonDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.kryptonDataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.kryptonDataGridView1.SelectedRows[0].Tag as AdvModel;
                if (brand != null)
                    PreviewPic(brand.AdvImage);
            }
        }

        private void KryptonDataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (this.kryptonDataGridView1.CurrentRow == null)
                return;
            if (this.kryptonDataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.kryptonDataGridView1.CurrentRow.Tag as AdvModel;
                if (brand != null)
                    PreviewPic(brand.AdvImage);
            }
        }
    }
}
