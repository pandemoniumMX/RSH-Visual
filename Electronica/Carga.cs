using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;


namespace Electronica
{
    public partial class Carga : Form
    {
        public Carga()
        {
            InitializeComponent();
        }

     

        private void Carga_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        //RUN BG STUFF HERE.NO GUI HERE PLEASE
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 75; i <= 100; i++)
            {
                //CHECK FOR CANCELLATION FIRST
                if (backgroundWorker1.CancellationPending)
                {
                    //CANCEL
                    e.Cancel = true;
                }
                else
                {
                    simulateHeavyJob();
                    backgroundWorker1.ReportProgress(i);
                }
            }

        }

        //THIS UPDATES GUI.OUR PROGRESSBAR
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            percentageLabel.Text = e.ProgressPercentage.ToString() + " %";
        }

        //WHEN JOB IS DONE THIS IS CALLED.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                display("You have Cancelled");
                progressBar1.Value = 0;
                percentageLabel.Text = "0";
            }
            else
            {
                display("Listo");
                Close();
            }
        }
        //SIMULATE HEAVY JOB
        private void simulateHeavyJob()
        {
            //SUSPEND THREAD FOR 100 MS
            Thread.Sleep(100);
        }
        //DISPLAY MSG BOX
        private void display(String text)
        {
            MessageBox.Show(text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
