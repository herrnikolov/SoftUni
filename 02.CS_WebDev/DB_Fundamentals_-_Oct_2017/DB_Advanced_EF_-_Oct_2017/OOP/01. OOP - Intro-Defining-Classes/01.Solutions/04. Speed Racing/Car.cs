public class Car
{
    public string Model { get; set; }
    public double Fuel { get; set; }
    public double Consumption { get; set; }
    public double DistanceTravelled { get; set; }

    public Car(string model, double fuel, double consumption)
    {
        this.Model = model;
        this.Fuel = fuel;
        this.Consumption = consumption;
        this.DistanceTravelled = 0;
    }


    public bool Move(double distance)
    {
        double fuelNeeded = distance * this.Consumption;
        if (this.Fuel < fuelNeeded)
        {
            return false;
        }
        this.Fuel -= fuelNeeded;
        this.DistanceTravelled += distance;
        return true;
    }
}
