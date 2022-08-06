namespace ClassLibrary1.Classes;

public class Car
{
    // Общеие параметры машин которые где-то задаются
    public CarDefinition definition;
    
    // Текущий уровень топлива
    public float currentFuelLevel;

    // Метод, с помощью которого можно вычислить сколько автомобиль может проехать на остаточном количестве топлива в баке
    public float GetCurrentDrivingRange(bool checkLoad = true)
    {
        return GetDrivingRange(currentFuelLevel, checkLoad);
    }
    
    // Метод, с помощью которого можно вычислить сколько автомобиль может проехать на полном баке топлива
    public float GetMaxDrivingRange(bool checkLoad = true)
    {
        return GetDrivingRange(definition.maxFuelCapacity, checkLoad);
    }

    // Метод, с помощью которого можно вычислить сколько автомобиль может проехать
    public float GetDrivingRange(float fuelLevel, bool checkLoad = true)
    {
        if (fuelLevel <= 0f)
        {
            return 0f;
        }

        var baseRange = fuelLevel / definition.fuelUsagePerKm;
        if (checkLoad == false)
        {
            return baseRange;
        }
        
        var modifiedRange = baseRange * GetWeightMultiplier();
        return modifiedRange;
    }

    // Метод, который на основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет
    public float GetDrivingDurationSeconds(float fuelLevel, float distanceKm)
    {
        var drivingRange = GetDrivingRange(fuelLevel);
        if (drivingRange < distanceKm)
        {
            return float.PositiveInfinity;
        }

        return distanceKm / definition.speedKmPerSecond;
    }

    // Определяет модификатор для запаса хода (пассажиры, груз)
    public virtual float GetWeightMultiplier()
    {
        return 1f;
    }
}