using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarTestSecond
{
    /// <summary>
    /// https://yq.aliyun.com/ziliao/4885
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       private  void ProgressBar_Value(int val)
        {
            progressBar1.Value = val;
            label1.Text = val.ToString() + "%";
        }
        private void DownloadFile(string url,string savefile,Action<int> downloadProgresschanged,Action downloadFileCompleted)
        {
            WebClient client = new WebClient();
            if(downloadProgresschanged!=null)
            {
                client.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs e)
                  {
                      this.Invoke(downloadProgresschanged,e.ProgressPercentage);
                  };
            }
            if(downloadFileCompleted!=null)
            {
                client.DownloadFileCompleted += delegate (object sender, AsyncCompletedEventArgs e)
                  {
                      this.Invoke(downloadFileCompleted);

                  };
            }
            client.DownloadFileAsync(new Uri(url),savefile);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DownloadFile("http://localhost:8088/update.zip",@"F:\update.zip",ProgressBar_Value,null);
        }
    }
}
