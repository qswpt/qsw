using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Common.Utils;
using QSW.Common.Models;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainCityExAmount : UserControl
    {
        private static List<CityModel> cityList;

        private static List<ExLogisticModel> exLogisticList;
        public MaintainCityExAmount()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns[0].Width = 250;
            this.dataGridView1.Columns[1].Width = 250;
            this.dataGridView1.Columns[2].Width = 80;
            var result = WebRequestUtil.GetCityExLogisticsAmountList();
            if (result != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<CityExLogisticsAmountModel>>>(result.Content);
                if (response != null)
                {
                    List<CityExLogisticsAmountModel> brandModelList = response.Data;
                    foreach (var brand in brandModelList)
                    {
                        int index = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[index].Cells[0].Value = this.GetCityName(brand.CityId);
                        this.dataGridView1.Rows[index].Cells[1].Value = this.GetExName(brand.ExId);
                        this.dataGridView1.Rows[index].Cells[2].Value = brand.Amount;
                        this.dataGridView1.Rows[index].Tag = brand;
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.dataGridView1.SelectedRows[0].Tag as CityExLogisticsAmountModel;
                var deleteResponse = WebRequestUtil.DeleteCityExLogisticsAmount(brand.id);
                if (deleteResponse != null)
                {
                    bool res = JsonUtil.Deserialize<QSWResponse<bool>>(deleteResponse.Content).Data;
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
                var brand = this.dataGridView1.SelectedRows[0].Tag as CityExLogisticsAmountModel;
                using (AddUpdateCityExLogisticsAmountFrm modify = new AddUpdateCityExLogisticsAmountFrm(MaintainType.Update, brand))
                {
                    var dialogResult = modify.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        InitControls();
                    }
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CityExLogisticsAmountModel newBrandModel = new CityExLogisticsAmountModel();
            using (AddUpdateCityExLogisticsAmountFrm newBrand = new AddUpdateCityExLogisticsAmountFrm(MaintainType.New, newBrandModel))
            {
                var dialogResult = newBrand.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    InitControls();
                }
            }
        }

        public static List<CityModel> CityList
        {
            get
            {
                if (cityList == null)
                {
                    var result = WebRequestUtil.GetCityList();
                    if (result != null)
                    {
                        var response = JsonUtil.Deserialize<QSWResponse<List<CityModel>>>(result.Content);
                        cityList = response.Data;
                    }
                }

                return cityList;
            }
        }

        public static List<ExLogisticModel> ExLogisticList
        {
            get
            {
                if (exLogisticList == null)
                {
                    var result = WebRequestUtil.GetExLogisticList();
                    if (result != null)
                    {
                        var response = JsonUtil.Deserialize<QSWResponse<List<ExLogisticModel>>>(result.Content);
                        exLogisticList = response.Data;
                    }
                }

                return exLogisticList;
            }
        }

        private string GetCityName(int cityId)
        {
            if (CityList != null)
            {
               var city = CityList.FirstOrDefault(p => p.CityId == cityId);
                if (city != null)
                {
                    return city.CityName;
                }
            }

            return string.Empty;
        }

        private string GetExName(int exId)
        {
            if (ExLogisticList != null)
            {
                var ex = ExLogisticList.FirstOrDefault(p => p.ExId == exId);
                if (ex != null)
                {
                    return ex.ExName;
                }
            }

            return string.Empty;
        }
    }
}
