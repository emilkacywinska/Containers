using System;
namespace ContainersProgram;

public abstract class Container
{

    protected static int nextSerialNumber = 0;
    public string SerialNumber { get; }
    public double Weight { get; set; }
    protected double Height { get; set; }
    protected double ContainerWeight { get; set; }
    protected double Depth { get; set; }
    protected double MaxCapacity { get; set; }

    protected abstract string ContainerTypeCode { get; }

    public Container(double weight, double height, double containerWeight, double depth, double maxCapacity)
    {
        Weight = weight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        MaxCapacity = maxCapacity;

        SerialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        nextSerialNumber++;
        return $"KON-{ContainerTypeCode}-{nextSerialNumber}";
    }

    public virtual void Load(double cargoWeight)
    {
        if (Weight + cargoWeight > MaxCapacity)
        {
            throw new OverfillException($"Overfilling container {SerialNumber}. Cargo weight exceeds maximum capacity.");
        }
        else
        {
            Weight += cargoWeight;
        }
    }

    public virtual void Unload()
    {
        Weight = 0;
    }

    public override string ToString()
    {
        return $"[Container] -- SerialNumber: {SerialNumber}, Weight: {Weight} kg, Height: {Height} cm, Container Weight: {ContainerWeight} kg, Depth: {Depth} cm, Max Capacity: {MaxCapacity} kg";
    }

}