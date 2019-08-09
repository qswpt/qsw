using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainCommodity : UserControl
    {
        private static List<BrandModel> brandModelList;
        private static List<CommodityTypeModel> commodityTypeModelList;
        private static List<UnitModel> unitModelList;
        public MaintainCommodity()
        {
            InitializeComponent();
            InitControls();
        }

        public static List<BrandModel> BrandModelList
        {
            get
            {
                brandModelList = getBrandModelList();
                return brandModelList;
            }
        }

        public static List<CommodityTypeModel> CommodityTypeList
        {
            get
            {
                commodityTypeModelList = getCommodityTypeList();
                return commodityTypeModelList;
            }
        }

        public static List<UnitModel> UnitModelList
        {
            get
            {
                unitModelList = getUnitModelList();
                return unitModelList;
            }
        }

        private void InitControls()
        {
            var contentResult = WebRequestUtil.GetCommodityList();
            if (contentResult != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<CommodityModel>>>(contentResult.Content);
                List<CommodityModel> commodityModelList = response.Data;
                foreach (var commodity in commodityModelList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = commodity.CommodityName;
                    this.dataGridView1.Rows[index].Cells[1].Value = commodity.CommodityGeneral;
                    this.dataGridView1.Rows[index].Cells[2].Value = commodity.CommodityPrice;
                    this.dataGridView1.Rows[index].Cells[3].Value = commodity.BrandName;
                    this.dataGridView1.Rows[index].Cells[4].Value = commodity.CommodityCode;
                    this.dataGridView1.Rows[index].Cells[5].Value = commodity.CommoditySpec;
                    this.dataGridView1.Rows[index].Cells[6].Value = commodity.CommodityIndex;
                    this.dataGridView1.Rows[index].Cells[7].Value = commodity.CommodityRH;
                    this.dataGridView1.Rows[index].Cells[8].Value = commodity.CommodityFL;
                    this.dataGridView1.Rows[index].Cells[9].Value = commodity.CommodityRM;
                    this.dataGridView1.Rows[index].Tag = commodity;
                }
            }
        }

        private static List<CommodityTypeModel> getCommodityTypeList()
        {
            var contentResult = WebRequestUtil.GetCommodityType();
            if (contentResult != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<CommodityTypeModel>>>(contentResult.Content);
                List<CommodityTypeModel> commodityModelList = response.Data;
                return commodityModelList;
            }

            return null;
        }

        private static List<UnitModel> getUnitModelList()
        {
            var contentResult = WebRequestUtil.GetUnit();
            if (contentResult != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<UnitModel>>>(contentResult.Content);
                List<UnitModel> unitModelList = response.Data;
                return unitModelList;
            }

            return null;
        }

        private static List<BrandModel> getBrandModelList()
        {
            var contentResult = WebRequestUtil.GetBrandHome();
            if (contentResult != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<BrandModel>>>(contentResult.Content);
                List<BrandModel> brandModelList = response.Data;
                return brandModelList;
            }

            return null;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var commodity = this.dataGridView1.SelectedRows[0].Tag as CommodityModel;
                var result = WebRequestUtil.DeleteCommodityById(commodity.CommodityId);
                if (result != null)
                {
                    bool res = JsonUtil.Deserialize<QSWResponse<bool>>(result.Content).Data;
                    if (res)
                    {
                        this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
                    }
                }
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var commodity = this.dataGridView1.SelectedRows[0].Tag as CommodityModel;
                using (AddUpdateCommdityFrm upadteCommodityFrm = new AddUpdateCommdityFrm(MaintainType.Update, commodity))
                {
                    var dialogResult = upadteCommodityFrm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        this.InitControls();
                    }
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CommodityModel newCommodityModel = new CommodityModel();
            using (AddUpdateCommdityFrm NewCommodityFrm = new AddUpdateCommdityFrm(MaintainType.New, newCommodityModel))
            {
                var dialogResult = NewCommodityFrm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    this.InitControls();
                }
            }
        }
    }
}
