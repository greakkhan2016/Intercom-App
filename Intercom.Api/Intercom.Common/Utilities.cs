using Intercom.Common.Interface;
using System;

namespace Intercom.Common
{
    public class Utilities: IUtilities
    {
        /// <summary>
        /// Calculates distance from dublin office to customers home
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public double CalculateDistanceBetweenTwoLocations(double Latitude, double Longitude, double Latitude1,double Longtitude1)
        {
            double theta = Longitude - Longtitude1;
            double distancebetweentwolocations = Math.Sin(Deg2rad(Latitude)) * Math.Sin(Deg2rad(Latitude1))
                + Math.Cos(Deg2rad(Latitude)) * Math.Cos(Deg2rad(Latitude1)) * Math.Cos(Deg2rad(theta));
            distancebetweentwolocations = Math.Acos(distancebetweentwolocations);
            distancebetweentwolocations = Rad2deg(distancebetweentwolocations);
            distancebetweentwolocations = distancebetweentwolocations * 60 * 1.1515;
            distancebetweentwolocations *= 1.609344;
            return distancebetweentwolocations;
        }

        /// <summary>
        ///  This function converts     
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public double Deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        /// <summary>
        ///  This function converts radians to decimal degrees      
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public double Rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
