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
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(149, 131);
            this.tbOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(233, 31);
            this.tbOrder.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(86, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 29);
            this.label3.TabIndex = 10;
            this.label3.Values.Text = "顺序：";
            // 
            // tbCommodityTypeName
            // 
            this.tbCommodityTypeName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbCommodityTypeName.Location = new System.Drawing.Point(149, 44);
            this.tbCommodityTypeName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCommodityTypeName.Name = "tbCommodityTypeName";
            this.tbCommodityTypeName.Size = new System.Drawing.Size(233, 31);
            this.tbCommodityTypeName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 5;
            this.label1.Values.Text = "商品类型：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(303, 366);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(174, 366);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // AddUpdateCommodityTypeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 454);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCommodityTypeName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
        private KryptonButton btnCancel;
        private KryptonButton btnSave;
    }
}