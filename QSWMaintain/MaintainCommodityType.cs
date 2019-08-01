using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainCommodityType : UserControl
    {
        public MaintainCommodityType()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            var result = WebRequestUtil.GetCommodityType();
            if (result != null)
            {
                var commodityTypeList = JsonUtil.Deserialize<QSWResponse<List<CommodityTypeModel>>>(result.Content).Data;
                foreach (var commodityType in commodityTypeList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = commodityType.TypeName;
                    this.dataGridView1.Rows[index].Cells[1].Value = commodityType.OderSart;
                    this.dataGridView1.Rows[index].Tag = commodityType;
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CommodityTypeModel commodityTypeModel = new CommodityTypeModel();
            using (AddUpdateCommodityTypeFrm addCommodityTypeFrm = new AddUpdateCommodityTypeFrm(MaintainType.New, commodityTypeModel))
            {
                addCommodityTypeFrm.ShowDialog();
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var commodityTypeModel = this.dataGridView1.SelectedRows[0].Tag as CommodityTypeModel;
                using (AddUpdateCommodityTypeFrm addCommodityTypeFrm = new AddUpdateCommodityTypeFrm(MaintainType.Update, commodityTypeModel))
                {
                    var dialogResult = addCommodityTypeFrm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        this.InitControls();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var commodityType = this.dataGridView1.SelectedRows[0].Tag as CommodityTypeModel;
                var result = WebRequestUtil.DeleteCommodityType(commodityType.TypeId);
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
    }
}
