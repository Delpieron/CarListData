using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    /// Logika działania Paska postępu
    /// </summary>
    public partial class ProgresBarWindow : Window
    {
        public bool CancelTask { get; set; }
        public ProgresBarWindow()
        {
            InitializeComponent();
            CancelTask = false;
        }

        private async void Window_ContentRenderedAsync(object sender, EventArgs e)
        {
            await ProgressAsync();
        }
        async Task ProgressAsync()
        {
            for (int i = 0; i <= 100; i++)
            {
                await Task.Delay(10);
                Pbar.Value = i;
                if (CancelTask == true)
                    Close();
            }
            this.cancel.Content = "zamknij";

        }
        private void CancelTaskButton(object sender, RoutedEventArgs e)
        {
            CancelTask = true;
            if (Pbar.Value == 100)
            {
                this.Close();
            }
        }
    }
}
