using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MongoDB.Bson;

namespace NearbyRestaurants.Domain
{
    /// <summary>
    /// State of the order
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Order is received
        /// </summary>
        Received = 0,

        /// <summary>
        /// Payment was successful
        /// </summary>
        Processed = 5,

        /// <summary>
        /// Order is ready to be delivered
        /// </summary>
        Ready = 10,

        /// <summary>
        /// Order is successfully delivered
        /// </summary>
        Delivered = 15,

        /// <summary>
        /// Payment was failed
        /// </summary>
        PaymentFailed = 250,

        /// <summary>
        /// The order is canceled
        /// </summary>
        Canceled = 255,
    }

    public class Order
    {
        public ObjectId Id { get; private set; }

        /// <summary>
        /// Which restaurant has received this order?
        /// </summary>
        public ObjectId RestaurantId { get; private set; }

        /// <summary>
        /// Which customer made this order?
        /// </summary>
        public ObjectId CustomerId { get; private set; }

        /// <summary>
        /// Date that the order has taken place
        /// </summary>
        public DateTime Date { get; private set; } = new DateTime().ToUniversalTime();

        /// <summary>
        /// Which items are ordered?
        /// </summary>
        public ICollection<OrderItem> Items { get; private set; }

        /// <summary>
        /// Current state of the order
        /// </summary>
        public OrderDelivery Delivery { get; private set; }

        /// <summary>
        /// Payment
        /// </summary>
        public Payment Payment { get; private set; }

        /// <summary>
        /// Add payment
        /// </summary>
        /// <param name="payment">Payment object</param>
        public void AddPayment(Payment payment)
        {
            if (this.Status != OrderStatus.Received)
            {
                throw new ConstraintException("Cannot add/modify payment.");
            }

            this.Payment = payment;
            this.Status = OrderStatus.Processed;
        }

        /// <summary>
        /// Add unsuccessful payment
        /// </summary>
        /// <param name="payment">Payment info</param>
        public void UnsuccessfulPayment(Payment payment)
        {
            if (this.Status != OrderStatus.Received)
            {
                throw new ConstraintException("Cannot add/modify payment.");
            }

            this.Payment = payment;
            this.Status = OrderStatus.PaymentFailed;
        }

        /// <summary>
        /// Current order status
        /// </summary>
        public OrderStatus Status { get; private set; } = OrderStatus.Received;

        /// <summary>
        /// Change state to ready
        /// </summary>
        public void OrderIsReady()
        {
            if (this.Status != OrderStatus.Processed)
            {
                throw new ConstraintException("Cannot change status to ready.");
            }

            this.Status = OrderStatus.Ready;
        }

        /// <summary>
        /// Change state to delivered
        /// </summary>
        public void OrderDelivered()
        {
            if (this.Status != OrderStatus.Ready)
            {
                throw new ConstraintException("Cannot change status to delivered.");
            }

            this.Status = OrderStatus.Delivered;
        }

        /// <summary>
        /// Change state to canceled
        /// </summary>
        public void OrderCanceled()
        {
            if (this.Status == OrderStatus.Delivered || this.Status == OrderStatus.PaymentFailed ||
                this.Status == OrderStatus.Canceled)
            {
                throw new ConstraintException("Cannot change status to canceled.");
            }

            this.Status = OrderStatus.Canceled;
        }

        /// <summary>
        /// Create a new instance of the order
        /// </summary>
        /// <param name="restaurantId">Restaurant ID</param>
        /// <param name="customerId">Customer ID</param>
        /// <param name="orderItems">Ordered items</param>
        /// <param name="delivery">Delivery information</param>
        /// <returns></returns>
        public static Order Create(ObjectId restaurantId, ObjectId customerId, IEnumerable<OrderItem> orderItems,
            OrderDelivery delivery) => new Order()
        {
            RestaurantId = restaurantId,
            CustomerId = customerId,
            Items = orderItems.ToList(),
            Delivery = delivery,
        };
    }
}