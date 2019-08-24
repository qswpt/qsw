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
            this.btnBrowse = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbOrder = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbState = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(60, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "品牌名：";
            // 
            // tbName
            // 
            this.tbName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbName.Location = new System.Drawing.Point(134, 116);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(233, 31);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 29);
            this.label2.TabIndex = 0;
            this.label2.Values.Text = "品牌图片：";
            // 
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(134, 177);
            this.tbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbImage.Name = "tbImage";
            this.tbImage.ReadOnly = true;
            this.tbImage.Size = new System.Drawing.Size(233, 31);
            this.tbImage.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(375, 173);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(108, 40);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Values.Text = "浏览...";
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(79, 239);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 29);
            this.label3.TabIndex = 3;
            this.label3.Values.Text = "顺序：";
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(134, 236);
            this.tbOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(233, 31);
            this.tbOrder.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(375, 521);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(504, 521);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(41, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 29);
            this.label4.TabIndex = 3;
            this.label4.Values.Text = "品牌类型：";
            // 
            // cmbType
            // 
            this.cmbType.DropDownWidth = 233;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(134, 296);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(233, 29);
            this.cmbType.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(79, 355);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 29);
            this.label5.TabIndex = 3;
            this.label5.Values.Text = "状态：";
            // 
            // cmbState
            // 
            this.cmbState.DropDownWidth = 233;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(134, 352);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(233, 29);
            this.cmbState.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(515, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // AddUpdateBrandFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 615);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.tbOrder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbImage);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateBrandFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUpdateBrandFrm";
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonLabel label1;
        private KryptonTextBox tbName;
        private KryptonLabel label2;
        private KryptonTextBox tbImage;
        private KryptonButton btnBrowse;
        private KryptonLabel label3;
        private KryptonTextBox tbOrder;
        private KryptonButton btnSave;
        private KryptonButton btnCancel;
        private KryptonLabel label4;
        private KryptonComboBox cmbType;
        private KryptonLabel label5;
        private KryptonComboBox cmbState;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}