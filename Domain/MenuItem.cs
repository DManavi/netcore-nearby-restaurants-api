using System.Security;
using MongoDB.Bson;

namespace NearbyRestaurants.Domain
{
    public class MenuItem
    {
        public ObjectId Id { get; private set; }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Description of the item (e.g. Ingredients in food)
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Category (e.g. Starter, drink, etc)
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// Change the menu item category
        /// </summary>
        /// <param name="newCategory">Name of the new category</param>
        public void ChangeCategory(string newCategory)
        {
            if (string.IsNullOrEmpty(newCategory) || string.IsNullOrWhiteSpace(newCategory))
            {
                throw new VerificationException(message: "Category cannot be null, empty or whitespace.");
            }

            if (this.Category.Equals(newCategory))
            {
                throw new VerificationException(message: "Category is not changed.");
            }

            this.Category = newCategory;
        }

        /// <summary>
        /// Price per unit
        /// </summary>
        public float Price { get; private set; }

        public void UpdatePrice(float price) => this.Price = price;

        /// <summary>
        /// Is the item available
        /// </summary>
        public bool Available { get; private set; }

        public void MakeAvailable() => this.Available = true;
        public void MakeUnAvailable() => this.Available = false;

        /// <summary>
        /// Create a new instance of the menu item
        /// </summary>D
        /// <param name="name">Name of the item</param>
        /// <param name="description">Describe the menu entry</param>
        /// <param name="category">Which category does the item belong to</param>
        /// <param name="price">Price per unit</param>
        /// <param name="available">Is this item available</param>
        /// <returns>Instance of the menu item</returns>
        public static MenuItem create(string name, string description, string category, float price, bool available) =>
            new MenuItem()
            {
                Name = name,
                Description = description,
                Category = category,
                Price = price,
                Available = available
            };
    }
}