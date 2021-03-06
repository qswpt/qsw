﻿using ComponentFactory.Krypton.Toolkit;

namespace QSWMaintain
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMaintainADs = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnMaintaindBrand = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnMaintainCommodity = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnMaintainCommodityType = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOrderManager = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckButton1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnMaintainEx = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.btnMaintainCity = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaintainADs
            // 
            this.btnMaintainADs.Checked = true;
            this.btnMaintainADs.Location = new System.Drawing.Point(15, 8);
            this.btnMaintainADs.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaintainADs.Name = "btnMaintainADs";
            this.btnMaintainADs.Size = new System.Drawing.Size(152, 30);
            this.btnMaintainADs.TabIndex = 1;
            this.btnMaintainADs.Values.Text = "首页广告位";
            this.btnMaintainADs.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            this.btnMaintainADs.Click += new System.EventHandler(this.BtnMaintainADs_Click);
            // 
            // btnMaintaindBrand
            // 
            this.btnMaintaindBrand.Location = new System.Drawing.Point(15, 53);
            this.btnMaintaindBrand.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaintaindBrand.Name = "btnMaintaindBrand";
            this.btnMaintaindBrand.Size = new System.Drawing.Size(152, 30);
            this.btnMaintaindBrand.TabIndex = 2;
            this.btnMaintaindBrand.Values.Text = "品牌管理";
            this.btnMaintaindBrand.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            this.btnMaintaindBrand.Click += new System.EventHandler(this.BtnMaintaindBrand_Click);
            // 
            // btnMaintainCommodity
            // 
            this.btnMaintainCommodity.Location = new System.Drawing.Point(15, 98);
            this.btnMaintainCommodity.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaintainCommodity.Name = "btnMaintainCommodity";
            this.btnMaintainCommodity.Size = new System.Drawing.Size(152, 30);
            this.btnMaintainCommodity.TabIndex = 2;
            this.btnMaintainCommodity.Values.Text = "商品管理";
            this.btnMaintainCommodity.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            this.btnMaintainCommodity.Click += new System.EventHandler(this.BtnMaintainCommodity_Click);
            // 
            // btnMaintainCommodityType
            // 
            this.btnMaintainCommodityType.Location = new System.Drawing.Point(15, 144);
            this.btnMaintainCommodityType.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaintainCommodityType.Name = "btnMaintainCommodityType";
            this.btnMaintainCommodityType.Size = new System.Drawing.Size(152, 30);
            this.btnMaintainCommodityType.TabIndex = 2;
            this.btnMaintainCommodityType.Values.Text = "修改商品类型";
            this.btnMaintainCommodityType.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            this.btnMaintainCommodityType.Click += new System.EventHandler(this.BtnMaintainCommodityType_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 490);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOrderManager);
            this.panel2.Controls.Add(this.kryptonCheckButton1);
            this.panel2.Controls.Add(this.btnMaintainEx);
            this.panel2.Controls.Add(this.btnMaintainCity);
            this.panel2.Controls.Add(this.btnMaintainCommodityType);
            this.panel2.Controls.Add(this.btnMaintaindBrand);
            this.panel2.Controls.Add(this.btnMaintainCommodity);
            this.panel2.Controls.Add(this.btnMaintainADs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 468);
            this.panel2.TabIndex = 3;
            // 
            // btnOrderManager
            // 
            this.btnOrderManager.Location = new System.Drawing.Point(15, 334);
            this.btnOrderManager.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderManager.Name = "btnOrderManager";
            this.btnOrderManager.Size = new System.Drawing.Size(152, 30);
            this.btnOrderManager.TabIndex = 6;
            this.btnOrderManager.Values.Text = "订单管理";
            this.btnOrderManager.Click += new System.EventHandler(this.btnOrderManager_Click);
            // 
            // kryptonCheckButton1
            // 
            this.kryptonCheckButton1.Location = new System.Drawing.Point(15, 286);
            this.kryptonCheckButton1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonCheckButton1.Name = "kryptonCheckButton1";
            this.kryptonCheckButton1.Size = new System.Drawing.Size(152, 30);
            this.kryptonCheckButton1.TabIndex = 5;
            this.kryptonCheckButton1.Values.Text = "配送费用管理";
            this.kryptonCheckButton1.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            this.kryptonCheckButton1.Click += new System.EventHandler(this.KryptonCheckButton1_Click);
            // 
            // btnMaintainEx
            // 
            this.btnMaintainEx.Location = new System.Drawing.Point(15, 237);
            this.btnMaintainEx.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaintainEx.Name = "btnMaintainEx";
            this.btnMaintainEx.Size = new System.Drawing.Size(152, 30);
            this.btnMaintainEx.TabIndex = 4;
            this.btnMaintainEx.Values.Text = "配送方式";
            this.btnMaintainEx.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            this.btnMaintainEx.Click += new System.EventHandler(this.BtnMaintainEx_Click);
            // 
            // btnMaintainCity
            // 
            this.btnMaintainCity.Location = new System.Drawing.Point(15, 190);
            this.btnMaintainCity.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaintainCity.Name = "btnMaintainCity";
            this.btnMaintainCity.Size = new System.Drawing.Size(152, 30);
            this.btnMaintainCity.TabIndex = 3;
            this.btnMaintainCity.Values.Text = "修改地区";
            this.btnMaintainCity.CheckedChanged += new System.EventHandler(this.Btn_CheckedChanged);
            this.btnMaintainCity.Click += new System.EventHandler(this.BtnMaintainCity_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(186, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(820, 472);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 472);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 18);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Ebrima", 8F);
            this.label1.Location = new System.Drawing.Point(2, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 5;
            this.label1.Values.Text = "准备就绪.";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(186, 472);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(820, 18);
            this.panel4.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 490);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "世颜网后台维护系统 ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private KryptonCheckButton btnMaintainADs;
        private KryptonCheckButton btnMaintaindBrand;
        private KryptonCheckButton btnMaintainCommodity;
        private KryptonCheckButton btnMaintainCommodityType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private KryptonLabel label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private KryptonCheckButton btnMaintainEx;
        private KryptonCheckButton btnMaintainCity;
        private KryptonCheckButton kryptonCheckButton1;
        private KryptonCheckButton btnOrderManager;
    }
}

