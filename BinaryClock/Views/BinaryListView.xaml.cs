using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BinaryClock.Views
{
    public sealed partial class BinaryListView : UserControl
    {
        public static readonly DependencyProperty BinaryDataProperty = DependencyProperty.Register(
            nameof(BinaryData), typeof(IEnumerable<bool>), typeof(BinaryListView), new PropertyMetadata(default(IEnumerable<bool>)));

        public IEnumerable<bool> BinaryData
        {
            get { return (IEnumerable<bool>) GetValue(BinaryDataProperty); }
            set { SetValue(BinaryDataProperty, value); }
        }

        public BinaryListView()
        {
            this.InitializeComponent();
        }


    }
}
