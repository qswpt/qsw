using ComponentFactory.Krypton.Toolkit;

namespace QSWMaintain
{
    partial class AddUpdateCommodityTypeFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbOrder = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbCommodityTypeName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSaves = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(101, 77);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(233, 27);
            this.tbOrder.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(51, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 10;
            this.label3.Values.Text = "顺序：";
            // 
            // tbCommodityTypeName
            // 
            this.tbCommodityTypeName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbCommodityTypeName.Location = new System.Drawing.Point(101, 29);
            this.tbCommodityTypeName.Name = "tbCommodityTypeName";
            this.tbCommodityTypeName.Size = new System.Drawing.Size(233, 27);
            this.tbCommodityTypeName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 5;
            this.label1.Values.Text = "商品类型：";
            // 
            // btnSaves
            // 
            this.btnSaves.Location = new System.Drawing.Point(178, 128);
            this.btnSaves.Name = "btnSaves";
            this.btnSaves.Size = new System.Drawing.Size(75, 28);
            this.btnSaves.TabIndex = 13;
            this.btnSaves.Text = "保存";
            this.btnSaves.UseVisualStyleBackColor = true;
            this.btnSaves.Click += new System.EventHandler(this.btnSaves_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(259, 128);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 28);
            this.btnCancle.TabIndex = 14;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // AddUpdateCommodityTypeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 177);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSaves);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCommodityTypeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateCommodityTypeFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddUpdateCommodityTypeFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonTextBox tbOrder;
        private KryptonLabel label3;
        private KryptonTextBox tbCommodityTypeName;
        private KryptonLabel label1;
        private System.Windows.Forms.Button btnSaves;
        private System.Windows.Forms.Button btnCancle;
    }
}