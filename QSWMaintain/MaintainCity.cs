using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainCity : UserControl
    {
        public MaintainCity()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns[0].Width = 100;
            this.dataGridView1.Columns[1].Width = 250;
            var result = WebRequestUtil.GetCityList();
            if (result != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<CityModel>>>(result.Content);
                List<CityModel> cityModelList = response.Data;
                foreach (var city in cityModelList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = city.CityId;
                    this.dataGridView1.Rows[index].Cells[1].Value = city.CityName;
                    this.dataGridView1.Rows[index].Tag = city;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.dataGridView1.SelectedRows[0].Tag as CityModel;
                var deleteResponse = WebRequestUtil.DeleteCity(brand.CityId);
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
                var brand = this.dataGridView1.SelectedRows[0].Tag as CityModel;
                using (AddUpdateCityFrm modify = new AddUpdateCityFrm(MaintainType.Update, brand))
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
            CityModel newBrandModel = new CityModel();
            using (AddUpdateCityFrm newBrand = new AddUpdateCityFrm(MaintainType.New, newBrandModel))
            {
                var dialogResult = newBrand.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    InitControls();
                }
            }
        }
    }
}
