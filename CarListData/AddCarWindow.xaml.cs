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
    /// Logika interakcji dla klasy AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        readonly CarListDbContext context;
        CarList NewCar = new CarList();

        public AddCarWindow(CarListDbContext context)
        {
            this.context = context;
            InitializeComponent();
            NewCarGrid.DataContext = NewCar;

        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            context.CarList.Add(NewCar);
            context.SaveChanges();
            Close();
            

        }
    }
}
