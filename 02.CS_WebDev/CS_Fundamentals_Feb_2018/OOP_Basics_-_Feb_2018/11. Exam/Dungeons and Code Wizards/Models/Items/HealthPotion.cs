using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public class HealthPotion : Item
    {
        public HealthPotion(int weight) : base(weight = 5)
        {
        }

        public void AffectCharacter(Character.Character character)
        {
            //character.Health += 20;
        }
    }
}
