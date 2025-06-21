using System;

// Strategy Interface
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

// Concrete Strategies
public class CreditCardPayment : IPaymentStrategy
{
    private string _cardNumber;
    private string _holderName;

    public CreditCardPayment(string cardNumber, string holderName)
    {
        _cardNumber = cardNumber;
        _holderName = holderName;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid ${amount} using Credit Card");
        Console.WriteLine($"Card Number: ****-****-****-{_cardNumber.Substring(_cardNumber.Length - 4)}");
        Console.WriteLine($"Card Holder: {_holderName}");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private string _email;

    public PayPalPayment(string email)
    {
        _email = email;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid ${amount} using PayPal");
        Console.WriteLine($"PayPal Account: {_email}");
    }
}

public class BankTransferPayment : IPaymentStrategy
{
    private string _accountNumber;
    private string _bankName;

    public BankTransferPayment(string accountNumber, string bankName)
    {
        _accountNumber = accountNumber;
        _bankName = bankName;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid ${amount} using Bank Transfer");
        Console.WriteLine($"Bank: {_bankName}");
        Console.WriteLine($"Account: ****{_accountNumber.Substring(_accountNumber.Length - 4)}");
    }
}

// Context Class
public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ExecutePayment(decimal amount)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("No payment strategy selected!");
            return;
        }

        Console.WriteLine($"Processing payment of ${amount}...");
        _paymentStrategy.Pay(amount);
        Console.WriteLine("Payment completed successfully!\n");
    }
}