using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Введите объем бака: ");
        double fuelTankVolume = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите расход топлива на 1 км: ");
        double fuelConsumption = Convert.ToDouble(Console.ReadLine());

        Car car = new Car(fuelTankVolume, fuelConsumption);

        Console.Write("Введите объем заправляемого топлива: ");
        double initialFuelVolume = Convert.ToDouble(Console.ReadLine());
        car.FillFuelTank(initialFuelVolume);

        while (true)
        {
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1 - Поехать");
            Console.WriteLine("2 - Торможение");
            Console.WriteLine("3 - Разгон");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    car.Drive();
                    break;
                case 2:
                    car.Brake();
                    break;
                case 3:
                    car.Accelerate();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор");
                    break;
            }

            Console.WriteLine();
        }
    }
}

