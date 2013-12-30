using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using Renci.SshNet;

namespace NormalBar
{
    public partial class FixBarForm : Form
    {
        public FixBarForm()
        {
            InitializeComponent();
        }

        private void fixIt_Click(object sender, EventArgs e)
        {
            //New BW so UI don't freeze
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender,
    DoWorkEventArgs e)
        {
            EstablishSshConnection(new string[] { @"for dir in \", @"/Applications/Weather.app \", @"/Applications/MobilePhone.app \", @"/Applications/MobileSlideShow.app \", @"/Applications/Camera.app \", @"/Applications/Calculator.app \", @"/Applications/FaceTime.app \", @"/Applications/MobileSMS.app \", @"/Applications/Passbook.app \", @"/Applications/Videos.app \", @"/Applications/VoiceMemos.app \", @"/Applications/AppStore.app \", "; do", "plutil -key UIViewControllerBasedStatusBarAppearance -value 0 -type bool \"${dir}/Info.plist\"", "done" });
        }

        private delegate void ChangeProgressDelegate(int width);

        private void ChangeProgress(int width)
        {
            if (this.progress.InvokeRequired)
            {
                // This is a worker thread so delegate the task.
                this.progress.Invoke(new ChangeProgressDelegate(this.ChangeProgress), width);
            }
            else
            {
                // This is the UI thread so perform the task.
                this.progress.Value = width;
            }
        }

        public void EstablishSshConnection(string[] command)
        {
            string pass;
            if (passBox.Text == "") pass = "alpine"; else pass = passBox.Text;


            //Current directory
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            ChangeProgress(20);

            //SSH Connection
            using (var client = new SshClient(ipBox.Text, "root", pass))
            {
                ChangeProgress(30);

                client.Connect();
                ChangeProgress(40);

                Thread.Sleep(2000);

                //Commands passed in EstablishSshConnection parameter
                foreach (var Command in command)
                {
                    var cmd = client.RunCommand(Command);
                    Thread.Sleep(500);
                    ChangeProgress(progress.Value + 1);
                }

                //Respring
                client.RunCommand("sbreload");

                ChangeProgress(100);

                client.Disconnect();
            }

            MessageBox.Show("Success!");
        }
    }
}
