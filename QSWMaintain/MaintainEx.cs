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
    public partial class MaintainEx : UserControl
    {
        public MaintainEx()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns[0].Width = 100;
            this.dataGridView1.Columns[1].Width = 250;
            var result = WebRequestUtil.GetExLogisticList();
            if (result != null)
            {
                var response = JsonUtil.Deserialize<QSWResponse<List<ExLogisticModel>>>(result.Content);
                List<ExLogisticModel> exModelList = response.Data;
                foreach (var ex in exModelList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = ex.ExId;
                    this.dataGridView1.Rows[index].Cells[1].Value = ex.ExName;
                    this.dataGridView1.Rows[index].Tag = ex;
                }
            }
        }

        private void btnAd_Click(object sender, EventArgs e)
        {
            ExLogisticModel newBrandModel = new ExLogisticModel();
            using (AddUpdateExFrm newBrand = new AddUpdateExFrm(MaintainType.New, newBrandModel))
            {
                var dialogResult = newBrand.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    InitControls();
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.dataGridView1.SelectedRows[0].Tag as ExLogisticModel;
                using (AddUpdateExFrm modify = new AddUpdateExFrm(MaintainType.Update, brand))
                {
                    var dialogResult = modify.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        InitControls();
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.dataGridView1.SelectedRows[0].Tag as ExLogisticModel;
                var deleteResponse = WebRequestUtil.DeleteExLogistic(brand.ExId);
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
    }
}
