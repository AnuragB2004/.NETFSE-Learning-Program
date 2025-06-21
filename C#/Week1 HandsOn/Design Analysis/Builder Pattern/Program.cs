using System;

class Program
{
    static void Main(string[] args)
    {
        Computer gamingPC = new Computer.Builder()
            .SetCPU("Intel Core i9-13900K")
            .SetRAM("32GB DDR5")
            .SetStorage("2TB NVMe SSD")
            .SetGraphicsCard("NVIDIA RTX 4080")
            .SetMotherboard("ASUS ROG Strix Z790")
            .SetPowerSupply("850W Gold")
            .Build();

        Computer officePC = new Computer.Builder()
            .SetCPU("Intel Core i5-13400")
            .SetRAM("16GB DDR4")
            .SetStorage("512GB SSD")
            .SetMotherboard("MSI B660M")
            .SetPowerSupply("550W Bronze")
            .Build();

        Console.WriteLine(gamingPC);
        Console.WriteLine("\n" + new string('-', 40) + "\n");
        Console.WriteLine(officePC);
    }
}