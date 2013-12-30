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

            var dir = AppDomain.CurrentDomain.BaseDirectory;
            string strOutput = "";

            ChangeProgress(20);

            //using (var client = new SshClient(ipBox.Text, "root", pass))
            //{
            //    client.Connect();
            //    ChangeProgress(40);
            //    client.RunCommand("sudo kill -9 SpringBoard");

            //    Thread.Sleep(2000);
            //    ChangeProgress(70);
            //    ChangeProgress(100);
            //}


            using (var client = new SshClient(ipBox.Text, "root", pass))
            {
                ChangeProgress(30);
                client.Connect();
                ChangeProgress(40);
                Thread.Sleep(2000);

                foreach (var Command in command)
                {
                    var cmd = client.RunCommand(Command);
                    Thread.Sleep(500);
                    ChangeProgress(progress.Value + 1);
                    strOutput = strOutput + cmd.Result + "\n";
                }

                var cmd2 = client.RunCommand("sbreload");
                strOutput = strOutput + cmd2.Result;

                ChangeProgress(100);

                client.Disconnect();
            }

            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(dir + @"\log.txt");
                file.WriteLine(strOutput);
                file.Close();
            }
            catch (Exception e)
            { }

            MessageBox.Show("Success!");
        }
    }
}
