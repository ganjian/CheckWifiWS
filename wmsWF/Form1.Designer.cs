namespace wmsWF
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnPing = new System.Windows.Forms.Button();
            this.btnTCPCount = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnInterFaceSummary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "shownotify";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(13, 13);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(75, 23);
            this.btnPing.TabIndex = 0;
            this.btnPing.Text = "ping外部IP";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // btnTCPCount
            // 
            this.btnTCPCount.Location = new System.Drawing.Point(112, 13);
            this.btnTCPCount.Name = "btnTCPCount";
            this.btnTCPCount.Size = new System.Drawing.Size(75, 23);
            this.btnTCPCount.TabIndex = 1;
            this.btnTCPCount.Text = "TCP连接数";
            this.btnTCPCount.UseVisualStyleBackColor = true;
            this.btnTCPCount.Click += new System.EventHandler(this.btnTCPCount_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 42);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(520, 247);
            this.txtInfo.TabIndex = 2;
            // 
            // btnInterFaceSummary
            // 
            this.btnInterFaceSummary.Location = new System.Drawing.Point(204, 12);
            this.btnInterFaceSummary.Name = "btnInterFaceSummary";
            this.btnInterFaceSummary.Size = new System.Drawing.Size(75, 23);
            this.btnInterFaceSummary.TabIndex = 3;
            this.btnInterFaceSummary.Text = "接口摘要";
            this.btnInterFaceSummary.UseVisualStyleBackColor = true;
            this.btnInterFaceSummary.Click += new System.EventHandler(this.btnInterFaceSummary_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 301);
            this.Controls.Add(this.btnInterFaceSummary);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnTCPCount);
            this.Controls.Add(this.btnPing);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Button btnTCPCount;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnInterFaceSummary;
    }
}

