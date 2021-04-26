using System;
using System.Windows;
namespace CarListData
{
    /// <summary>
    /// Logika działania okna dodawania samochodu
    /// </summary>
    public partial class AddCarWindow : Window
    {
        readonly CarListDbContext context;
        readonly CarList NewCar = new CarList();

        public AddCarWindow(CarListDbContext context)
        {
            this.context = context;
            InitializeComponent();
        }
        private void AddCar(object sender, RoutedEventArgs e)
        {            
            string message = CarValidator.CheckLongOfInsertedData(GetUserInput());
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Error", MessageBoxButton.OK);
                return;
            }
            try
            {
                context.CarList.Add(NewCar);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot save changes to database.", "Error", MessageBoxButton.OK);
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            if (string.IsNullOrEmpty(message)) BackToMainWindow(null,null);

        }
        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            string message = "Car added succesfuly";
            MessageBox.Show(message, "Error", MessageBoxButton.OK);
            MainWindow main = new MainWindow(context);
            main.Show();
            Close();
        }
        private CarList GetUserInput() => new CarList()
        {
            RegistrationNumber = registrationNumber.Text,
                Vin = vin.Text,
                Brand = brand.Text,
                Model = model.Text
        };
    }
}
