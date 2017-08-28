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

namespace winformForth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ProgressForm myProgressBar = null;
        private delegate bool IncreaseHandle(int value,string info);
        private IncreaseHandle myIncrease = null;
        private int max = 100;
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(ThreadFun));
            th.Start();
        }
        private void ThreadFun()
        {
            MethodInvoker mi = new MethodInvoker(ShowProcessBar);
            //ShowProcessBar();
            this.BeginInvoke(mi);
            Thread.Sleep(100);
            object objReturn = null;
            for (int i = 0; i < max; i++)
            {
                objReturn = this.Invoke(this.myIncrease,new object[] {i,i.ToString()+"\r\n"});
                Thread.Sleep(50);
            }
        }
        private void ShowProcessBar()
        {
            myProgressBar = new ProgressForm(max);
            myIncrease = new IncreaseHandle(myProgressBar.Increase);
            myProgressBar.ShowDialog();
            myProgressBar = null;

        }
    }
}
