using System;
using ShapeLibrary;
using System.Numerics;

namespace Lab2Console
{
    public static class Program
    {
        private const int nrRandShapes = 20;
        private static float triangleCircumferenceSum;
        private static float sumAreaShaped;
        private static float volume3DShape;
        private static string largestVolume3DShape = "Ingen geometrisk 3D form slumpades fram";

        private static void Main()
        {
            ChangeDecimalOutputSeparation();
            Print20RandomShapes();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"-----------------------------------------------------------------------------------------------" +
                              $"\nSumman av alla trianglars omkrets: {triangleCircumferenceSum:0.0}");
            float averageAreaShapes = sumAreaShaped / nrRandShapes;
            Console.WriteLine($"\nDen genomsnittliga arean av alla geometriska former: {averageAreaShapes:0.0}");
            Console.WriteLine($"\nDen geometriska 3D form som har störst volym {volume3DShape:0.0} är: {largestVolume3DShape}\n");
            Console.WriteLine("En triangel med följande invärden Vector2.Zero, Vector2.One, new Vector2(2.0f, .5f) har koordinaterna:");
            var t = new Triangle(Vector2.Zero, Vector2.One, new Vector2(2.0f, .5f));
            foreach (Vector2 v in t)
                Console.WriteLine(v);
        }

        private static void Print20RandomShapes()
        {
            Console.WriteLine($"{nrRandShapes} slumpmässigt genererade geometriska former med {Shape.Min} som minimumvärde" +
                              $" och {Shape.Max} som maximumvärde:\n---------------------------------------------------------------------" +
                              $"--------------------------");

            for (int i = 0; i < nrRandShapes; i++)
            {
                var shape = Shape.GenerateShape().ToString();
                string shapeName = Shape.CurrentShape.GetType().Name;
                switch (shapeName)
                {
                    case "Circle":
                        sumAreaShaped += (Shape.CurrentShape as Circle).Area;
                        break;
                    case "Rectangle":
                        sumAreaShaped += (Shape.CurrentShape as Rectangle).Area;
                        break;
                    case "Triangle":
                        triangleCircumferenceSum += (Shape.CurrentShape as Triangle).Circumference;
                        sumAreaShaped += (Shape.CurrentShape as Triangle).Area;
                        break;
                    case "Cuboid":
                        sumAreaShaped += (Shape.CurrentShape as Cuboid).Area;
                        if (MathF.Abs((Shape.CurrentShape as Cuboid).Volume) > MathF.Abs(volume3DShape))
                        {
                            volume3DShape = (Shape.CurrentShape as Cuboid).Volume;
                            largestVolume3DShape = shape;
                        }
                        break;
                    case "Sphere":
                        sumAreaShaped += (Shape.CurrentShape as Sphere).Area;
                        if (MathF.Abs((Shape.CurrentShape as Sphere).Volume) > MathF.Abs(volume3DShape))
                        {
                            volume3DShape = (Shape.CurrentShape as Sphere).Volume;
                            largestVolume3DShape = shape;
                        }
                        break;
                }
                Console.WriteLine(shape);
            }
        }

        private static void ChangeDecimalOutputSeparation()
        {
            //https://stackoverflow.com/questions/9160059/set-up-dot-instead-of-comma-in-numeric-values
            var customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
    }
}
