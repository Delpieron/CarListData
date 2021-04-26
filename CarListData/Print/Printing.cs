using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows;
using System.Linq;

namespace CarListData
{
    public class Printing
    {
        private static int count = 1;
        private Font printFont;
        private readonly CarListDbContext context;

        public Printing(CarListDbContext context)
        {
            this.context = context;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            List<CarList> cars = context.CarList.ToList();

            // Calculate the number of lines per page.
            float linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            string titleLine = "Car List Data Table";

            float titlePosX = ev.MarginBounds.Left + (ev.MarginBounds.Width / 2) - (5*titleLine.Length);
            ev.Graphics.DrawString(titleLine, printFont, Brushes.Black, titlePosX, topMargin, new StringFormat());
            foreach (var car in cars)
            {   
            if (count > linesPerPage)
                {
                    ev.HasMorePages = true;
                    return;
                }
                
                string line = car.CarId + "  |  " + car.RegistrationNumber + "  |  " + car.Vin + "  |  " + car.Model + "  |  " + car.Brand;

                float yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            ev.HasMorePages = false;

        }
        public void Print()
        {
            try
            {
                printFont = new Font("Arial", 65);
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}