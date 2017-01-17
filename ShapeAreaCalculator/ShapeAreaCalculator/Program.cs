
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string choice;

            Console.WriteLine("Enter the shape name\n");
            choice = Console.ReadLine();

            ShapesAreaCalculator shape = ShapeFactory.GetShape(choice);

            Console.WriteLine("Enter the dimensions\n");
            string dimen = Console.ReadLine();

            double[] dimension = Array.ConvertAll(dimen.Split(' '), Double.Parse);

            double actual = shape.CalculateArea(dimension).Display();

            Console.WriteLine("Area is:"+actual);
            Console.ReadLine();
        }
    }
}
