using System;
using DomainCrudCommon;
using Work4Jesus.ValueModels;

namespace Work4Jesus.Domain
{
    /// <summary>
    /// Christian Events
    /// </summary>
    public class Cevent : Entity
    {
        private GpsPosition _gpsPosition;

        public string GpsPositionRawData;
        public int Owner { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public DateTime StartOfEvent { get; set; }
        public DateTime EndOfEvent { get; set; }

        public string Adress { get; set; }

        /// <summary>
        ///     In order to add complementary indication of the adress
        /// </summary>
        public string AdressComplement { get; set; }

        public float Price { get; set; }
        public string Description { get; set; }

        public string Picture { get; set; }
        public string ChurchLink { get; set; }
        public string YoutubeLink { get; set; }

        public string KeyWord { get; set; }

        public Cevent()
        {
            ValueRegister.RegisterReflect(GetPropertyName(() => GpsPositionRawData), load => _gpsPosition = load,
                () => _gpsPosition);
        }

        //public DateTime 

        public void SetGpsPosition(float longitute, float latitude)
        {
            _gpsPosition = new GpsPosition(longitute, latitude);
        }
        public GpsPosition GetGpsPosition()
        {
            return _gpsPosition;
        }
    }
}