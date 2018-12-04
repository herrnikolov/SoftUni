using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle()
        {

        }
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        private readonly List<Product> trunk;

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();



    }
}
