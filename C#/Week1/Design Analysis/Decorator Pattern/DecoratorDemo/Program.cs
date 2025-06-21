using System;

class Program
{
    static void Main(string[] args)
    {
        // Simple email notification
        INotifier emailNotifier = new EmailNotifier();
        emailNotifier.Send("Hello World!");

        Console.WriteLine(new string('-', 40));

        // Email + SMS notification
        INotifier emailSmsNotifier = new SMSNotifierDecorator(new EmailNotifier());
        emailSmsNotifier.Send("Important Update!");

        Console.WriteLine(new string('-', 40));

        // Email + SMS + Slack notification
        INotifier multiChannelNotifier = new SlackNotifierDecorator(
            new SMSNotifierDecorator(
                new EmailNotifier()));
        multiChannelNotifier.Send("Critical Alert!");

        Console.WriteLine(new string('-', 40));

        // All channels notification
        INotifier allChannelsNotifier = new FacebookNotifierDecorator(
            new SlackNotifierDecorator(
                new SMSNotifierDecorator(
                    new EmailNotifier())));
        allChannelsNotifier.Send("System Maintenance Notice!");
    }
}