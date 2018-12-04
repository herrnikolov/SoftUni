using System.Text;

public class Tesla : Car
{
    public Tesla(string model, string color, int battery)
        : base(model, color, battery)
    {
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{this.Color} {this.GetType()} {this.Model} with {this.Battery} Batteries");
        builder.AppendLine(this.Start());
        builder.Append(this.Stop());
        return builder.ToString();
    }
}