namespace Intercom.Common.Interface
{
    public interface IUtilities
    {
        public double CalculateDistanceBetweenTwoLocations(double Latitude, double Longitude, double Latitude1, double Longtitude1);
        public double Deg2rad(double deg);
        public double Rad2deg(double rad);
    }
}
