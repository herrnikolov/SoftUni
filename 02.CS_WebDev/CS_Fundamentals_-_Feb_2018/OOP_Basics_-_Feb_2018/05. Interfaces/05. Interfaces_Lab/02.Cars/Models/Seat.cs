using System.Text;

public class Seat : Car
{
    public Seat(string model, string color)
        : base(model, color)
    {
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{this.Color} {this.GetType()} {this.Model}");
        builder.AppendLine(this.Start());
        builder.Append(this.Stop());
        return builder.ToString();
    }
}