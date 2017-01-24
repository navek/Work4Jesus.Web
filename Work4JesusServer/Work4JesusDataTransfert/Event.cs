using System;

namespace Work4JesusDataTransfert
{
    public class Event
    {
        public int Id { get; set; }

        /// <summary>
        ///     title of the event
        /// </summary>
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public DateTime StartOfEvent { get; set; }
        public DateTime EndOfEvent { get; set; }

        public string Adress { get; set; }
        public GpsPosition Gps { get; set; }

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
    }
}