using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        Stream bellSound;
        Plugin.SimpleAudioPlayer.ISimpleAudioPlayer player;

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
                var assembly = typeof(App).GetTypeInfo().Assembly;
                bellSound = assembly.GetManifestResourceStream("Ghanta.Audio." + "Bell.mp3");
                player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(bellSound);
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
            bellSound = null;
            player = null;
        }

        /// <summary>
        /// This function executes whenever Accelerometer reading is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Use this variable to get rotation details</param>
        private void AccelerometerReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            if (e.Reading.Acceleration.X > 0.45 || e.Reading.Acceleration.X < -0.45)
            {
                GhantaImage.Rotation = e.Reading.Acceleration.X * 30;
                if (!player.IsPlaying)
                {
                    player.Play();
                }

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