using System;
namespace ContainersProgram;

public class RefrigeratedContainer : Container
{
    protected override string ContainerTypeCode => "R";

    private string productType;
    private double temperature;

    public RefrigeratedContainer(double weight, double height, double containerWeight, double depth, double maxCapacity, string productType, double temperature) 
        : base(weight, height, containerWeight, depth, maxCapacity)
    {
        this.productType = productType.ToLower();
        this.temperature = temperature;
    }

    private static readonly Dictionary<string, double> ProductTemperatureMap = new Dictionary<string, double>()
    {
        {"bananas", 13.3 },
        {"chocolate", 18},
        {"fish", 2},
        {"meat", -15},
        {"ice cream", -18},
        {"frozen pizza", -30},
        {"cheese", 7.2},
        {"sausages", 5},
        {"butter", 20.5},
        {"eggs", 19}
    };
    
    public override void Load(double cargoWeight)
    {
        if (Weight + cargoWeight > MaxCapacity)
        {
            throw new OverfillException($"Overfilling container {SerialNumber}. Cargo weight exceeds maximum capacity.");
        }
        else if (!IsValidTemperature(productType, temperature))
        {
            throw new InvalidOperationException($"Temperature {temperature}°C is not suitable for storing {productType}.");
        }
        else if (!IsSameProductType(productType))
        {
            throw new InvalidOperationException($"Container can only store products of the same type.");
        }
        else
        {
            Weight += cargoWeight;
        }
    }

    public override void Unload()
    {
        base.Unload();
    }
    
    private bool IsValidTemperature(string productType, double temperature)
    {
        if (ProductTemperatureMap.ContainsKey(productType))
        {
            double requiredTemperature = ProductTemperatureMap[productType];
            return temperature >= requiredTemperature;
        }
        return false;
    }
    
    
    private bool IsSameProductType(string newProductType)
    {
        return productType == newProductType.ToLower();
    }

    public override string ToString()
    {
        return $"[RefrigeratedContainer] -- SerialNumber: {SerialNumber}, Weight: {Weight} kg, Height: {Height} cm, Container Weight: {ContainerWeight} kg, Depth: {Depth} cm, Max Capacity: {MaxCapacity} kg, Product Type: {productType}, Temperature: {temperature} °C";
    }

    
}