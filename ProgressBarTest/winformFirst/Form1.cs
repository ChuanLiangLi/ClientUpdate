using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //用子线程工作
            new System.Threading.Thread(new System.Threading.ThreadStart(StartDownload)).Start();
        }
        //开始下载
        public void StartDownload()
        {
            Downloader downloader = new Downloader();
            downloader.onDownLoadProgress += new Downloader.dDownloadProgress(downloader_onDownLoadProgress);
            downloader.Start();
        }
        //同步更新UI
        void downloader_onDownLoadProgress(long total, long current)
        {
            //子线程去访问UI控件，不在同一个线程中。
            if (this.InvokeRequired)
            {
                this.Invoke(new Downloader.dDownloadProgress(downloader_onDownLoadProgress), new object[] { total, current });
            }
            else
            {
                this.progressBar1.Maximum = (int)total;
                this.progressBar1.Value = (int)current;
            }
        }
    }
    /// <summary>
    /// 下载类（您的复杂处理类）
    /// </summary>
    public class Downloader
    {
        //委托
        public delegate void dDownloadProgress(long total, long current);
        //事件
        public event dDownloadProgress onDownLoadProgress;
        //开始模拟工作
        public void Start()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (onDownLoadProgress != null)
                    onDownLoadProgress(100, i);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
