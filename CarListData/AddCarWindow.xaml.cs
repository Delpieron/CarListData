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
    /// Logika działania okna dodawania samochodu
    /// </summary>
    public partial class AddCarWindow : Window
    {
        readonly CarListDbContext context;
        readonly CarList NewCar = new CarList();
        Validator validator = new Validator();

        public AddCarWindow(CarListDbContext context)
        {
            this.context = context;
            InitializeComponent();
            NewCarGrid.DataContext = NewCar;

        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            ErrorWindow errorWindow = new ErrorWindow();

            //jezeli vin lub numer rejestracyjny jest niepoprawny wyswietla okno z bledem

            if (NewCar.Vin == null || NewCar.RegistrationNumber == null)
            {
                errorWindow.Show();
                errorWindow.ErrorMessage.Inlines.Add(new Run("vin and registration number cannot be empty!"));
            }
            else
            {
                context.CarList.Add(NewCar);

                //validator sprawdza czy dlugosc podanych danych jest poprawna

                bool IsVinValid = validator.CarAddValidator(NewCar.Vin, 17);
                bool IsRegisterNumberValid = validator.CarAddValidator(NewCar.RegistrationNumber, 7);

                //wykonywana jest akcja w zaleznosci od tego czy dlugosc danych jest poprawna

                if (IsVinValid == true && IsRegisterNumberValid == true)
                {
                    context.SaveChanges();
                    MainWindow main = new MainWindow(context);
                    main.Show();
                    Close();
                }

                else if (IsVinValid)
                {
                    errorWindow.Show();
                    errorWindow.ErrorMessage.Inlines.Add(new Run("Registration number requires 7 characters!"));
                    registrationNumber.Clear();                    
                }

                else if (IsRegisterNumberValid)
                {
                    errorWindow.Show();
                    errorWindow.ErrorMessage.Inlines.Add(new Run("Vin number requires 17 characters!"));
                    vin.Clear();
                }

                else
                {
                    errorWindow.Show();
                    errorWindow.ErrorMessage.Inlines.Add(new Run("Registration number requires 7 characters, " +
                        "and vin number requires 17 characters!"));
                    vin.Clear();
                    registrationNumber.Clear();
                }
            }
            
        }
    }
}
