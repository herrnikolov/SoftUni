using System;

namespace _15._Drawing_Tool
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();

            DrawingTool drawingTool = null;

            if (figure == "Square")
            {
                var size = int.Parse(Console.ReadLine());
                var square = new Square(size);
                drawingTool = new DrawingTool(square);
            }
            else if (figure == "Rectangle")
            {
                var width = int.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                var rectangle = new Rectangle(width, height);
                drawingTool = new DrawingTool(rectangle);
            }

            drawingTool.Draw();
        }
    }
}
