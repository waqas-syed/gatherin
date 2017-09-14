using Gatherin.Common;

namespace Gatherin.Domain.Model.GatherinAggregate
{
    /// <summary>
    /// Contains the Latitude, Longitude and Area
    /// </summary>
    public class Location
    {
        private decimal _latitude;
        private decimal _longitude;
        private string _area;

        /// <summary>
        /// Initialize the location with latitude, longitude and area
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="area"></param>
        public Location(decimal latitude, decimal longitude, string area)
        {
            Latitude = latitude;
            Longitude = longitude;
            Area = area;
        }

        /// <summary>
        /// Latitude
        /// </summary>
        public decimal Latitude
        {
            get { return _latitude; }
            private set
            {
                Assertion.AssertDecimalNotZero(value);
                _latitude = value;
            }
        }

        /// <summary>
        /// Longitude
        /// </summary>
        public decimal Longitude
        {
            get { return _longitude; }
            private set
            {
                Assertion.AssertDecimalNotZero(value);
                _longitude = value;
            }
        }

        /// <summary>
        /// Area
        /// </summary>
        public string Area
        {
            get { return _area; }
            set
            {
                Assertion.AssertStringNotNullorEmpty(value);
                _area = value;
            }
        }
    }
}
