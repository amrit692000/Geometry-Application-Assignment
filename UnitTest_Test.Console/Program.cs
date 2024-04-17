
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

class Program
{
    static async Task Main(string[] args)
    {
        var featureManagement = new Dictionary<string, string>
        {
            { "FeatureManagement:Square", "true" },
            { "FeatureManagement:Rectangle", "false" },
            { "FeatureManagement:Triangle", "true" }
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement)
            .Build();

        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
        
        if (await featureManager.IsEnabledAsync("Square"))
        
        {
            Console.WriteLine("Enter the side length of the square:");
            if (int.TryParse(Console.ReadLine(), out int sideLength))
            {
                Console.WriteLine($"Square area: {sideLength * sideLength}");
                Console.WriteLine($"Square perimeter: {4 * sideLength}");
            }
            else
            {
                Console.WriteLine("Invalid input for Square.");
            }
        }
        else
        {
            Console.WriteLine("Square feature is not enabled.");
        }
         if (await featureManager.IsEnabledAsync("Rectangle"))
         {

        Console.WriteLine("Enter the length and width of the rectangle separated by space:");
        string[] rectangleDimensions = Console.ReadLine().Split(' ');
        int rectangleLength, rectangleWidth;
        if (rectangleDimensions.Length == 2 && int.TryParse(rectangleDimensions[0], out rectangleLength) && int.TryParse(rectangleDimensions[1], out rectangleWidth))
        {
            Console.WriteLine($"Rectangle area: {rectangleLength * rectangleWidth}");
            Console.WriteLine($"Rectangle perimeter: {2 * (rectangleLength + rectangleWidth)}");
        }
        else
        {
            Console.WriteLine("Invalid input for Rectangle.");
        }
    }
        if (await featureManager.IsEnabledAsync("Triangle"))
        {
        Console.WriteLine("Enter the three side lengths of the triangle separated by space:");
        string[] triangleDimensions = Console.ReadLine().Split(' ');
        int triangleSide1, triangleSide2, triangleSide3;
        if (triangleDimensions.Length == 3 && int.TryParse(triangleDimensions[0], out triangleSide1) && int.TryParse(triangleDimensions[1], out triangleSide2) && int.TryParse(triangleDimensions[2], out triangleSide3))
        {
            if (triangleSide1 + triangleSide2 > triangleSide3 && triangleSide1 + triangleSide3 > triangleSide2 && triangleSide2 + triangleSide3 > triangleSide1)
            {
                double semiPerimeter = (triangleSide1 + triangleSide2 + triangleSide3) / 2.0;
                double triangleArea = Math.Sqrt(semiPerimeter * (semiPerimeter - triangleSide1) * (semiPerimeter - triangleSide2) * (semiPerimeter - triangleSide3));
                Console.WriteLine($"Triangle area: {triangleArea}");
                Console.WriteLine($"Triangle perimeter: {triangleSide1 + triangleSide2 + triangleSide3}");
            }
            else
            {
                Console.WriteLine("Invalid input for Triangle: Not a valid triangle.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Triangle.");
        }
        }
    }
}
