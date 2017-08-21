namespace BlogAutoUpdate
{
    partial class DownloadProgress
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCurrent = new System.Windows.Forms.Label();
            this.progressBarCurrent = new System.Windows.Forms.ProgressBar();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.labelCurrentItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(17, 16);
            this.labelCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(82, 15);
            this.labelCurrent.TabIndex = 0;
            this.labelCurrent.Text = "正在下载：";
            // 
            // progressBarCurrent
            // 
            this.progressBarCurrent.Location = new System.Drawing.Point(19, 35);
            this.progressBarCurrent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarCurrent.Name = "progressBarCurrent";
            this.progressBarCurrent.Size = new System.Drawing.Size(675, 27);
            this.progressBarCurrent.Step = 1;
            this.progressBarCurrent.TabIndex = 1;
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Location = new System.Drawing.Point(20, 84);
            this.progressBarTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(674, 29);
            this.progressBarTotal.Step = 1;
            this.progressBarTotal.TabIndex = 1;
            // 
            // labelCurrentItem
            // 
            this.labelCurrentItem.AutoSize = true;
            this.labelCurrentItem.Location = new System.Drawing.Point(112, 16);
            this.labelCurrentItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentItem.Name = "labelCurrentItem";
            this.labelCurrentItem.Size = new System.Drawing.Size(0, 15);
            this.labelCurrentItem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "总进度：";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(585, 146);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 29);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "取消";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.OnCancel);
            // 
            // DownloadProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 201);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.progressBarTotal);
            this.Controls.Add(this.progressBarCurrent);
            this.Controls.Add(this.labelCurrentItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCurrent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载进度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.ProgressBar progressBarCurrent;
        private System.Windows.Forms.ProgressBar progressBarTotal;
        private System.Windows.Forms.Label labelCurrentItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
    }
}