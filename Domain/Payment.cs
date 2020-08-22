using System;

namespace NearbyRestaurants.Domain
{
    public enum PaymentMethod
    {
        /// <summary>
        /// Credit card
        /// </summary>
        Credit = 0,
        
        /// <summary>
        /// Debit card
        /// </summary>
        Debit = 1,
        
        /// <summary>
        /// Paypal account
        /// </summary>
        Paypal = 2,
        
        /// <summary>
        /// Cash
        /// </summary>
        Cash = 3,
        
        /// <summary>
        /// Unknown payment method
        /// </summary>
        Unknown = 255,
    }

    public enum PaymentStatus
    {
        /// <summary>
        /// Successful payment
        /// </summary>
        Succeed = 0,
        
        /// <summary>
        /// Payment failed
        /// </summary>
        Failed = 255,
    }

    public class Payment
    {
        /// <summary>
        /// Payment status
        /// </summary>
        public PaymentStatus Status { get; private set; }

        /// <summary>
        /// Payment method
        /// </summary>
        public PaymentMethod Method { get; private set; }

        /// <summary>
        /// Payment reference number
        /// </summary>
        public string ReferenceNumber { get; private set; }

        /// <summary>
        /// Description (e.g. the error or other notes)
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// When the payment was performed
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Create a new payment object
        /// </summary>
        /// <param name="status">Payment status</param>
        /// <param name="method">How has it paid?</param>
        /// <param name="referenceNumber">Payment reference number</param>
        /// <param name="description">Payment description</param>
        /// <param name="date">When the payment has taken place?</param>
        public static Payment Create(PaymentStatus status, PaymentMethod method, string referenceNumber,
            string description, DateTime date) => new Payment()
        {
            Status = status,
            Method = method,
            ReferenceNumber = referenceNumber,
            Description = description,
            Date = date,
        };
    }
}