using System;
using System.Collections.Generic;
using System.Text;

namespace CarListData
{
    /// <summary>
    /// Lista właściwości przedmiotów w tabeli
    /// </summary>
    public class CarList
    {
        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Vin { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
