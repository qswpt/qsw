﻿namespace QSWMaintain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMaintainADs = new System.Windows.Forms.Button();
            this.btnMaintaindBrand = new System.Windows.Forms.Button();
            this.btnMaintainCommodity = new System.Windows.Forms.Button();
            this.btnMaintainCommodityType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(253, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 800);
            this.panel1.TabIndex = 0;
            // 
            // btnMaintainADs
            // 
            this.btnMaintainADs.Location = new System.Drawing.Point(24, 22);
            this.btnMaintainADs.Name = "btnMaintainADs";
            this.btnMaintainADs.Size = new System.Drawing.Size(190, 50);
            this.btnMaintainADs.TabIndex = 1;
            this.btnMaintainADs.Text = "修改广告位";
            this.btnMaintainADs.UseVisualStyleBackColor = true;
            this.btnMaintainADs.Click += new System.EventHandler(this.BtnMaintainADs_Click);
            // 
            // btnMaintaindBrand
            // 
            this.btnMaintaindBrand.Location = new System.Drawing.Point(25, 97);
            this.btnMaintaindBrand.Name = "btnMaintaindBrand";
            this.btnMaintaindBrand.Size = new System.Drawing.Size(190, 50);
            this.btnMaintaindBrand.TabIndex = 2;
            this.btnMaintaindBrand.Text = "修改品牌";
            this.btnMaintaindBrand.UseVisualStyleBackColor = true;
            this.btnMaintaindBrand.Click += new System.EventHandler(this.BtnMaintaindBrand_Click);
            // 
            // btnMaintainCommodity
            // 
            this.btnMaintainCommodity.Location = new System.Drawing.Point(24, 172);
            this.btnMaintainCommodity.Name = "btnMaintainCommodity";
            this.btnMaintainCommodity.Size = new System.Drawing.Size(190, 50);
            this.btnMaintainCommodity.TabIndex = 2;
            this.btnMaintainCommodity.Text = "修改商品";
            this.btnMaintainCommodity.UseVisualStyleBackColor = true;
            this.btnMaintainCommodity.Click += new System.EventHandler(this.BtnMaintainCommodity_Click);
            // 
            // btnMaintainCommodityType
            // 
            this.btnMaintainCommodityType.Location = new System.Drawing.Point(24, 247);
            this.btnMaintainCommodityType.Name = "btnMaintainCommodityType";
            this.btnMaintainCommodityType.Size = new System.Drawing.Size(190, 50);
            this.btnMaintainCommodityType.TabIndex = 2;
            this.btnMaintainCommodityType.Text = "修改商品类型";
            this.btnMaintainCommodityType.UseVisualStyleBackColor = true;
            this.btnMaintainCommodityType.Click += new System.EventHandler(this.BtnMaintainCommodityType_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 816);
            this.Controls.Add(this.btnMaintainCommodityType);
            this.Controls.Add(this.btnMaintainCommodity);
            this.Controls.Add(this.btnMaintaindBrand);
            this.Controls.Add(this.btnMaintainADs);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "七色网维护系统 ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMaintainADs;
        private System.Windows.Forms.Button btnMaintaindBrand;
        private System.Windows.Forms.Button btnMaintainCommodity;
        private System.Windows.Forms.Button btnMaintainCommodityType;
    }
}

