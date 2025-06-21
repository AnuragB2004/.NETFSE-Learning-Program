using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Stock Market Observer Pattern Demo ===\n");

        // Create stock market (subject)
        StockMarket stockMarket = new StockMarket();

        // Create observers
        MobileApp mobileApp = new MobileApp("StockTracker");
        WebApp webApp = new WebApp("InvestmentPortal");
        EmailNotificationService emailService = new EmailNotificationService();

        // Register observers
        Console.WriteLine("Registering observers...");
        stockMarket.RegisterObserver(mobileApp);
        stockMarket.RegisterObserver(webApp);
        stockMarket.RegisterObserver(emailService);

        Console.WriteLine(new string('-', 50));

        // Update stock prices
        stockMarket.SetStockPrice("AAPL", 150.25m);
        
        Console.WriteLine(new string('-', 50));
        
        stockMarket.SetStockPrice("GOOGL", 2750.80m);

        Console.WriteLine(new string('-', 50));

        // Remove an observer
        Console.WriteLine("Removing mobile app observer...");
        stockMarket.RemoveObserver(mobileApp);
        
        Console.WriteLine(new string('-', 50));
        
        stockMarket.SetStockPrice("MSFT", 305.15m);
    }
}