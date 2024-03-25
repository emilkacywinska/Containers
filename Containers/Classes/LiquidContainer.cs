using System;
namespace ContainersProgram;

public class LiquidContainer : Container, IHazardNotifier
{
    protected override string ContainerTypeCode => "L";

    private bool isDangerous;

    public LiquidContainer(double weight, double height, double containerWeight, double depth, double maxCapacity, bool isDangerous) 
        : base(weight, height, containerWeight, depth, maxCapacity)
    {
        this.isDangerous = isDangerous;
    }

    public override void Load(double cargoWeight)
    {
        bool isOverfill = false;
        
        if (isDangerous && Weight + cargoWeight > MaxCapacity * 0.5)
        {
            isOverfill = true;
        }else if (!isDangerous && Weight + cargoWeight > MaxCapacity * 0.9)
        {
            isOverfill = true;
        }

        if (isOverfill)
        {
            NotifyHazard("Attempted to perform a dangerous operation: overfilling container.");
        }else
        {
            Weight += cargoWeight;
        }
    }

    public override void Unload()
    {
        base.Unload();
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification: Container {SerialNumber} - {message}");
    }
    
    public override string ToString()
    {
        string dangerInfo = isDangerous ? " (Dangerous)" : "";
        return $"[LiquidContainer] -- SerialNumber: {SerialNumber}, Weight: {Weight} kg, Height: {Height} cm, Container Weight: {ContainerWeight} kg, Depth: {Depth} cm, Max Capacity: {MaxCapacity} kg{dangerInfo}";
    }

    
}