using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformSecond2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();//运行backgroundWorker
            ProcessForm form = new ProcessForm(this.backgroundWorker1);
            form.ShowDialog(this);
            form.Close();
        }
        //先执行这个方法
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);

            }
            else if (e.Cancelled)
            {

            }
            else
            {


            }

        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                worker.ReportProgress(i);
                if (worker.CancellationPending)// 如果用户取消则跳出处理数据代码 
                {
                    e.Cancel = true;
                    break;
                }

            }
        }
    }
}
