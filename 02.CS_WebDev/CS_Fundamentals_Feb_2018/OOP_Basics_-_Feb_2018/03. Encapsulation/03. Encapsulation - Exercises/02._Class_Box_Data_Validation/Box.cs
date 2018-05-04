using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private const string errorMsg = "{0} cannot be zero or negative.";

    private decimal length;
    private decimal width;
    private decimal height;

    public decimal Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(errorMsg, nameof(this.Length)));
            }
            this.length = value;
        }
    }
    public decimal Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(errorMsg, nameof(this.Width)));
            }
            this.width = value;
        }
    }
    public decimal Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(errorMsg, nameof(this.Height)));
            }
            this.height = value;
        }
    }

    public Box(decimal length, decimal width, decimal height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private decimal GetVolume()
    {
        decimal result = this.Length * this.Width * this.Height;

        return result;
    }

    private decimal GetLateralSurfaceArea()
    {
        decimal result = 2 * (this.Length * this.Height + this.Width * this.Height);

        return result;
    }

    private decimal GetSurfaceArea()
    {
        decimal result = 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);

        return result;
    }

    public override string ToString()
    {
        var result = $"Surface Area - {this.GetSurfaceArea():F2}{Environment.NewLine}"
                     + $"Lateral Surface Area - {this.GetLateralSurfaceArea():F2}{Environment.NewLine}"
                     + $"Volume - {this.GetVolume():F2}";

        return result;
    }
}