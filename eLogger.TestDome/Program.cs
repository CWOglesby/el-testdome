// Question 5, but using a 'math' approach (rather than a loop) to overcome performance issues

// This is a .NET 8 console app that can be executed on the command line from the solution folder:
//  > 'dotnet run --project=eLogger.TestDome'

using System;

public static class Shipping
{
    public static int MinimalNumberOfPackages(int itemCount, int maxLargePackages, int maxSmallPackages)
    {
        var remainingItems = itemCount;

        // 1. Calculate large packages required to package all items
        // 2. If items will not fit perfectly in large packages, add one package
        // 3. Calculate actual large package count, no more than available large packages
        var largePackageCount = (remainingItems / 5) + (remainingItems % 5 == 0 ? 0 : 1);
        largePackageCount = Math.Min(largePackageCount, maxLargePackages);
        remainingItems -= (largePackageCount * 5);

        if (remainingItems <= 0)
            return largePackageCount;

        // Small packages hold one item each, just need to compare remainingItems and maxSmallPackages
        var smallPackageCount = Math.Min(remainingItems, maxSmallPackages);
        remainingItems -= smallPackageCount;

        if (remainingItems <= 0)
            return (largePackageCount + smallPackageCount);

        // Out of packages
        return -1;
    }

    public static void Main(string[] args)
    {
        // Test: itemCount exactly equal to maximum packaged items
        // EXPECT: 13 (3 large, 10 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(25, 3, 10));

        // Test: Items fit into only large packages with one large package not full
        // EXPECT: 2 (2 large, 0 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(8, 3, 10));

        // Test: Items fit into one package
        // EXPECT: 1 (1 large, 0 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(3, 3, 10));

        // Test: Items require both small and large packages, but not the maximum
        // EXPECT: 6 (3 large, 3 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(18, 3, 10));

        // Test: Not enough packages
        // EXPECT: -1 (max 25 items)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(40, 3, 10));

        // Test: Packages but no items
        // EXPECT: 0 (0 large, 0 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(0, 3, 10));

        // Test: Items but no packages
        // EXPECT: -1 (0 large, 0 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(1, 0, 0));

        // Test: No items or packages
        // EXPECT: 0 (0 large, 0 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(0, 0, 0));

        // Test: Performance test for large storehouse, large packages only
        // EXPECT: 429496730 (429496730 large, 0 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(Int32.MaxValue, Int32.MaxValue, 0));

        // Test: Performance test for large storehouse, small packages only
        // EXPECT: 2147483647 (0 large, 2147483647 small)
        Console.WriteLine(Shipping.MinimalNumberOfPackages(Int32.MaxValue, 0, Int32.MaxValue));
    }
}