using System;
using System.Collections.Generic;

namespace AdapterDemo
{
    // Target Interface
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // Adaptee Classes (Third-party payment gateways)
    public class PayPalGateway
    {
        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"Processing ${amount:F2} payment through PayPal Gateway");
        }
    }

    public class StripeGateway
    {
        public void ChargeCard(decimal amount)
        {
            Console.WriteLine($"Charging ${amount:F2} through Stripe Gateway");
        }
    }

    public class SquareGateway
    {
        public void ProcessTransaction(decimal amount)
        {
            Console.WriteLine($"Processing ${amount:F2} transaction through Square Gateway");
        }
    }

    // Adapter Classes
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalGateway _payPalGateway;

        public PayPalAdapter(PayPalGateway payPalGateway)
        {
            _payPalGateway = payPalGateway;
        }

        public void ProcessPayment(decimal amount)
        {
            _payPalGateway.MakePayment(amount);
        }
    }

    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeGateway _stripeGateway;

        public StripeAdapter(StripeGateway stripeGateway)
        {
            _stripeGateway = stripeGateway;
        }

        public void ProcessPayment(decimal amount)
        {
            _stripeGateway.ChargeCard(amount);
        }
    }

    public class SquareAdapter : IPaymentProcessor
    {
        private readonly SquareGateway _squareGateway;

        public SquareAdapter(SquareGateway squareGateway)
        {
            _squareGateway = squareGateway;
        }

        public void ProcessPayment(decimal amount)
        {
            _squareGateway.ProcessTransaction(amount);
        }
    }

    // Payment Service Class (Optional - shows practical usage)
    public class PaymentService
    {
        public void ProcessPayments(List<(IPaymentProcessor processor, decimal amount, string gateway)> payments)
        {
            foreach (var payment in payments)
            {
                Console.WriteLine($"\n--- Processing payment via {payment.gateway} ---");
                payment.processor.ProcessPayment(payment.amount);
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Adapter Pattern Demo - Payment Processors ===\n");

            // Create payment processors using adapters
            IPaymentProcessor paypalProcessor = new PayPalAdapter(new PayPalGateway());
            IPaymentProcessor stripeProcessor = new StripeAdapter(new StripeGateway());
            IPaymentProcessor squareProcessor = new SquareAdapter(new SquareGateway());

            // Basic usage - same interface for different gateways
            Console.WriteLine("=== Basic Payment Processing ===");
            paypalProcessor.ProcessPayment(100.50m);
            stripeProcessor.ProcessPayment(250.75m);
            squareProcessor.ProcessPayment(75.25m);

            // Advanced usage - using a service
            Console.WriteLine("\n=== Advanced Payment Service Usage ===");
            var paymentService = new PaymentService();
            var payments = new List<(IPaymentProcessor, decimal, string)>
            {
                (paypalProcessor, 150.00m, "PayPal"),
                (stripeProcessor, 300.50m, "Stripe"),
                (squareProcessor, 99.99m, "Square"),
                (paypalProcessor, 25.75m, "PayPal")
            };

            paymentService.ProcessPayments(payments);

            // Demonstrate polymorphism
            Console.WriteLine("\n=== Polymorphic Usage ===");
            IPaymentProcessor[] processors = { paypalProcessor, stripeProcessor, squareProcessor };
            decimal[] amounts = { 50.00m, 75.50m, 120.25m };

            for (int i = 0; i < processors.Length; i++)
            {
                Console.WriteLine($"Payment {i + 1}:");
                processors[i].ProcessPayment(amounts[i]);
            }

            // Show the benefit of uniform interface
            Console.WriteLine("\n=== Uniform Interface Benefit ===");
            ProcessPaymentUniformly(paypalProcessor, 200.00m);
            ProcessPaymentUniformly(stripeProcessor, 300.00m);
            ProcessPaymentUniformly(squareProcessor, 150.00m);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // This method can work with any payment processor that implements IPaymentProcessor
        static void ProcessPaymentUniformly(IPaymentProcessor processor, decimal amount)
        {
            Console.WriteLine($"Processing uniform payment of ${amount:F2}");
            processor.ProcessPayment(amount);
        }
    }
}