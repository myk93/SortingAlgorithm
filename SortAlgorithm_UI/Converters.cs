using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SortAlgorithm_UI
{
    class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class ScaleValue : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            // value to scale
            var value = (int)values[0];

            // the maximum values that can be scaled
            var maxNumber = (int)values[1];

            // the number to reach at the higher scale
            // [convert(...,maxNumber,...) == number to reach]
            double numberToReach = (double)values[2];

            return ((double)value / maxNumber) * numberToReach;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ScaleToColor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            // value to scale
            int value = (int)values[0];

            // the maximum values that can be scaled
            int maxNumber = (int)values[1];


            var ratio = ((double)value / maxNumber) * 255;
            var c = Color.FromArgb((byte)ratio, 100,60,255);

            return new SolidColorBrush(c);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
;