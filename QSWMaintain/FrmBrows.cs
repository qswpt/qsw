using ComponentFactory.Krypton.Toolkit;
using Framework.Common.Utils;
using mshtml;
using QSW.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QSWMaintain
{
    public partial class FrmBrows : KryptonForm
    {
        private string titleName = string.Empty;
        private int comId = 0;
        public FrmBrows(string titleName, int comId)
        {
            InitializeComponent();
            this.titleName = titleName;
            this.comId = comId;
            this.Text = this.titleName;
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Navigate(ConstDefine.Client.BaseUrl + "/ComInfoEdit.html?id=" + this.comId + "t" + DateTime.Now.Ticks);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IHTMLDocument2 Doc2 = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                try
                {
                    Doc2.parentWindow.execScript("getTxtinfo();", "JavaScript");
                }
                catch (Exception)
                {
                }
                var body = Doc2.body.outerHTML;
                //正则表达式获取DIV
                string str = string.Empty;
                if (!string.IsNullOrEmpty(body))
                {
                    MatchCollection mcDiv = Regex.Matches(body, "<SPAN id=cmtxt style=\"DISPLAY: none\">([\\s\\S]*?)</SPAN><SPAN id=spendtxt style=\"DISPLAY: none\">");
                    str = mcDiv[0].Groups[0].Value;
                    str = str.Replace("<SPAN id=cmtxt style=\"DISPLAY: none\">", "").Replace("</SPAN><SPAN id=spendtxt style=\"DISPLAY: none\">", "");
                }
                var re = WebRequestUtil.UpdateCommodityRemark(this.comId, str);
                if (re == null || re.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("保存失败！");
                }
                else
                {
                    MessageBox.Show("保存成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error("保存商品详情失败：" + ex.Message);
                MessageBox.Show("保存失败！");
            }
        }
    }
}
