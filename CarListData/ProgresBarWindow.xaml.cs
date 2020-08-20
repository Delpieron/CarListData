using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarListData
{
    /// <summary>
    /// Logika interakcji dla klasy ProgresBarWindow.xaml
    /// </summary>
    public partial class ProgresBarWindow : Window
    {
        private bool isWorking { get; set; }
        public ProgresBarWindow()
        {
            InitializeComponent();
            isWorking = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, EventArgs e)
        {
                for (int i = 0; i < 100; i++)
                {
                    (sender as BackgroundWorker).ReportProgress(i);
                    Thread.Sleep(100);
                    if (!isWorking)
                    {
                    break;
                    
                    }
                }
        } 

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            Pbar.Value = e.ProgressPercentage;
        }

        private void CancelProgress(object sender, RoutedEventArgs e)
        {
            isWorking = false;
            Close();
        }
    }
}
