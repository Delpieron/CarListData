using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace CarListData
{
    public class Validator
    {
        public bool CarAddValidator(string data, int requiredLenght)
        {
            return data.Length == requiredLenght ? true : false;            
        }
        
    }
}
