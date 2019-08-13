using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProject
{
    class AgeRule : ValidationRule
    {
        long min;
        long max;

        public long Min { get => min; set => min = value; }
        public long Max { get => max; set => max = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long numVal = 0;
            if (!long.TryParse(value.ToString(), out numVal))
            {
                return new ValidationResult(false, "Wrong data");
            }

            if (numVal < min || numVal > max)
            {
                return new ValidationResult(false, "Out of Range");
            }

            return ValidationResult.ValidResult;
        }
    }
}
