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

namespace winformSecond
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(Method1)).Start();
        }
        private  void Method2(int n,int s)
        {
            if (this.InvokeRequired)
            {
                this.Invoke( new Mydelete(Method2) ,new object[] { n, s });
            }
            else
            {
                progressBar1.Value = s;
                progressBar1.Maximum = n;
                this.textBox1.AppendText(s.ToString()+"\r\n");
                label1.Text = s.ToString()+"/100";
            }
        }
        public delegate void Mydelete(int n,int s);
        private   void   Method1()
        {
            for (int i = 0; i <=100; i++)
            {
                Method2(100,i);
                Thread.Sleep(100);
            }
        }
    }
}
