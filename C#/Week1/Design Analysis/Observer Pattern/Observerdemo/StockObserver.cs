using System;
using System.Collections.Generic;

// Subject Interface
public interface IStock
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Observer Interface
public interface IObserver
{
    void Update(string stockSymbol, decimal price);
}

// Concrete Subject
public class StockMarket : IStock
{
    private List<IObserver> _observers;
    private string _stockSymbol;
    private decimal _price;

    public StockMarket()
    {
        _observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine($"Observer registered. Total observers: {_observers.Count}");
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine($"Observer removed. Total observers: {_observers.Count}");
    }

    public void NotifyObservers()
    {
        Console.WriteLine($"Notifying {_observers.Count} observers about {_stockSymbol} price change to ${_price}");
        foreach (var observer in _observers)
        {
            observer.Update(_stockSymbol, _price);
        }
    }

    public void SetStockPrice(string stockSymbol, decimal price)
    {
        _stockSymbol = stockSymbol;
        _price = price;
        NotifyObservers();
    }
}

// Concrete Observers
public class MobileApp : IObserver
{
    private string _appName;

    public MobileApp(string appName)
    {
        _appName = appName;
    }

    public void Update(string stockSymbol, decimal price)
    {
        Console.WriteLine($"[{_appName} Mobile App] Stock Alert: {stockSymbol} is now ${price}");
        SendPushNotification(stockSymbol, price);
    }

    private void SendPushNotification(string stockSymbol, decimal price)
    {
        Console.WriteLine($"[{_appName}] Push notification sent to mobile device");
    }
}

public class WebApp : IObserver
{
    private string _websiteName;

    public WebApp(string websiteName)
    {
        _websiteName = websiteName;
    }

    public void Update(string stockSymbol, decimal price)
    {
        Console.WriteLine($"[{_websiteName} Web App] Stock Update: {stockSymbol} price updated to ${price}");
        UpdateWebDashboard(stockSymbol, price);
    }

    private void UpdateWebDashboard(string stockSymbol, decimal price)
    {
        Console.WriteLine($"[{_websiteName}] Dashboard updated with latest {stockSymbol} price");
    }
}

public class EmailNotificationService : IObserver
{
    public void Update(string stockSymbol, decimal price)
    {
        Console.WriteLine($"[Email Service] Sending email alert: {stockSymbol} price changed to ${price}");
        SendEmail(stockSymbol, price);
    }

    private void SendEmail(string stockSymbol, decimal price)
    {
        Console.WriteLine($"[Email Service] Email sent to subscribers about {stockSymbol}");
    }
}