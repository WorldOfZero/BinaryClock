using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace BinaryClock.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Color backgroundColor = Color.FromArgb(255, 0, 0, 255);

        public Color BackgroundColor {
            get { return backgroundColor; }
            set {
                if (backgroundColor != value)
                {
                    backgroundColor = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(BackgroundColor)));
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(BackgroundBrush)));
                    }
                }
            }
        }

        public SolidColorBrush BackgroundBrush
        {
            get {
                return new SolidColorBrush(BackgroundColor);
            }
        }

        private IEnumerable<bool> testData = new[] { false, false, false, false, false, false, true, false };

        public IEnumerable<bool> TestData {
            get { return testData; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
