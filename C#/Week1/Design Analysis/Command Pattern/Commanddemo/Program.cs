using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Home Automation Command Pattern Demo ===");

        // Create devices (receivers)
        Light livingRoomLight = new Light("Living Room");
        Light kitchenLight = new Light("Kitchen");
        Fan bedroomFan = new Fan("Bedroom");

        // Create commands
        LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
        LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);
        LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
        LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);
        FanOnCommand bedroomFanOn = new FanOnCommand(bedroomFan);
        FanOffCommand bedroomFanOff = new FanOffCommand(bedroomFan);

        // Create remote control (invoker)
        RemoteControl remote = new RemoteControl();

        // Set up remote control
        remote.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
        remote.SetCommand(1, kitchenLightOn, kitchenLightOff);
        remote.SetCommand(2, bedroomFanOn, bedroomFanOff);

        Console.WriteLine(remote.ToString());

        // Test commands
        Console.WriteLine("\nTesting remote control:");
        remote.OnButtonPressed(0);  // Living room light on
        remote.OffButtonPressed(0); // Living room light off
        remote.OnButtonPressed(1);  // Kitchen light on
        remote.OnButtonPressed(2);  // Bedroom fan on

        Console.WriteLine("\nUndo last command:");
        remote.UndoButtonPressed(); // Undo bedroom fan on

        Console.WriteLine("\nUndo again:");
        remote.UndoButtonPressed(); // Undo kitchen light on

        Console.WriteLine("\nUndo again:");
        remote.UndoButtonPressed(); // Undo living room light off

        Console.WriteLine("\nUndo again:");
        remote.UndoButtonPressed(); // Undo living room light on

        Console.WriteLine("\nTry to undo when no commands:");
        remote.UndoButtonPressed(); // No command to undo
    }
}