using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using FinalProjectConsoleApp;

namespace FinalProject
{
    class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is BloodBank)
            {
                if (((BloodBank)value).Age > 50)
                {
                    return Brushes.Red;
                }
                else if(((BloodBank)value).Age < 18)
                {
                    return Brushes.Red;
                }
                if (((BloodBank)value).Weight > 200)
                {
                    return Brushes.Red;
                }
                else if (((BloodBank)value).Weight < 45)
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.White;
                }
            }
            else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
