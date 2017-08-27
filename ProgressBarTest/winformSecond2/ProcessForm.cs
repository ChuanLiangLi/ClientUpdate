using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformSecond2
{
    public partial class ProcessForm : Form
    {
        private BackgroundWorker backgroundWorker1;
        public ProcessForm( BackgroundWorker backgroundWorker1)
        {
            InitializeComponent();
            this.backgroundWorker1 = backgroundWorker1;
            this.backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            this.backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }
        //又执行啦这个方法
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();//执行完之后，直接关闭页面
            //MessageBox.Show(this,"执行完成");
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            this.btnCancle.Enabled = false;
            this.Close();
        }
    }
}
