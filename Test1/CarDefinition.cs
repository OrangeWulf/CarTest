namespace ClassLibrary1.Classes;

public class CarDefinition
{
    // Тут можно было бы сделать и строкой но не ясна специфика поля в будущем
    public CarType carType;
    
    // Сделаем вид что всегда движемся с постоянной скоростью
    public float speedKmPerSecond;

    public float maxFuelCapacity;

    // Сделаем вид что всегда движемся с постоянным расходом
    public float fuelUsagePerKm;
}