using System;
using System.Collections.Generic;
using System.Text;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double consumption)
        : base(fuelQuantity, consumption + 0.9)
    {
    }
}
