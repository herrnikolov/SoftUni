using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private decimal length;

    public decimal Length
    {
        get { return length; }
        set { length = value; }
    }

    private decimal width;

    public decimal Width
    {
        get { return width; }
        set { width = value; }
    }

    private decimal height;

    public decimal Height
    {
        get { return height; }
        set { height = value; }
    }

    public Box( decimal length, decimal width, decimal height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private decimal GetVolume()
    {
        // Volume = lwh

        decimal result = this.Length * this.Width * this.Height;

        return result;
    }

    private decimal GetLateralSurfaceArea()
    {
        // Lateral Surface Area = 2lh + 2wh

        decimal result = 2 * (this.Length * this.Height + this.Width * this.Height);

        return result;
    }

    private decimal GetSurfaceArea()
    {
        // Surface Area = 2lw + 2lh + 2wh

        decimal result = 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);

        return result;
    }

    public override string ToString()
    {
        var result = $"Surface Area - {this.GetSurfaceArea():f2}{Environment.NewLine}"
                     + $"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}{Environment.NewLine}"
                     + $"Volume - {this.GetVolume():f2}";

        return result;
    }
}