namespace ClassLibrary1.Classes;

public class TruckCar : Car
{
    public float loadedWeight;

    public const float weightFee = 0.04f;
    
    // Дополните класс проверкой может ли автомобиль принять полный груз на борт
    public bool CanTakeWeight(float weight, float fuelLevel, float distanceKm)
    {
        return GetMaxWeight(fuelLevel, distanceKm) >= weight;
    }
    
    public float GetMaxWeight(float fuelLevel, float distanceKm)
    {
        var neededFuel = distanceKm / definition.fuelUsagePerKm;
        var fuelLeft = fuelLevel - neededFuel;

        if (fuelLeft <= 0)
        {
            return 0;
        }

        var fuelPerObject = fuelLevel * weightFee;
        var calculatedFee = fuelLeft / fuelPerObject;
        return calculatedFee;
    }

    public override float GetWeightMultiplier()
    {
        if (loadedWeight <= 0)
        {
            return base.GetWeightMultiplier();
        }

        // Не знаю допустимо ли рассчитать уменьшение запаса хода на килограмм поэтому буду конвертировать в стаки по 200кг
        var weightInt = (int) loadedWeight;
        var weightStacks = weightInt / 200;
        return 1 - weightStacks * weightFee;
    }
}