using System;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Singleton Pattern Demo ===\n");

            // Create multiple references to Logger
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;
            Logger logger3 = Logger.Instance;

            // Test different log levels
            logger1.LogInfo("Application starting...");
            logger2.LogWarning("This is a warning message");
            logger3.LogError("This is an error message");
            logger1.Log("Regular log message");

            // Verify they're the same instance
            Console.WriteLine("\n=== Singleton Verification ===");
            Console.WriteLine($"logger1 == logger2: {ReferenceEquals(logger1, logger2)}");
            Console.WriteLine($"logger1 == logger3: {ReferenceEquals(logger1, logger3)}");
            Console.WriteLine($"logger2 == logger3: {ReferenceEquals(logger2, logger3)}");
            
            Console.WriteLine("\n=== Hash Code Comparison ===");
            Console.WriteLine($"HashCode logger1: {logger1.GetHashCode()}");
            Console.WriteLine($"HashCode logger2: {logger2.GetHashCode()}");
            Console.WriteLine($"HashCode logger3: {logger3.GetHashCode()}");

            // Simulate application workflow
            Console.WriteLine("\n=== Application Workflow Simulation ===");
            SimulateUserLogin();
            SimulateDataProcessing();
            SimulateApplicationShutdown();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void SimulateUserLogin()
        {
            Logger logger = Logger.Instance;
            logger.LogInfo("User login process started");
            logger.Log("Validating credentials...");
            logger.LogInfo("User successfully logged in");
        }

        static void SimulateDataProcessing()
        {
            Logger logger = Logger.Instance;
            logger.LogInfo("Data processing started");
            logger.Log("Processing 1000 records...");
            logger.LogWarning("Some records were skipped");
            logger.LogInfo("Data processing completed");
        }

        static void SimulateApplicationShutdown()
        {
            Logger logger = Logger.Instance;
            logger.LogInfo("Application shutdown initiated");
            logger.Log("Cleaning up resources...");
            logger.LogInfo("Application shutdown completed");
        }
    }
}