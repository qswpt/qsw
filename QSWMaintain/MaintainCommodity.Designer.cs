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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuige = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMigration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colColor,
            this.colManufacture,
            this.colCode,
            this.colGuige,
            this.colIndex,
            this.colHot,
            this.colLight,
            this.colMigration});
            this.dataGridView1.Location = new System.Drawing.Point(2, 55);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(697, 413);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(227, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(125, 12);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(17, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // colName
            // 
            this.colName.HeaderText = "商品名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "颜色";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            // 
            // colManufacture
            // 
            this.colManufacture.HeaderText = "生产商";
            this.colManufacture.Name = "colManufacture";
            this.colManufacture.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.HeaderText = "编码";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colGuige
            // 
            this.colGuige.HeaderText = "规格";
            this.colGuige.Name = "colGuige";
            this.colGuige.ReadOnly = true;
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "索引号";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            // 
            // colHot
            // 
            this.colHot.HeaderText = "耐热";
            this.colHot.Name = "colHot";
            this.colHot.ReadOnly = true;
            // 
            // colLight
            // 
            this.colLight.HeaderText = "耐光";
            this.colLight.Name = "colLight";
            this.colLight.ReadOnly = true;
            // 
            // colMigration
            // 
            this.colMigration.HeaderText = "耐迁移性";
            this.colMigration.Name = "colMigration";
            this.colMigration.ReadOnly = true;
            // 
            // MaintainCommodity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnNew);
            this.Name = "MaintainCommodity";
            this.Size = new System.Drawing.Size(700, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuige;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMigration;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnNew;
    }
}
