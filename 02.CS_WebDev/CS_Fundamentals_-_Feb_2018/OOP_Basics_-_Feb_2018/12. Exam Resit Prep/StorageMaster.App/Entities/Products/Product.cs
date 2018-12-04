using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public abstract class Product
    {
        public Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        private double price;

        public double Price
        {
            get { return price; }
            set {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value; }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}
