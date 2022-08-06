namespace ClassLibrary1.Classes;

public class PassengerCar : Car
{
    // Водитель считается за пассажира? По идее да, но четкого определения в задании не было
    public int passengers;

    public const float passengerFee = 0.06f;

    // Предусмотрите проверку на допустимое количество пассажиров
    public bool CanTakePassengers(int passengers, float fuelLevel, float distanceKm)
    {
        return GetMaxPassengers(fuelLevel, distanceKm) >= passengers;
    }
    
    public int GetMaxPassengers(float fuelLevel, float distanceKm)
    {
        var neededFuel = distanceKm / definition.fuelUsagePerKm;
        var fuelLeft = fuelLevel - neededFuel;

        if (fuelLeft <= 0)
        {
            return 0;
        }

        var fuelPerPassenger = fuelLevel * passengerFee;
        var passengersFloat = fuelLeft / fuelPerPassenger;
        return (int) Math.Ceiling(passengersFloat);
    }

    public override float GetWeightMultiplier()
    {
        if (passengers <= 0)
        {
            return base.GetWeightMultiplier();
        }

        return 1 - passengers * passengerFee;
    }
}