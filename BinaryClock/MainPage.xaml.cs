using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BinaryClock.Converter;
using BinaryClock.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BinaryClock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly MainViewModel viewModel = new MainViewModel();
        readonly Task colorUpdateTask;
        readonly DispatcherTimer clock;

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
            colorUpdateTask = BeginColorUpdate(viewModel);
            clock = CreateClock();
        }

        private DispatcherTimer CreateClock()
        {
            var clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromSeconds(1);
            clock.Tick += (o, e) => {
                UpdateViewModelForCurrentTime(viewModel, DateTime.Now);
            };
            clock.Start();
            return clock;
        }

        private void UpdateViewModelForCurrentTime(MainViewModel mainViewModel, DateTime currentTime)
        {
            var seconds = new int[] { currentTime.Second / 10, currentTime.Second % 10 };
            var minutes = new int[] { currentTime.Minute / 10, currentTime.Minute % 10 };
            var hour = new int[] { currentTime.Hour / 10, currentTime.Hour % 10 };

            mainViewModel.TimeData = new List<IEnumerable<bool>>() {
                IntegerToBooleanArrayConverter.ConvertToBools(hour[0], 2),
                IntegerToBooleanArrayConverter.ConvertToBools(hour[1], 4),
                IntegerToBooleanArrayConverter.ConvertToBools(minutes[0], 3),
                IntegerToBooleanArrayConverter.ConvertToBools(minutes[1], 4),
                IntegerToBooleanArrayConverter.ConvertToBools(seconds[0], 3),
                IntegerToBooleanArrayConverter.ConvertToBools(seconds[1], 4)
            };
        }

        private Task BeginColorUpdate(MainViewModel viewModel)
        {
            return Task.Run(async () =>
            {
                int iterations = 0;
                while (true)
                {
                    await Task.Delay(50);
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        viewModel.BackgroundColor = Color.FromArgb(255,
                            (byte)(128 + (int)(Math.Sin(iterations * .01f) * 127)),
                            (byte)(128 + (int)(Math.Sin(iterations * .0125f + 1) * 127)),
                            (byte)(128 + (int)(Math.Sin(iterations * .009f + 1) * 127)));
                    });
                    iterations++;
                }
            });
        }
    }
}
