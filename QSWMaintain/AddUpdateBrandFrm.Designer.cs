using ComponentFactory.Krypton.Toolkit;

namespace QSWMaintain
{
    partial class AddUpdateBrandFrm
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
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbImage = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbOrder = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbState = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnUpFile = new System.Windows.Forms.Button();
            this.btnSaves = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(44, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "品牌名：";
            // 
            // tbName
            // 
            this.tbName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbName.Location = new System.Drawing.Point(117, 32);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(279, 27);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 0;
            this.label2.Values.Text = "品牌图片：";
            // 
            // tbImage
            // 
            this.tbImage.Enabled = false;
            this.tbImage.Location = new System.Drawing.Point(117, 69);
            this.tbImage.Name = "tbImage";
            this.tbImage.ReadOnly = true;
            this.tbImage.Size = new System.Drawing.Size(279, 27);
            this.tbImage.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(61, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 3;
            this.label3.Values.Text = "顺序：";
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(117, 106);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(95, 27);
            this.tbOrder.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(228, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 24);
            this.label4.TabIndex = 3;
            this.label4.Values.Text = "品牌类型：";
            this.label4.Visible = false;
            // 
            // cmbType
            // 
            this.cmbType.DropDownWidth = 233;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(316, 108);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(148, 25);
            this.cmbType.TabIndex = 5;
            this.cmbType.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 24);
            this.label5.TabIndex = 3;
            this.label5.Values.Text = "状态：";
            this.label5.Visible = false;
            // 
            // cmbState
            // 
            this.cmbState.DropDownWidth = 233;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(70, 141);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(186, 25);
            this.cmbState.TabIndex = 5;
            this.cmbState.Visible = false;
            // 
            // btnUpFile
            // 
            this.btnUpFile.Location = new System.Drawing.Point(401, 67);
            this.btnUpFile.Name = "btnUpFile";
            this.btnUpFile.Size = new System.Drawing.Size(86, 28);
            this.btnUpFile.TabIndex = 6;
            this.btnUpFile.Text = "图片上传";
            this.btnUpFile.UseVisualStyleBackColor = true;
            this.btnUpFile.Click += new System.EventHandler(this.btnUpFile_Click);
            // 
            // btnSaves
            // 
            this.btnSaves.Location = new System.Drawing.Point(328, 160);
            this.btnSaves.Name = "btnSaves";
            this.btnSaves.Size = new System.Drawing.Size(75, 28);
            this.btnSaves.TabIndex = 7;
            this.btnSaves.Text = "保存";
            this.btnSaves.UseVisualStyleBackColor = true;
            this.btnSaves.Click += new System.EventHandler(this.btnSaves_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(412, 160);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 28);
            this.btnCancle.TabIndex = 8;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // AddUpdateBrandFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 204);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSaves);
            this.Controls.Add(this.btnUpFile);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbImage);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateBrandFrm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUpdateBrandFrm";
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonLabel label1;
        private KryptonTextBox tbName;
        private KryptonLabel label2;
        private KryptonTextBox tbImage;
        private KryptonLabel label3;
        private KryptonTextBox tbOrder;
        private KryptonLabel label4;
        private KryptonComboBox cmbType;
        private KryptonLabel label5;
        private KryptonComboBox cmbState;
        private System.Windows.Forms.Button btnUpFile;
        private System.Windows.Forms.Button btnSaves;
        private System.Windows.Forms.Button btnCancle;
    }
}