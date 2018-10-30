using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ghanta.Views
{
    /// <summary>
    /// This page uses Accelerometer functionality of the device to display 
    /// Ghanta (bell) image and rotate it according to the angle of device rotation
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GhantaPage : ContentPage
	{
        /// <summary>
        /// This variable sets the speed of the Accelerometer updates
        /// </summary>
        SensorSpeed speed = SensorSpeed.Fastest;

		public GhantaPage ()
		{
			InitializeComponent ();

            Accelerometer.ReadingChanged += AccelerometerReadingChanged;

		}

        /// <summary>
        /// Start Accelerometer when page is being viewed
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Accelerometer.Start(speed);
        }

        /// <summary>
        /// Stop Accelerometer when page is not being viewed
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.Stop();
        }

        /// <summary>
        /// This function executes whenever Accelerometer reading is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Use this variable to get rotation details</param>
        private void AccelerometerReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            
        }
    }
}