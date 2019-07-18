using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class MaintainADs : UserControl
    {
        public MaintainADs()
        {
            InitializeComponent();
        }

        private void InitControls()
        {
            this.textBox1.Text = "city--1-min-min.jpg";
            this.textBox2.Text = "city--2-min-min.jpg";
            this.textBox3.Text = "city--3-min-min.jpg";
            this.textBox4.Text = "city--4-min-min.jpg";
            this.textBox5.Text = "city--5-min-min.jpg";
        }

        private void ButtonModify_Click(object sender, EventArgs e)
        {
            string btnName = (sender as Button).Name;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";
            fileDialog.Title = "请选择广告位图片";
            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                char num = btnName.First(p => char.IsDigit(p));
                int number = num - 48;
                string dstAD = string.Format("city--{0}-min-min.jpg",number);
                string filePath = fileDialog.FileName;
                bool res = ModifyAD(dstAD, filePath);
                if (!res)
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        private bool ModifyAD(string dstAD, string filePath)
        {
            return false;
        }
    }
}
