using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformForth
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(int vMax)
        {
            InitializeComponent();
            this.progressBar1.Maximum = vMax;
        }
        public bool Increase(int value,string info)
        {
            if (value >= 0)
            {
                //progressBar1.Value = value;
                if (progressBar1.Value  <= progressBar1.Maximum)
                {
                    progressBar1.Value = value;
                    this.textBox1.AppendText(info);
                    Application.DoEvents();
                    progressBar1.Update();
                    progressBar1.Refresh();
                    this.textBox1.Update();
                    this.textBox1.Refresh();
                    return true;

                }
                else
                {
                    progressBar1.Value = progressBar1.Maximum;
                    this.textBox1.AppendText(info);
                    return false;
                }
            }
            return false;
        }
    }
}
