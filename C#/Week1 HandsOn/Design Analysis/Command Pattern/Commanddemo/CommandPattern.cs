using System;
using System.Collections.Generic;

// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver Classes
public class Light
{
    private string _location;
    private bool _isOn;

    public Light(string location)
    {
        _location = location;
        _isOn = false;
    }

    public void TurnOn()
    {
        _isOn = true;
        Console.WriteLine($"{_location} light is ON");
    }

    public void TurnOff()
    {
        _isOn = false;
        Console.WriteLine($"{_location} light is OFF");
    }

    public bool IsOn => _isOn;
}

public class Fan
{
    private string _location;
    private bool _isOn;

    public Fan(string location)
    {
        _location = location;
        _isOn = false;
    }

    public void TurnOn()
    {
        _isOn = true;
        Console.WriteLine($"{_location} fan is ON");
    }

    public void TurnOff()
    {
        _isOn = false;
        Console.WriteLine($"{_location} fan is OFF");
    }

    public bool IsOn => _isOn;
}

// Concrete Commands
public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}

public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }

    public void Undo()
    {
        _light.TurnOn();
    }
}

public class FanOnCommand : ICommand
{
    private Fan _fan;

    public FanOnCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.TurnOn();
    }

    public void Undo()
    {
        _fan.TurnOff();
    }
}

public class FanOffCommand : ICommand
{
    private Fan _fan;

    public FanOffCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.TurnOff();
    }

    public void Undo()
    {
        _fan.TurnOn();
    }
}

// Null Object Pattern for empty slots
public class NoCommand : ICommand
{
    public void Execute() { }
    public void Undo() { }
}

// Invoker Class
public class RemoteControl
{
    private ICommand[] _onCommands;
    private ICommand[] _offCommands;
    private Stack<ICommand> _undoCommands;

    public RemoteControl()
    {
        _onCommands = new ICommand[7]; // 7 slots
        _offCommands = new ICommand[7];
        _undoCommands = new Stack<ICommand>();

        ICommand noCommand = new NoCommand();
        for (int i = 0; i < 7; i++)
        {
            _onCommands[i] = noCommand;
            _offCommands[i] = noCommand;
        }
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        _onCommands[slot] = onCommand;
        _offCommands[slot] = offCommand;
    }

    public void OnButtonPressed(int slot)
    {
        _onCommands[slot].Execute();
        _undoCommands.Push(_onCommands[slot]);
    }

    public void OffButtonPressed(int slot)
    {
        _offCommands[slot].Execute();
        _undoCommands.Push(_offCommands[slot]);
    }

    public void UndoButtonPressed()
    {
        if (_undoCommands.Count > 0)
        {
            ICommand command = _undoCommands.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("No command to undo!");
        }
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine("\n------ Remote Control ------");
        for (int i = 0; i < _onCommands.Length; i++)
        {
            sb.AppendLine($"[slot {i}] {_onCommands[i].GetType().Name}    {_offCommands[i].GetType().Name}");
        }
        return sb.ToString();
    }
}