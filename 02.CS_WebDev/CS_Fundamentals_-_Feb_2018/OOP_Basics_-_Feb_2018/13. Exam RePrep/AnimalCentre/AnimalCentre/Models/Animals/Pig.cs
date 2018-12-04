using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            //Animal type: { animal type} - { animal name} -Happiness: { animal happiness} -Energy: { animal energy}
            return string.Format(base.ToString(), nameof(Pig), Name, happiness, energy);
        }
    }
}
