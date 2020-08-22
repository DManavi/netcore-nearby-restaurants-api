using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace NearbyRestaurants.Domain
{
    public class Restaurant
    {
        public ObjectId Id { get; set; }

        public string Title { get; set; }

        public ICollection<OpeningHour> OpeningHours { get; set; }

        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Type { get; set; }
    }
}