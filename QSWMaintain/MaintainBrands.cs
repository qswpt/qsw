﻿using Framework.Common.Utils;
using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainBrands : UserControl
    {
        public MaintainBrands()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns[0].Width = 250;
            this.dataGridView1.Columns[1].Width = 100;
            this.dataGridView1.Columns[2].Width = 80;
            this.dataGridView1.Columns[3].Width = 80;
            this.dataGridView1.Columns[4].Width = 80;
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

        }

        private void BtnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnAd_Click(object sender, EventArgs e)
        {
            BrandModel newBrandModel = new BrandModel();
            using (AddUpdateBrandFrm newBrand = new AddUpdateBrandFrm(MaintainType.New, newBrandModel))
            {
                var dialogResult = newBrand.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    InitControls();
                }
            }
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var brand = this.dataGridView1.SelectedRows[0].Tag as BrandModel;
                using (AddUpdateBrandFrm modify = new AddUpdateBrandFrm(MaintainType.Update, brand))
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
                var brand = this.dataGridView1.SelectedRows[0].Tag as BrandModel;
                var deleteResponse = WebRequestUtil.DeleteBrand(brand.BrandId);
                if (deleteResponse != null)
                {
                    bool res = JsonUtil.Deserialize<QSWResponse<bool>>(deleteResponse.Content).Data;
                    if (res)
                    {
                        this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
                        WebRequestUtil.DeleteBrandImage(brand.BrandImg);
                    }
                }
            }
        }
    }
}
