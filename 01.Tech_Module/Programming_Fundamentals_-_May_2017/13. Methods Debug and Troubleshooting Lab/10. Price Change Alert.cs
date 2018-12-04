using System;

class PriceChangeAlert
{
    static void Main()
    {
        var numberOfPrices = int.Parse(Console.ReadLine());
        var significanceThreshold = double.Parse(Console.ReadLine());
        var lastPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPrices - 1; i++)
        {
            double price = double.Parse(Console.ReadLine());
            double difference = Percentage(lastPrice, price);

            bool isSignificantDifference = hasDifference(difference, significanceThreshold);

            string message = GetMessage(price, lastPrice, difference, isSignificantDifference);
            lastPrice = price;

            Console.WriteLine(message);
        }
    }

    private static string GetMessage(double newestPrice, double lastPrice, double difference, bool hasSignificantDifference)
    {
        string message = "";
        if (difference == 0)
        {
            message = string.Format($"NO CHANGE: {newestPrice}");
        }
        else if (!hasSignificantDifference)
        {
            message = string.Format($"MINOR CHANGE: {lastPrice} to {newestPrice} ({difference * 100:F2}%)");
        }
        else if (hasSignificantDifference && difference > 0)
        {
            message = string.Format($"PRICE UP: {lastPrice} to {newestPrice} ({difference * 100:F2}%)");
        }
        else if (hasSignificantDifference && difference < 0)
        {
            message = string.Format($"PRICE DOWN: {lastPrice} to {newestPrice} ({difference * 100:F2}%)");
        }

        return message;
    }

    private static bool hasDifference(double difference, double threshold)
    {
        if (Math.Abs(difference) >= threshold)
        {
            return true;
        }
        return false;
    }

    private static double Percentage(double oldPrice, double newPrice)
    {
        double percent = (newPrice - oldPrice) / oldPrice;
        return percent;
    }
}