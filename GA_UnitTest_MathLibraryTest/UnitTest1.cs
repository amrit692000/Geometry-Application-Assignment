namespace GA_UnitTest_MathLibraryTest;
 


[TestClass]
public class ShapeTests
{
    [TestMethod]
    public void TestSquareArea()
    {
        // Arrange
        int sideLength = 5;
        var square = new Square(sideLength);

        // Act
        double area = square.CalculateArea();

        // Assert
        Assert.AreEqual(sideLength * sideLength, area);
    }

    [TestMethod]
    public void TestSquarePerimeter()
    {
        // Arrange
        int sideLength = 5;
        var square = new Square(sideLength);

        // Act
        double perimeter = square.CalculatePerimeter();

        // Assert
        Assert.AreEqual(4 * sideLength, perimeter);
    }

    [TestMethod]
    public void TestRectangleArea()
    {
        // Arrange
        int length = 5;
        int width = 3;
        var rectangle = new Rectangle(length, width);

        // Act
        double area = rectangle.CalculateArea();

        // Assert
        Assert.AreEqual(length * width, area);
    }

    [TestMethod]
    public void TestRectanglePerimeter()
    {
        // Arrange
        int length = 5;
        int width = 3;
        var rectangle = new Rectangle(length, width);

        // Act
        double perimeter = rectangle.CalculatePerimeter();

        // Assert
        Assert.AreEqual(2 * (length + width), perimeter);
    }

    [TestMethod]
    public void TestTriangleArea()
    {
        // Arrange
        int side1 = 3;
        int side2 = 4;
        int side3 = 5;
        var triangle = new Triangle(side1, side2, side3);

        // Act
        double area = triangle.CalculateArea();

        // Assert
        double semiPerimeter = (side1 + side2 + side3) / 2.0;
        double expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));
        Assert.AreEqual(expectedArea, area);
    }

    [TestMethod]
    public void TestTrianglePerimeter()
    {
        // Arrange
        int side1 = 3;
        int side2 = 4;
        int side3 = 5;
        var triangle = new Triangle(side1, side2, side3);

        // Act
        double perimeter = triangle.CalculatePerimeter();

        // Assert
        Assert.AreEqual(side1 + side2 + side3, perimeter);
    }
}
