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
        }


        public void GetCars()
        {
            CarDG.ItemsSource = context.CarList.ToList();
        }

        private void UpdateCar(object s, RoutedEventArgs e)
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
            context.CarList.Remove(productToDelete);
            context.SaveChanges();
            GetCars();
        }

        private void AddCarWindow(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow(context);
            addCarWindow.Show();
        }

        private void RefreshGrid(object sender, RoutedEventArgs e)
        {
            GetCars();
        }

        private void OpenProgressBarWindow(object sender, RoutedEventArgs e)
        {
            ProgresBarWindow progresBarWindow = new ProgresBarWindow();
            progresBarWindow.Show();
        }
    }
}
