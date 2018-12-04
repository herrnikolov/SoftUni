public abstract class Car : ICar, IElectricCar
{
    private int battery;

    private string color;

    private string model;

    public Car(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public Car(string model, string color, int battery)
        : this(model, color)
    {
        this.Battery = battery;
    }

    public int Battery
    {
        get => this.battery;
        private set => this.battery = value;
    }

    public string Color
    {
        get => this.color;
        private set => this.color = value;
    }

    public string Model
    {
        get => this.model;
        private set => this.model = value;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }
}