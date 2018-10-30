using Microsoft.AppCenter.Crashes;
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
        SensorSpeed speed = SensorSpeed.Normal;

		public GhantaPage ()
		{
			InitializeComponent ();
        }

        /// <summary>
        /// Start Accelerometer when page is being viewed
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                Accelerometer.ReadingChanged += AccelerometerReadingChanged;
                Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Crashes.TrackError(fnsEx, new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>());
            }
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
            if (e.Reading.Acceleration.X > 0.1 || e.Reading.Acceleration.X < -0.1)
            {
                GhantaImage.Rotation = e.Reading.Acceleration.X * 30;
            }
            else
            {
                GhantaImage.RotationX = 0;
                GhantaImage.RotationY = 0;
                GhantaImage.Rotation = 0;
            }
        }
    }
}