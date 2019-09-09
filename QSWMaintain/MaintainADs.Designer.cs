using ComponentFactory.Krypton.Toolkit;

namespace QSWMaintain
{
    partial class MaintainADs
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnModify = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ColAdvType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdvContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdvSart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 800);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 503);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(994, 444);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(988, 438);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(105, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 103, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(782, 430);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.kryptonDataGridView1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(994, 494);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnDelete);
            this.panel1.Controls.Add(this.BtnNew);
            this.panel1.Controls.Add(this.BtnModify);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 88);
            this.panel1.TabIndex = 1;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(285, 32);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(108, 40);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Values.Text = "删除";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(25, 32);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(108, 40);
            this.BtnNew.TabIndex = 2;
            this.BtnNew.Values.Text = "新建";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.Location = new System.Drawing.Point(157, 32);
            this.BtnModify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(108, 40);
            this.BtnModify.TabIndex = 2;
            this.BtnModify.Values.Text = "修改";
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.ColumnHeadersHeight = 34;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAdvType,
            this.ColAdvContent,
            this.ColAdvSart,
            this.ColAdv});
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(3, 97);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersVisible = false;
            this.kryptonDataGridView1.RowHeadersWidth = 62;
            this.kryptonDataGridView1.RowTemplate.Height = 34;
            this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(988, 394);
            this.kryptonDataGridView1.TabIndex = 2;
            //this.kryptonDataGridView1.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.KryptonDataGridView1_CellStateChanged);
            this.kryptonDataGridView1.SelectionChanged += new System.EventHandler(this.KryptonDataGridView1_SelectionChanged);
            // 
            // ColAdvType
            // 
            this.ColAdvType.HeaderText = "广告类型";
            this.ColAdvType.MinimumWidth = 8;
            this.ColAdvType.Name = "ColAdvType";
            this.ColAdvType.ReadOnly = true;
            this.ColAdvType.Width = 150;
            // 
            // ColAdvContent
            // 
            this.ColAdvContent.HeaderText = "广告内容";
            this.ColAdvContent.MinimumWidth = 8;
            this.ColAdvContent.Name = "ColAdvContent";
            this.ColAdvContent.ReadOnly = true;
            this.ColAdvContent.Width = 150;
            // 
            // ColAdvSart
            // 
            this.ColAdvSart.HeaderText = "显示顺序";
            this.ColAdvSart.MinimumWidth = 8;
            this.ColAdvSart.Name = "ColAdvSart";
            this.ColAdvSart.ReadOnly = true;
            this.ColAdvSart.Width = 150;
            // 
            // ColAdv
            // 
            this.ColAdv.HeaderText = "广告图像";
            this.ColAdv.MinimumWidth = 8;
            this.ColAdv.Name = "ColAdv";
            this.ColAdv.ReadOnly = true;
            this.ColAdv.Width = 150;
            // 
            // MaintainADs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MaintainADs";
            this.Size = new System.Drawing.Size(1000, 800);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private KryptonButton BtnDelete;
        private KryptonButton BtnNew;
        private KryptonButton BtnModify;
        private KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdvContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdvSart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdv;
    }
}
