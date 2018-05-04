using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Item
    {
        private int weight;

        public int Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        void AffectCharacter(Character.Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");  
            }
            else
            {
              
            }
        }

    }
}
