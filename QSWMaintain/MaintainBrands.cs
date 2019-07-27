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
using QSW.Common.Models;
using Framework.Common.Utils;
using System.Web.Mvc;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainBrands : UserControl
    {
        
        private BrandController brandController= new BrandController();
        public MaintainBrands()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            var result = WebRequestUtil.GetBrandHome();
            if (result != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<BrandModel>>>(result.Content);
                List<BrandModel> brandModelList = response.Data;
                foreach (var brand in brandModelList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = brand.BrandName;
                    this.dataGridView1.Rows[index].Cells[1].Value = brand.BrandImg;
                    this.dataGridView1.Rows[index].Cells[2].Value = brand.OderSart;
                    this.dataGridView1.Rows[index].Cells[3].Value = brand.BrandTypeId;
                    this.dataGridView1.Rows[index].Cells[4].Value = brand.BrandState;
                    this.dataGridView1.Rows[index].Tag = brand;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.dataGridView1.SelectedRows[0].Tag as BrandModel;
                ActionResult result = brandController.DeleteBrand(brand.BrandId);
                this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            var brand = this.dataGridView1.SelectedRows[0].Tag as BrandModel;
            AddUpdateBrandFrm modify = new AddUpdateBrandFrm( MaintainType.Update,brand);
            modify.ShowDialog();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BrandModel newBrandModel = new BrandModel();
            AddUpdateBrandFrm newBrand = new AddUpdateBrandFrm(MaintainType.New, newBrandModel);
            newBrand.ShowDialog();
        }
    }
}
