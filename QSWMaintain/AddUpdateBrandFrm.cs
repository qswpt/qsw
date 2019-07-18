using QSW.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class AddUpdateBrandFrm : Form
    {
        private BrandModel brandModel;
        public AddUpdateBrandFrm(MaintainType type,BrandModel model)
        {
            InitializeComponent();
            if (type == MaintainType.Update)
            {
                this.brandModel = model;
            }
            else
            {
                this.brandModel = new BrandModel();
            }

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
            Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Save()
        {

        }
    }
}
