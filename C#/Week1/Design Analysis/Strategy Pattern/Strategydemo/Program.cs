using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Payment Strategy Pattern Demo ===\n");

        PaymentContext paymentContext = new PaymentContext();

        // Pay with Credit Card
        Console.WriteLine("1. Paying with Credit Card:");
        paymentContext.SetPaymentStrategy(new CreditCardPayment("1234567890123456", "John Doe"));
        paymentContext.ExecutePayment(250.75m);

        // Pay with PayPal
        Console.WriteLine("2. Paying with PayPal:");
        paymentContext.SetPaymentStrategy(new PayPalPayment("john.doe@email.com"));
        paymentContext.ExecutePayment(100.50m);

        // Pay with Bank Transfer
        Console.WriteLine("3. Paying with Bank Transfer:");
        paymentContext.SetPaymentStrategy(new BankTransferPayment("9876543210", "First National Bank"));
        paymentContext.ExecutePayment(500.00m);

        // Try to pay without setting strategy
        Console.WriteLine("4. Attempting payment without strategy:");
        PaymentContext newContext = new PaymentContext();
        newContext.ExecutePayment(75.25m);
    }
}