namespace QSWMaintain
{
    partial class AddUpdateExFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateExFrm));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancels = new System.Windows.Forms.Button();
            this.btnSaves = new System.Windows.Forms.Button();
            this.tbExName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnCancels);
            this.kryptonPanel1.Controls.Add(this.btnSaves);
            this.kryptonPanel1.Controls.Add(this.tbExName);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(445, 137);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnCancels
            // 
            this.btnCancels.Location = new System.Drawing.Point(351, 85);
            this.btnCancels.Name = "btnCancels";
            this.btnCancels.Size = new System.Drawing.Size(75, 28);
            this.btnCancels.TabIndex = 16;
            this.btnCancels.Text = "取消";
            this.btnCancels.UseVisualStyleBackColor = true;
            this.btnCancels.Click += new System.EventHandler(this.btnCancels_Click);
            // 
            // btnSaves
            // 
            this.btnSaves.Location = new System.Drawing.Point(261, 85);
            this.btnSaves.Name = "btnSaves";
            this.btnSaves.Size = new System.Drawing.Size(75, 28);
            this.btnSaves.TabIndex = 15;
            this.btnSaves.Text = "保存";
            this.btnSaves.UseVisualStyleBackColor = true;
            this.btnSaves.Click += new System.EventHandler(this.btnSaves_Click);
            // 
            // tbExName
            // 
            this.tbExName.Location = new System.Drawing.Point(105, 34);
            this.tbExName.Margin = new System.Windows.Forms.Padding(2);
            this.tbExName.Name = "tbExName";
            this.tbExName.Size = new System.Drawing.Size(321, 27);
            this.tbExName.TabIndex = 14;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(23, 36);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(92, 24);
            this.kryptonLabel1.TabIndex = 13;
            this.kryptonLabel1.Values.Text = "快递名称：";
            // 
            // AddUpdateExFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 137);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddUpdateExFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Krypton Form";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbExName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.Button btnSaves;
        private System.Windows.Forms.Button btnCancels;
    }
}

