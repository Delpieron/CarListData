using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarListData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly CarListDbContext context;
        CarList NewCar = new CarList();
        CarList selectedCar = new CarList();


        public MainWindow(CarListDbContext context)
        {
            this.context = context;
            InitializeComponent();
            GetCars();
            NewCarGrid.DataContext = NewCar;
        }


        private void GetCars()
        {
            CarDG.ItemsSource = context.Cars.ToList();
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            context.Cars.Add(NewCar);
            context.SaveChanges();
            GetCars();
            NewCar = new CarList();
            NewCarGrid.DataContext = new CarList();
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.Update(selectedCar);
            context.SaveChanges();
            GetCars();
        }

        private void SelectCarToEdit(object s, RoutedEventArgs e)
        {
            selectedCar = (s as FrameworkElement).DataContext as CarList;
            UpdateCarGrid.DataContext = selectedCar;
        }

        private void DeleteCar(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as CarList;
            context.Cars.Remove(productToDelete);
            context.SaveChanges();
            GetCars();
        }
    }
}
