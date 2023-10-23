using System;

public class Car
{
    private double fuelTank; // объем бака
    private double fuelConsumption; // расход топлива на 1 км

    public Car(double fuelTank, double fuelConsumption)
    {
        this.fuelTank = fuelTank;
        this.fuelConsumption = fuelConsumption;
    }

    public void FillFuelTank(double fuelVolume)
    {
        fuelTank += fuelVolume;
        Console.WriteLine($"Бак заправлен. Текущий объем топлива: {fuelTank} л");
    }

    public void Drive()
    {
        Random random = new Random();

        double distance = random.Next(1, 50); // по расстоянию я не уверен что так нормально в случае чего поменять надо будет
        
        double fuelNeeded = fuelConsumption * distance; // расчет необходимого топлива на наш заезд

        if (fuelNeeded <= fuelTank)
        {
            fuelTank -= fuelNeeded;
            Console.WriteLine($"Проехали {distance} км. Остаток топлива: {fuelTank} л");
        }
        else
        {
            Console.WriteLine($"Недостаточно топлива для поездки на {distance} км");

            Console.Write("Хотите заправиться? (да/нет): ");
            string userChoice = Console.ReadLine();

            if (userChoice.ToLower() == "да")
            {
                Console.Write("Введите объем заправляемого топлива: "); //надо сделать сравнение с объемом бака
                double fuelVolume = Convert.ToDouble(Console.ReadLine());
                FillFuelTank(fuelVolume);
            }
        }
    }

    public void Brake()
    {
        Console.WriteLine("Торможение..."); // я не понимаю зачем оно нам но оно нам надо. с разгоном так же
    }

    public void Accelerate()
    {
        Console.WriteLine("Разгон...");
    }
}

