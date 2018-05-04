using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Bags;

namespace DungeonsAndCodeWizards.Models.Character
{
    public class Warrior : Character
    {
        public Warrior(string name, Faction faction) : base(name, 100, 50, 40, faction)
        {

        }
    }
}