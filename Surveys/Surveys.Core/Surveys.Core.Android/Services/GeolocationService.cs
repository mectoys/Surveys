using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Locations;
using Surveys.Core.ServicesInterfaces;
using Surveys.Core.Droid.Services;
using Xamarin.Forms;
using Android.Views;
using Android.Widget;

[assembly:Dependency(typeof(GeolocationService))]

namespace Surveys.Core.Droid.Services
{
    public class GeolocationService : IGeolocationService
    {
        private readonly LocationManager
            locationManager = null;

        public GeolocationService()
        {
            locationManager =
                Xamarin.Forms.Forms.Context.GetSystemService(Context.LocationService)
                as LocationManager;
        }

        public Task<Tuple<double, double>> GetCurrentLocationAsync()
        {
            var provider =
                locationManager.GetBestProvider(new Criteria()
                { Accuracy = Accuracy.Fine }, true);

            var location =
                locationManager.GetLastKnownLocation(provider);

            var result = new Tuple<double, double>(location.Latitude, location.Longitude);

            return Task.FromResult(result);
        }
    }
}