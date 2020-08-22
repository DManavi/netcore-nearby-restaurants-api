using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace NearbyRestaurants.Domain
{
    public class Restaurant
    {
        public ObjectId Id { get; private set; }

        /// <summary>
        /// Name of the restaurant
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Which time slots the restaurant is available 
        /// </summary>
        public ICollection<OpeningHour> OpeningHours { get; private set; }

        /// <summary>
        /// Where the restaurant is located
        /// </summary>
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; private set; }

        /// <summary>
        /// Create a new restaurant
        /// </summary>
        /// <param name="name">Name of the restaurant</param>
        /// <param name="openingHours">Opening hours</param>
        /// <param name="location">Point on the map</param>
        /// <returns>New instance of the restaurant</returns>
        public static Restaurant create(string name, IEnumerable<OpeningHour> openingHours,
            GeoJsonPoint<GeoJson2DGeographicCoordinates> location) => new Restaurant()
        {
            Name = name,
            OpeningHours = openingHours.ToList(),
            Location = location
        };
    }
}