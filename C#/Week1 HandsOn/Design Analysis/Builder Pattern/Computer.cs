using System;

public class Computer
{
    public string CPU { get; private set; }
    public string RAM { get; private set; }
    public string Storage { get; private set; }
    public string GraphicsCard { get; private set; }
    public string Motherboard { get; private set; }
    public string PowerSupply { get; private set; }

    private Computer(Builder builder)
    {
        CPU = builder.CPU;
        RAM = builder.RAM;
        Storage = builder.Storage;
        GraphicsCard = builder.GraphicsCard;
        Motherboard = builder.Motherboard;
        PowerSupply = builder.PowerSupply;
    }

    public override string ToString()
    {
        return $"Computer Configuration:\n" +
               $"CPU: {CPU}\n" +
               $"RAM: {RAM}\n" +
               $"Storage: {Storage}\n" +
               $"Graphics Card: {GraphicsCard}\n" +
               $"Motherboard: {Motherboard}\n" +
               $"Power Supply: {PowerSupply}";
    }

    public class Builder
    {
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }
        public string GraphicsCard { get; private set; }
        public string Motherboard { get; private set; }
        public string PowerSupply { get; private set; }

        public Builder SetCPU(string cpu)
        {
            CPU = cpu;
            return this;
        }

        public Builder SetRAM(string ram)
        {
            RAM = ram;
            return this;
        }

        public Builder SetStorage(string storage)
        {
            Storage = storage;
            return this;
        }

        public Builder SetGraphicsCard(string graphicsCard)
        {
            GraphicsCard = graphicsCard;
            return this;
        }

        public Builder SetMotherboard(string motherboard)
        {
            Motherboard = motherboard;
            return this;
        }

        public Builder SetPowerSupply(string powerSupply)
        {
            PowerSupply = powerSupply;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}