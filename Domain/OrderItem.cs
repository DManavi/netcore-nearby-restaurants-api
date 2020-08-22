using System.Data;
using MongoDB.Bson;

namespace NearbyRestaurants.Domain
{
    public class OrderItem
    {
        /// <summary>
        /// Which item is it?
        /// </summary>
        public ObjectId ItemId { get; private set; }

        /// <summary>
        /// How many of the item is ordered
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Increase quantity by 1
        /// </summary>
        public void IncreaseQuantity() => this.Quantity++;

        /// <summary>
        /// Decrease quantity by 1
        /// </summary>
        /// <exception cref="ConstraintException"></exception>
        public void DecreaseQuantity()
        {
            if (this.Quantity.Equals(1))
            {
                throw new ConstraintException("Quantity cannot be less than 1.");
            }

            this.Quantity--;
        }

        /// <summary>
        /// Price per unit
        /// </summary>
        public float Price { get; private set; }

        /// <summary>
        /// Notes like add extra sauce or pepper or etc
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        /// Create a new order item
        /// </summary>
        /// <param name="itemId">Item ID (referenced from MenuItem)</param>
        /// <param name="quantity">How many of the item is ordered</param>
        /// <param name="price">Price per unit</param>
        /// <param name="notes">Any extra note/hint? (e.g. add sauce or etc.)</param>
        /// <returns></returns>
        public static OrderItem Create(ObjectId itemId, int quantity, float price, string notes) => new OrderItem()
        {
            ItemId = itemId,
            Quantity = quantity,
            Price = price,
            Notes = notes,
        };
    }
}