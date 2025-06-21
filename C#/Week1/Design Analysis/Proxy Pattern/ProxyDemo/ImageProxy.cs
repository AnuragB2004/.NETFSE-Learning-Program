using System;
using System.Threading;

// Subject Interface
public interface IImage
{
    void Display();
}

// Real Subject
public class RealImage : IImage
{
    private string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromRemoteServer();
    }

    private void LoadFromRemoteServer()
    {
        Console.WriteLine($"Loading image '{_filename}' from remote server...");
        // Simulate time-consuming operation
        Thread.Sleep(2000);
        Console.WriteLine($"Image '{_filename}' loaded successfully.");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {_filename}");
    }
}

// Proxy
public class ProxyImage : IImage
{
    private string _filename;
    private RealImage _realImage;
    private static readonly object _lock = new object();

    public ProxyImage(string filename)
    {
        _filename = filename;
    }

    public void Display()
    {
        if (_realImage == null)
        {
            lock (_lock)
            {
                if (_realImage == null)
                {
                    Console.WriteLine("Proxy: Creating real image instance...");
                    _realImage = new RealImage(_filename);
                }
            }
        }
        else
        {
            Console.WriteLine("Proxy: Using cached image...");
        }
        _realImage.Display();
    }
}