using control_panel.loginpanel;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace control_panel.loading
{
    //ładowanie [Misiek <3]
    public partial class mainloading : Window
    {
        public mainloading()
        {
            InitializeComponent();
            LoadingBackground();
        }

        private readonly Random _random = new Random();
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private void LoadingBackground()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            ProgressText.Text = (string)e.UserState;

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(0, String.Format("Ładowanie zasobów ..."));
            for (int i = 0; i < 11; i++)
            {
                Thread.Sleep(1000);
                worker.ReportProgress((i + 1) * 11, String.Format("Ładowanie zasobów {0}/{1} ...", i + 2, 11));
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            registerpanel loginpanel = new registerpanel();

            ProgressBar.Value = 100;
            ProgressText.Text = "Kończenie ...";
            Thread.Sleep(1000);
            ProgressText.Text = "Przekierowywanie do okna Logowania ...";
            Thread.Sleep(6000);
            Close();

            loginpanel.Show();
        }

        //<Image gif:ImageBehavior.AnimatedSource="E:/control panel/loading/images/anim.gif" HorizontalAlignment="Center" VerticalAlignment="Top" Height="222" Margin="0,20,0,0" Grid.RowSpan="5" >
        //</Image>
    }
}
