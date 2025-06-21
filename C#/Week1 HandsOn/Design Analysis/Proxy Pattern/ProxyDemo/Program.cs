using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Image Viewer with Proxy Pattern ===\n");

        IImage image1 = new ProxyImage("vacation_photo.jpg");
        IImage image2 = new ProxyImage("family_portrait.png");

        Console.WriteLine("First call to display image1:");
        image1.Display();

        Console.WriteLine("\nSecond call to display image1 (should use cache):");
        image1.Display();

        Console.WriteLine("\nFirst call to display image2:");
        image2.Display();

        Console.WriteLine("\nSecond call to display image2 (should use cache):");
        image2.Display();
    }
}