using ComponentFactory.Krypton.Toolkit;

namespace QSWMaintain
{
    partial class MaintainCommodity
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMigration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAd = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colGeneral,
            this.colPrice,
            this.colManufacture,
            this.colCode,
            this.colSpec,
            this.colIndex,
            this.colHot,
            this.colLight,
            this.colMigration});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 63);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(794, 414);
            this.dataGridView1.TabIndex = 3;
            // 
            // colName
            // 
            this.colName.HeaderText = "商品名";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colGeneral
            // 
            this.colGeneral.HeaderText = "颜料总称";
            this.colGeneral.MinimumWidth = 8;
            this.colGeneral.Name = "colGeneral";
            this.colGeneral.ReadOnly = true;
            this.colGeneral.Width = 150;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "单价";
            this.colPrice.MinimumWidth = 8;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 150;
            // 
            // colManufacture
            // 
            this.colManufacture.HeaderText = "生产商";
            this.colManufacture.MinimumWidth = 8;
            this.colManufacture.Name = "colManufacture";
            this.colManufacture.ReadOnly = true;
            this.colManufacture.Width = 150;
            // 
            // colCode
            // 
            this.colCode.HeaderText = "编码";
            this.colCode.MinimumWidth = 8;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 150;
            // 
            // colSpec
            // 
            this.colSpec.HeaderText = "规格";
            this.colSpec.MinimumWidth = 8;
            this.colSpec.Name = "colSpec";
            this.colSpec.ReadOnly = true;
            this.colSpec.Width = 150;
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "索引号";
            this.colIndex.MinimumWidth = 8;
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Width = 150;
            // 
            // colHot
            // 
            this.colHot.HeaderText = "耐热";
            this.colHot.MinimumWidth = 8;
            this.colHot.Name = "colHot";
            this.colHot.ReadOnly = true;
            this.colHot.Width = 150;
            // 
            // colLight
            // 
            this.colLight.HeaderText = "耐光";
            this.colLight.MinimumWidth = 8;
            this.colLight.Name = "colLight";
            this.colLight.ReadOnly = true;
            this.colLight.Width = 150;
            // 
            // colMigration
            // 
            this.colMigration.HeaderText = "耐迁移性";
            this.colMigration.MinimumWidth = 8;
            this.colMigration.Name = "colMigration";
            this.colMigration.ReadOnly = true;
            this.colMigration.Width = 150;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 480);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnAd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnAd
            // 
            this.btnAd.Location = new System.Drawing.Point(14, 13);
            this.btnAd.Name = "btnAd";
            this.btnAd.Size = new System.Drawing.Size(75, 28);
            this.btnAd.TabIndex = 7;
            this.btnAd.Text = "添加";
            this.btnAd.UseVisualStyleBackColor = true;
            this.btnAd.Click += new System.EventHandler(this.btnAd_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(104, 13);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 28);
            this.btnUp.TabIndex = 8;
            this.btnUp.Text = "编辑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(194, 13);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 28);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // MaintainCommodity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MaintainCommodity";
            this.Size = new System.Drawing.Size(800, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonDataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMigration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAd;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDel;
    }
}
