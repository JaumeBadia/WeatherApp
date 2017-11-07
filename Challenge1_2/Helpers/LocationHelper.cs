using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Challenge1_2.Helpers
{
    public class LocationHelper
    {
		public async static Task<Position> GetCurrentLocationAsync()
		{

            Position location = new Position();

            var geolocator = CrossGeolocator.Current;

            try
            {
                geolocator.DesiredAccuracy = 100;
                location = await geolocator.GetPositionAsync();
            }
            catch (Exception EX)
            {
                System.Diagnostics.Debug.WriteLine(EX.Message);
            }

            return location;
		}
    }
}
