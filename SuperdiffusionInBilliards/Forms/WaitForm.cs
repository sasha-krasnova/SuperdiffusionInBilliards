using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

delegate void SetTextCallback(double value);
delegate void SetTextCallbackVoid();

namespace SuperdiffusionInBilliards
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
        }

        public void ChangePercentThread(int current, int needed)
        {
            double percent = ((double)current / needed * 100);
            SetPercent(percent);
           
        }

        public void SetPercent(double value)
        {
            if (this.percent.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetPercent);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.progressBar.Value = Convert.ToInt32(Math.Floor(value));
            }
        }

        public void CloseThread()
        {
            if (this.percent.InvokeRequired)
            {
                SetTextCallbackVoid d = new SetTextCallbackVoid(CloseThread);
                this.Invoke(d, new object[] {});
            }
            else
            {
                Close();
            }
        }

        private void WaitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
