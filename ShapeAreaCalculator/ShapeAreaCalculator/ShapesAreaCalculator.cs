using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculator
{
    public static class ShapeFactory
    {
        public static ShapesAreaCalculator GetShape(string choice)
        {
           switch (choice)
            {
                case "Circle": var circleObject = new Circle();
                        return circleObject;
                case "Rectangle": var rectangleObject = new Rectangle();
                        return rectangleObject;
                case "Triangle": var triangleObject = new Traingle();
                        return triangleObject;
                default:
                    throw new Exception("Wrong choice Made");
            }

        }

    }

    public abstract class ShapesAreaCalculator
    {
        public abstract ShapesAreaCalculator CalculateArea(params double[] dimensions);
        public abstract double Display();
    }
    public class Circle : ShapesAreaCalculator
    {
        private double radius;
        public double area;
        public override ShapesAreaCalculator CalculateArea(params double[] dimensions)
        {
            if(dimensions.Length!=1)
            {
                throw new Exception("Wrong Number of input values for circle");
            }
            if (dimensions[0] < 0)
            {
                throw new Exception("Negative Numbers cannot be handled");
            }
            radius = dimensions[0];
            area = 3.14 * radius * radius;
            return this;
        }



        public override double Display()
        {
            return this.area;
        }
    }

    public class Rectangle : ShapesAreaCalculator
    {
        private double length;
        private double breadth;
        public double area;
        public override ShapesAreaCalculator CalculateArea(params double[] dimensions)
        {
            if (dimensions.Length != 2)
            {

                throw new Exception("Wrong Number of input values for Rectangle");
            }
            if (dimensions[0] < 0 || dimensions[1] < 0)
            {
                throw new Exception("Negative Numbers cannot be handled");
            }
            length = dimensions[0];
            breadth = dimensions[1];
            area = length * breadth;
            return this;
        }

        public override double Display()
        {
            return this.area;
        }
    }

    public class Traingle : ShapesAreaCalculator
    {
        private double Base;
        private double height;
        public double area;
        public override ShapesAreaCalculator CalculateArea(params double[] dimensions)
        {

            if (dimensions.Length != 2)
            {
                throw new Exception("Wrong Number of input values for triangle");
            }
            if(dimensions[0] < 0 || dimensions[1] <0)
            {
                throw new Exception("Negative Numbers cannot be handled");
            }
            Base = dimensions[0];
            height = dimensions[1];
            area = Base * height * 0.5 ;
            return this;
        }
        public override double Display()
        {
            return this.area;
        }
    }

}
