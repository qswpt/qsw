using Framework.Common.Utils;
using KJW.Web.Controllers;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static QSWMaintain.Program;

namespace QSWMaintain
{
    public partial class MaintainADs : UserControl
    {
        public MaintainADs()
        {
            InitializeComponent();
            InitControls();
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
                string dstAD = string.Format("city--{0}-min-min.jpg", number);
                string filePath = fileDialog.FileName;
                bool res = ModifyAD(number, filePath);
                if (!res)
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        private bool ModifyAD(int index, string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            var response = WebRequestUtil.ReplaceAdsImg(index, Convert.ToBase64String(fileBytes));
            if (response != null)
            {
                int res = JsonUtil.Deserialize<QSWResponse<string>>(response.Content).Status;
                return res == 1;
            }
            else
            {
                return false;
            }
        }
    }
}
