using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KJW.Web.Controllers;
using QSW.Web.Controllers;
using System.Web.Mvc;
using static QSWMaintain.Program;
using QSW.Common.Models;
using Framework.Common.Utils;

namespace QSWMaintain
{
    public partial class MaintainCommodity : UserControl
    {
        private static CommodityController commodityController = new CommodityController();
        private static CommodityTypeController commodityTypeController = new CommodityTypeController();
        private static UnitController unitController = new UnitController();
        private static BrandController brandController = new BrandController();
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
            var result = commodityController.GetCommodityList();
            if (result != null)
            {
                var contentResult = result as ContentResult;
                var response = JsonUtil.Deserialize<QSWResponse<List<CommodityModel>>>(contentResult.Content);
                List<CommodityModel> commodityModelList = response.Data;
                foreach (var commodity in commodityModelList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = commodity.BrandName;
                    this.dataGridView1.Rows[index].Cells[1].Value = commodity.CommodityGeneral;
                    this.dataGridView1.Rows[index].Cells[2].Value = commodity.CommodityFamilyId;
                    this.dataGridView1.Rows[index].Cells[3].Value = commodity.CommodityCode;
                    this.dataGridView1.Rows[index].Cells[4].Value = commodity.CommoditySpec;
                    this.dataGridView1.Rows[index].Cells[5].Value = commodity.CommodityIndex;
                    this.dataGridView1.Rows[index].Cells[6].Value = commodity.CommodityHOT;
                    this.dataGridView1.Rows[index].Cells[7].Value = commodity.CommodityRM;
                    this.dataGridView1.Rows[index].Cells[8].Value = commodity.CommodityFL;
                    this.dataGridView1.Rows[index].Tag = commodity;
                }
            }
        }

        private static List<CommodityTypeModel> getCommodityTypeList()
        {
            var result = commodityTypeController.GetCommodityType();
            if (result != null)
            {
                var contentResult = result as ContentResult;
                var response = JsonUtil.Deserialize<QSWResponse<List<CommodityTypeModel>>>(contentResult.Content);
                List<CommodityTypeModel> commodityModelList = response.Data;
                return commodityModelList;
            }

            return null;
        }

        private static List<UnitModel> getUnitModelList()
        {
            var result = unitController.GetUnit();
            if (result != null)
            {
                var contentResult = result as ContentResult;
                var response = JsonUtil.Deserialize<QSWResponse<List<UnitModel>>>(contentResult.Content);
                List<UnitModel> unitModelList = response.Data;
                return unitModelList;
            }

            return null;
        }

        private static List<BrandModel> getBrandModelList()
        {
            var result = brandController.GetBrandHome();
            if (result != null)
            {
                var contentResult = result as ContentResult;
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
                ActionResult result = commodityController.DeleteCommodityById(commodity.CommodityId);
                bool res = JsonUtil.Deserialize<QSWResponse<bool>>((result as ContentResult).Content).Data;
                if (res)
                {
                    this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
                }
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            var commodity = this.dataGridView1.SelectedRows[0].Tag as CommodityModel;
            AddUpdateCommdityFrm upadteCommodityFrm = new AddUpdateCommdityFrm(MaintainType.Update,commodity);
            upadteCommodityFrm.ShowDialog();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CommodityModel newCommodityModel = new CommodityModel();
            AddUpdateCommdityFrm NewCommodityFrm = new AddUpdateCommdityFrm(MaintainType.New, newCommodityModel);
            NewCommodityFrm.ShowDialog();
        }
    }
}
