using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private  void outPut(string log)
        {
            if(textBox1.GetLineFromCharIndex(textBox1.Text.Length)>100)
                {
                textBox1.Text = "";
            }
            textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss   "+log+"\r\n"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                outPut("进度进行中 ["+progressBar1.Value.ToString()+"/"+progressBar1.Maximum+"].....");
            }
            else
            {
                outPut("进度已完成");
                timer1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outPut("进度开始");
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            timer1.Enabled = true;
        }
    }
}
