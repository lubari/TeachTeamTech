using System;

namespace TechTeam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Continue = true;
            while (Continue)
            {
                double[,] points = GetPoints();
                double[] sides = CalculateTriangleSides(points);


                // Output side lengths
                PrintSides(sides);

                // Check if triangle is equilateral
                bool isEquilateral = sides[0] == sides[1] && sides[1] == sides[2];
                PrintTraingleProperty(isEquilateral, "Equilateral");

                // Check if triangle is isosceles
                bool isIsosceles = sides[0] == sides[1] || sides[1] == sides[2] || sides[2] == sides[0];
                PrintTraingleProperty(isIsosceles, "Isoceles");

                // Check if triangle is right-angled
                bool isRight = IsRightTriangle(sides[0], sides[1], sides[2], isEquilateral);
                PrintTraingleProperty(isRight, "Right");

                // Calculate and output perimeter
                double perimeter = CalculatePerimeter(sides);

                // Output even numbers up to perimeter
                EvenNumbers(perimeter);


                Console.WriteLine("Press Enter to Exit the program.");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Exit");
                    Continue = false;
                }
            }
        }

        static bool isEquilateral(double[] sides)
        {
            bool isEquilateral = sides[0] == sides[1] && sides[1] == sides[2];
            if (isEquilateral)
            {
                Console.WriteLine("Trainge IS NOT ");
            }
            return isEquilateral;
        }

        static void PrintTraingleProperty(bool value, string property)
        {
            string whatIs = "IS NOT";
            if (value)
            {
                whatIs = "IS";
            }
            Console.WriteLine($"Triangle {whatIs} {property}");
        }

        static double[,] GetPoints()
        {
            double[,] points = new double[3, 2];
            for (int i = 0; i < 3; i++)
            {
                points[i, 0] = InputPoint("x", i+1);
                points[i, 1] = InputPoint("y", i+1);
            }
            return points;
        }

        static double InputPoint(string v, int i)
        {
            Console.WriteLine("Enter "+v+i+" point: ");
            string input = Console.ReadLine().Replace('.', ',');
            bool isValidInput = true;
            double dot = 0;

            while (isValidInput)
            {
                if (double.TryParse(input, out double value))
                {
                    // The input is a valid integer, so we can cast it to double
                    dot = (double)value;
                    Console.WriteLine("The input value is " + v + i + " is: " + dot);
                    isValidInput= false;
                }
                else
                {
                    // The input is not a valid integer, so we cannot cast it to double
                    Console.WriteLine("The input is not a double.");
                    Console.WriteLine("Enter " + v + i + " point: ");
                    input = Console.ReadLine().Replace('.', ',');
                }
            }
            return dot;
        }

        static double[] CalculateTriangleSides(double[,] points)
        {
            double[] sides = new double[3];
            for (int i = 0; i < 3; i++)
            {
                int j = (i + 1) % 3;
                sides[i] = GetDistanceBetweenPoints(points[i, 0], points[i, 1], points[j, 0], points[j, 1]);
            }
            return sides;
        }

        static double GetDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
           return (Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
        }

        static void PrintSides(double[] sides)
        {
            for (int i = 0; i < (sides.Length); i++)
            {   
                Console.WriteLine("Side "+(i+1)+" length: " +sides[i]);
            }
        }

        static double CalculatePerimeter(double[] sides)
        {
            double perimeter = 0;
            foreach(double s in sides)
            {
                perimeter += s;
            }
            Console.WriteLine("Perimeter: "+perimeter);
            return perimeter;
        }

        static void EvenNumbers(double perimeter)
        {
            for (int i = 0; i <= (perimeter); i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($" {i} ");
                }
            }
            Console.WriteLine();
        }

        static bool IsRightTriangle(double s1, double s2, double s3, bool isEquilateral)
        {
            if (isEquilateral)
            {
                return false;
            }

            // Sort the sides in ascending order
            double[] sides = { s1, s2, s3 };
            Array.Sort(sides);

            // Check if the longest side satisfies the Pythagorean theorem
            return Convert.ToInt32(Math.Pow(sides[2], 2)) == Convert.ToInt32(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2));
        }
    }
}
