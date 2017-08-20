using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("程序需要更新");//AutoUpdateWinform.exe

            //    string updateExePath = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdateWinform.exe";
            //try
            //{
            //    System.Diagnostics.Process myPross = System.Diagnostics.Process.Start(updateExePath);
            //    Application.Exit();
            //}
            //catch(Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            #region 更新提示/判断是否自动更新
            BackgroundWorker updateWorker = new BackgroundWorker();
            updateWorker.DoWork += new DoWorkEventHandler(updateWorker_DoWork);
            updateWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(updateWorker_RunWorkerCompleted);
                    updateWorker.RunWorkerAsync();
            }
            #endregion
        #region 更新提示线程处理
        private void updateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageUtil.ShowTips("版本更新完成");
        }

        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                        Process.Start(Path.Combine(Application.StartupPath, "AutoUpdateWinform.exe"), "121");
                        Application.Exit();
            }
            catch (Exception ex)
            {
                //MessageUtil.ShowError(ex.Message);
            }
        }
        #endregion
        //      if (VersionHelper.HasNewVersion(oausServerIP,oausServerPort)) 
        //{      
        //     string updateExePath = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdater\\AutoUpdater.exe";
        //      System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start(updateExePath);     
        //     ......//退出当前进程  
        //}
    }
}
