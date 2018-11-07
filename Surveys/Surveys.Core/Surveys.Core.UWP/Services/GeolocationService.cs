using Surveys.Core.UWP.Services;
using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Surveys.Core.ServicesInterfaces;

[assembly:Dependency(typeof(GeolocationService))]
namespace Surveys.Core.UWP.Services
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<Tuple<double, double>> GetCurrentLocationAsync()
        {
            var geolocator = new Geolocator();
            var position = await
                geolocator.GetGeopositionAsync();
            var result = new Tuple<double,
                double>(position.Coordinate.Point.Position.Latitude,
                position.Coordinate.Point.Position.Longitude);

            return result;
        }
    }
}
