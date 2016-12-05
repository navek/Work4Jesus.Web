using System.Globalization;
using Commons.Utils.Extensions;
using DomainCrudCommon;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Work4Jesus.ValueModels
{
    public class GpsPosition : ValueObject<GpsPosition>
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public GpsPosition()
        {
        }

        public GpsPosition(float longitude, float latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        protected override bool EqualsCore(GpsPosition other)
        {
            return this.Latitude == other.Latitude && this.Longitude == other.Longitude;
        }

        protected override int GetHashCodeCore()
        {
            return (Longitude + Latitude).ToString(CultureInfo.InvariantCulture).GetStableHashCode();
        }
    }
}