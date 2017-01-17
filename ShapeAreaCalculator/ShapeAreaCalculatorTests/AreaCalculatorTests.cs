using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeAreaCalculator;

namespace ShapeAreaCalculatorTests
{
    [TestClass]
    public class AreaCalculatorTests
    {
        [TestMethod]
        public void RectangleInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Rectangle");
            double actual = shape.CalculateArea(10,20).Display();
            Assert.AreEqual(200, actual, "Area as Expected");
        }

        [TestMethod]
        public void InvalidInputForRectangle_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Rectangle");
            try
            {
                double actual = shape.CalculateArea(10, 20, 30).Display();
            }
            catch(Exception e)
            {
                Assert.AreEqual(e.Message, "Wrong Number of input values for Rectangle");
            }
        }

        [TestMethod]
        public void RectangleBoundaryValueInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Rectangle");
            double actual = shape.CalculateArea(0.01, 0.01).Display();
            Assert.AreEqual((0.01*0.01), actual, "Area as Expected");
        }

        [TestMethod]
        public void RectangleZeroValueInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Rectangle");
            double actual = shape.CalculateArea(0, 0).Display();
            Assert.AreEqual(0, actual, "Area as Expected");
        }

        [TestMethod]
        public void CircleInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Circle");
            double actual = shape.CalculateArea(10).Display();
            Assert.AreEqual(314, actual, "Area as Expected");
        }

        [TestMethod]
        public void InvalidInputForCircle_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Circle");
            try
            {
                double actual = shape.CalculateArea().Display();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Wrong Number of input values for circle",e.Message);
            }
        }

        [TestMethod]
        public void CircleBoundaryInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Circle");
            double actual = shape.CalculateArea(0.01).Display();
            Assert.AreEqual((3.14*0.01*0.01), actual, "Area as Expected");
        }

        [TestMethod]
        public void CircleZeroInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Circle");
            double actual = shape.CalculateArea(0).Display();
            Assert.AreEqual(0, actual, "Area as Expected");
        }


        [TestMethod]
        public void TriangleInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Triangle");
            double actual = shape.CalculateArea(2,2).Display();
            Assert.AreEqual(2, actual, "Area as Expected");
        }

        [TestMethod]
        public void InvalidInputForTriangle_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Triangle");
            try
            {
                double actual = shape.CalculateArea().Display();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Wrong Number of input values for triangle", e.Message);
            }
        }

        [TestMethod]
        public void TriangleBoundaryValueInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Triangle");
            double actual = shape.CalculateArea(0.01,0.01).Display();
            Assert.AreEqual((0.5*0.01*0.01), actual, "Area as Expected");
        }

        [TestMethod]
        public void TriangleZeroInput_GivesRightArea()
        {
            ShapesAreaCalculator shape = ShapeFactory.GetShape("Triangle");
            double actual = shape.CalculateArea(0, 0).Display();
            Assert.AreEqual(0, actual, "Area as Expected");
        }

        [TestMethod]
        public void InvalidInputToGetShape_ThrowsException()
        {
            try
            {
                ShapesAreaCalculator shape = ShapeFactory.GetShape("1");
            }
            catch(Exception e)
            {
                Assert.AreEqual("Wrong choice Made", e.Message);
            }
        }

        [TestMethod]
        public void NegativeInputForCircle_ThrowsException()
        {
            try
            {
                ShapesAreaCalculator shape = ShapeFactory.GetShape("Circle");
                double actual = shape.CalculateArea(-1).Display();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Negative Numbers cannot be handled", e.Message);
            }
        }

        [TestMethod]
        public void NegativeInputForRectangle_ThrowsException()
        {
            try
            {
                ShapesAreaCalculator shape = ShapeFactory.GetShape("Rectangle");
                double actual = shape.CalculateArea(-1,-1).Display();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Negative Numbers cannot be handled", e.Message);
            }
        }

        [TestMethod]
        public void NegativeInputForTraingle_ThrowsException()
        {
            try
            {
                ShapesAreaCalculator shape = ShapeFactory.GetShape("Triangle");
                double actual = shape.CalculateArea(-1, -2).Display();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Negative Numbers cannot be handled", e.Message);
            }
        }



    }
}
