using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace BinaryClock.Converter
{
    class BooleanToBrushConverter : IValueConverter
    {
        public Brush ActiveBrush
        {
            get; set;
        }
        public Brush DeactiveBrush
        {
            get; set;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var asBool = value as bool?;
            if (asBool.HasValue)
            {
                return asBool.Value ? ActiveBrush : DeactiveBrush;
            }
            throw new ArgumentException("Value was not a boolean type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
