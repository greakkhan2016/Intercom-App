using Intercom.Common;
using Xunit;

namespace Intercom.Unit.Tests.Intercom.UtilitiesTests
{
    public class UtilitiesTests
    {
        [Theory]
        [InlineData(1, 0.017453292519943295)]
        [InlineData(55, 0.9599310885968813)]
        [InlineData(80, 1.3962634015954636)]
        public void Deg2rad_decimaldegrees_returns_radians(double test, double expected)
        {
            var _sut = new Utilities();
            var result = _sut.Deg2rad(test);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(1, 57.29577951308232)]
        [InlineData(55, 3151.2678732195272)]
        [InlineData(80, 4583.662361046586)]
        public void Rad2deg_radians_returns_decimaldegrees(double test, double expected)
        {
            var _sut = new Utilities();
            var result = _sut.Rad2deg(test);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(53.3729581 ,- 6.3624744 , 53.2451022, -6.238335, 16.435297588378663)]
        [InlineData(53.3729581, -6.3624744, 54.080556, -6.361944,  78.67751889500109)]
        [InlineData(53.3729581, -6.3624744, 53.008769, -6.1056711, 43.959598556961545)]

        public void DistanceFromOffice_returns_distance(double Latitude, double Longitude, double Latitude1, double Longtitude1, double expected)
        {
            var _sut = new Utilities();
            var result = _sut.CalculateDistanceBetweenTwoLocations(Latitude, Longitude, Latitude1, Longtitude1);
            Assert.Equal(result, expected);
        }
    }
}


