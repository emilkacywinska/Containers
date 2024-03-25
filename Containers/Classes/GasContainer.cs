using System;
namespace ContainersProgram;

public class GasContainer : Container, IHazardNotifier
{
    protected override string ContainerTypeCode => "G";

    private double pressure;

    public GasContainer(double weight, double height, double containerWeight, double depth, double maxCapacity, double pressure) 
        : base(weight, height, containerWeight, depth, maxCapacity)
    {
        this.pressure = pressure;
    }

    public override void Load(double cargoWeight)
    {
        if (Weight + cargoWeight > MaxCapacity)
        {
            NotifyHazard($"Cargo weight exceeds maximum capacity in container {SerialNumber}");
            throw new OverfillException($"Overfilling container {SerialNumber}. Cargo weight exceeds maximum capacity.");
        }
        else
        {
            Weight += cargoWeight;
        }
    }

    public override void Unload()
    {
        Weight *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification: Container {SerialNumber} - {message}");
    }
    
    public override string ToString()
    {
        return $"[GasContainer] -- SerialNumber: {SerialNumber}, Weight: {Weight} kg, Height: {Height} cm, Container Weight: {ContainerWeight} kg, Depth: {Depth} cm, Max Capacity: {MaxCapacity} kg, Pressure: {pressure} atm";
    }

}