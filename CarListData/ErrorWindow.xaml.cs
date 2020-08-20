using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarListData
{
    /// <summary>
    /// Logika interakcji dla klasy ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void CloseErrorWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void ErrorText(string message)
        {
            ErrorMessage.Inlines.Add(new Run(message));
        }
    }
}
