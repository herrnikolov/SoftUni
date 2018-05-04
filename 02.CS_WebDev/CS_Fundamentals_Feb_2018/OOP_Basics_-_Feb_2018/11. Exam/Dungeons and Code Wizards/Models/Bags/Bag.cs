using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private int capacity = 100;

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public Bag(int capacity)
        {
            this.Capacity = capacity;
        }
    }
}
