using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FinalProjectConsoleApp;

namespace FinalProject
{
    class NameRule : ValidationRule
    {
        Program p = new Program();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(p.CheckName(value.ToString())))
            {
                return new ValidationResult(false, "Wrong data");
            }
            return ValidationResult.ValidResult;
        }
    }
}
