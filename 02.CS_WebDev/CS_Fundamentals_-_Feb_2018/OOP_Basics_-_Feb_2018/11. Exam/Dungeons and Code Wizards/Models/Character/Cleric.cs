using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Bags;

namespace DungeonsAndCodeWizards.Models.Character
{
    public class Cleric : Character
    {
        public Cleric(string name, Faction faction) : base(name, 50, 25, 40, faction)
        {

        }
    }
}
