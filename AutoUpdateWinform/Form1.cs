using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoUpdateWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取客户端应用程序及服务器端升级程序的最近一次更新日期 
        /// </summary>
        /// <param name="Dir"></param>
        /// <returns></returns>
        private string GetTheLastUpdateTime(string Dir)
        {
            string LastUpdateTime = "";
            string AutoUpdaterFileName = Dir ;
            try
            {
                //打开xml文件 
                FileStream myFile = new FileStream(AutoUpdaterFileName, FileMode.Open);
                //xml文件阅读器 
                XmlTextReader xml = new XmlTextReader(myFile);
                while (xml.Read())
                {
                    if (xml.Name == "UpdateTime")
                    {
                        //获取升级文档的最后一次更新日期 
                        LastUpdateTime = xml.GetAttribute("date");
                        break;
                    }
                }
                xml.Close();
                myFile.Close();
            }
            catch(Exception ex)
            {

            }
            
            return LastUpdateTime;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string thePreUpdateDate = GetTheLastUpdateTime(Application.StartupPath + "\\AutoUpdater.xml");
            string theLastsUpdateDate = "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8081/config/AutoUpdater.xml");    //创建一个请求示例
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();　　//获取响应，即发送请求
            Stream responseStream = response.GetResponseStream();
            //StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            //XmlTextReader xml = new XmlTextReader(responseStream);
            //while (xml.Read())
            //{
            //    if (xml.Name == "UpdateTime")
            //    {
            //        //获取升级文档的最后一次更新日期 
            //        theLastsUpdateDate = xml.GetAttribute("date");
            //        break;
            //    }
            //}
            byte[] bytes = new byte[1024];
            int realRead = 0;
            using (FileStream fs = new FileStream(Application.StartupPath+"\\update\\update.xml", FileMode.OpenOrCreate))
            {
                while ((realRead = responseStream.Read(bytes, 0, 1024)) != 0)
                {
                    fs.Write(bytes, 0, realRead);
                }

            }
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(Application.StartupPath + "\\update\\update.xml", xrs);
            doc.Load(reader);
          XmlNode node=    doc.SelectSingleNode("//UpdateFileList");
            XmlNodeList nodeList = node.ChildNodes;
            List<string> list = new List<string>();

            foreach (var item in nodeList)
            {
                XmlElement xe = (XmlElement)item;
                list.Add(xe.GetAttribute("FileName"));
            }


            if (thePreUpdateDate != "")
            {
                //如果客户端将升级的应用程序的更新日期大于服务器端升级的应用程序的更新日期 
                if (Convert.ToDateTime(thePreUpdateDate) >= Convert.ToDateTime(theLastsUpdateDate))
                {
                    MessageBox.Show("当前软件已经是最新的，无需更新！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            this.labDownFile.Text = "下载更新文件";
            this.labFileName.Refresh();
            this.btnCancel.Enabled = true;
            //this.progressBar. = 0;
           /// this.progressBarTotal.Position = 0;
           // this.progressBarTotal.Refresh();
            this.progressBar.Refresh();
            //通过动态数组获取下载文件的列表 
           // ArrayList List = GetDownFileList(GetTheUpdateURL(), theFolder.FullName);
          //  string[] urls = new string[List.Count];
           // List.CopyTo(urls, 0);
        }

        public void DownloadFile(string URL, string filename, System.Windows.Forms.ProgressBar prog, System.Windows.Forms.Label label1)
        {
            float percent = 0;
            try
            {
                HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                Stream st = myrp.GetResponseStream();
                Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    label1.Text = "当前补丁下载进度" + percent.ToString() + "%";
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
          //  DownloadFile("http://localhost:1928/WebServer/downloader/123.rar", @"C:\123.rar", progressBar1, label1);
        }
        private static  void FindFoldersAndFiles(string path)
        {
            foreach (string fileName in Directory.GetFiles(path))
            {
                foreach (string dicrectory in Directory.GetDirectories(path))
                {
                    FindFoldersAndFiles(dicrectory);
                }
            }
        }
        static long GetDirectoryLength(string path)
        {
            if (!Directory.Exists(path))
            {
                return 0;
            }

            long size = 0;

            //遍历指定路径下的所有文件
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo fi in di.GetFiles())
            {
                size += fi.Length;
            }

            //遍历指定路径下的所有文件夹
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    size += GetDirectoryLength(dis[i].FullName);
                }
            }

            return size;
        }

        //private void BatchDownload(object data)
        //{
        //    this.Invoke(this.activeStateChanger, new object[] { true, false });
        //    try
        //    {
        //        DownloadInstructions instructions = (DownloadInstructions)data;
        //        //批量下载 
        //        using (BatchDownloader bDL = new BatchDownloader())
        //        {
        //            bDL.CurrentProgressChanged += new DownloadProgressHandler(this.SingleProgressChanged);
        //            bDL.StateChanged += new DownloadProgressHandler(this.StateChanged);
        //            bDL.FileChanged += new DownloadProgressHandler(bDL_FileChanged);
        //            bDL.TotalProgressChanged += new DownloadProgressHandler(bDL_TotalProgressChanged);
        //            bDL.Download(instructions.URLs, instructions.Destination, (ManualResetEvent)this.cancelEvent);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowErrorMessage(ex);
        //    }
        //    this.Invoke(this.activeStateChanger, new object[] { false, false });
        //    this.labFileName.Text = "";
        //    //更新程序 
        //    if (this._Update)
        //    {
        //        //关闭原有的应用程序 
        //        this.labDownFile.Text = "正在关闭程序....";
        //        System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("TIMS");
        //        //关闭原有应用程序的所有进程 
        //        foreach (System.Diagnostics.Process pro in proc)
        //        {
        //            pro.Kill();
        //        }
        //        DirectoryInfo theFolder = new DirectoryInfo(Path.GetTempPath() +"JurassicUpdate"); 
        //    if (theFolder.Exists)
        //        {
        //            foreach (FileInfo theFile in theFolder.GetFiles())
        //            {
        //                //如果临时文件夹下存在与应用程序所在目录下的文件同名的文件，则删除应用程序目录下的文件
        //                if (File.Exists(Application.StartupPath + "\\"+Path.GetFileName(theFile.FullName))) 
        //                File.Delete(Application.StartupPath + "\\" + Path.GetFileName(theFile.FullName));
        //                //将临时文件夹的文件移到应用程序所在的目录下 
        //                File.Move(theFile.FullName, Application.StartupPath + "\\"+Path.GetFileName(theFile.FullName)); 
        //            }
        //        }
        //        //启动安装程序 
        //        this.labDownFile.Text = "正在启动程序....";
        //        System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "TIMS.exe");
        //        this.Close();
        //    }
        //}
    }
}
