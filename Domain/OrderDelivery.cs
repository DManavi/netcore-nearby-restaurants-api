using MongoDB.Driver.GeoJsonObjectModel;

namespace NearbyRestaurants.Domain
{
    public class OrderDelivery
    {
        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// Where to deliver
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Location on the map
        /// </summary>
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; private set; }

        /// <summary>
        /// Delivery notes (e.g. Name of the person might be different)
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        /// Create a new instance of the order delivery
        /// </summary>
        /// <param name="phoneNumber">Which number to call</param>
        /// <param name="address">Where to deliver</param>
        /// <param name="location">Where is the location on the map</param>
        /// <param name="notes">Any extra notes/hints</param>
        /// <returns></returns>
        public static OrderDelivery Create(string phoneNumber, string address, GeoJsonPoint<GeoJson2DGeographicCoordinates> location, string notes) => new OrderDelivery()
        {
            PhoneNumber = phoneNumber,
            Address = address,
            Location = location,
            Notes = notes
        };
    }
}