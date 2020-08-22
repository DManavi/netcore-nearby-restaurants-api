using System.Data;
using System.Runtime.CompilerServices;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace NearbyRestaurants.Domain
{
    public class Customer
    {
        public ObjectId Id { get; private set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Customer phone number (used in delivery)
        /// </summary>
        public string PhoneNumber { get; private set; }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new NoNullAllowedException(s: "Phone number cannot be null or empty.");
            }

            if (this.PhoneNumber.Equals(phoneNumber))
            {
                throw new ConstraintException(s: "Phone number is not changed.");
            }

            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Default delivery address
        /// </summary>
        public string DeliveryAddress { get; private set; }

        public void UpdateDeliveryAddress(string deliveryAddress)
        {
            if (string.IsNullOrEmpty(deliveryAddress) || string.IsNullOrWhiteSpace(deliveryAddress))
            {
                throw new NoNullAllowedException(s: "Delivery address cannot be null or empty.");
            }

            this.DeliveryAddress = deliveryAddress;
        }

        public void RemoveDeliveryAddress()
        {
            this.DeliveryAddress = string.Empty;
        }

        /// <summary>
        /// Default Delivery location
        /// </summary>
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> DeliveryLocation { get; set; }

        /// <summary>
        /// Update delivery location
        /// </summary>
        /// <param name="deliveryLocation"></param>
        /// <exception cref="NoNullAllowedException"></exception>
        public void UpdateDeliveryLocation(GeoJsonPoint<GeoJson2DGeographicCoordinates> deliveryLocation)
        {
            if (deliveryLocation == null)
            {
                throw new NoNullAllowedException(s: "Delivery location cannot be null.");
            }

            this.DeliveryLocation = deliveryLocation;
        }

        /// <summary>
        /// Remove delivery location
        /// </summary>
        public void RemoveDeliveryLocation()
        {
            this.DeliveryLocation = null;
        }

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="deliveryAddress"></param>
        /// <param name="deliveryLocation"></param>
        /// <returns></returns>
        public static Customer Create(string fullName, string phoneNumber, string deliveryAddress,
            GeoJsonPoint<GeoJson2DGeographicCoordinates> deliveryLocation)
        {
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new NoNullAllowedException(s: "Phone number cannot be null or empty.");
            }

            return new Customer()
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                DeliveryAddress = deliveryAddress,
                DeliveryLocation = deliveryLocation,
            };
        }
    }
}