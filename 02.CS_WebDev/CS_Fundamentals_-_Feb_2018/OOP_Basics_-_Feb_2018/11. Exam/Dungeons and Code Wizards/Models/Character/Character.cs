using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Bags;

namespace DungeonsAndCodeWizards.Models.Character
{
    public abstract class Character
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");

                }
                name = value;
            }
        }

        private double baseHealth;

        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }

        private double health;

        public double Health
        {
            get { return health; }
            private set { health = value; }
        }


        private double baseArmor;

        public double BaseArmor
        {
            get { return baseArmor; }
            private set { baseArmor = value; }
        }

        private double armor;

        public double Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        private double abilityPoints;

        public double AbilityPoints
        {
            get { return abilityPoints; }
            set { abilityPoints = value; }
        }

        private Bag bag;

        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }

        public Faction faction { get; set; }


        //IsAlive
        private bool isAlive = true;

        public bool IsAlive
        {
            get { return isAlive = true; }
            set { isAlive = value; }
        }


        private double restHealMultiplier = 0.2;

        public double RestHealMultiplier
        {
            get { return restHealMultiplier; }
            set { restHealMultiplier = value; }
        }

        public Character(string name, double health, double armor, double abilityPoints, Faction faction)
        {
            this.name = Name;
            this.baseHealth = BaseHealth;
            this.health = Health;
            this.baseArmor = BaseArmor;
            this.armor = Armor;
            this.abilityPoints = AbilityPoints;
            //this.bag = Bag;
            this.faction = Faction.CSharp;
            this.isAlive = IsAlive;
            this.restHealMultiplier = RestHealMultiplier;
        }
    }
}
