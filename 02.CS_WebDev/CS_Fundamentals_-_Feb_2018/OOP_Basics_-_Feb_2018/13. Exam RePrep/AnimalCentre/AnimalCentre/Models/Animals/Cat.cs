using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            //Animal type: { animal type} - { animal name} -Happiness: { animal happiness} -Energy: { animal energy}
            return string.Format(base.ToString(), nameof(Cat), Name, happiness, energy);
        }
    }
}
