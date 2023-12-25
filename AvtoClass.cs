using System;

// Класс Транспортное средство
class Vehicle
{
    private int fuelTank;                // Уровень топлива в баке
    private double mileage;              // Пробег
    private int fuelConsumptionPer100Km; // Расход топлива на 100 км
    private double speed;                // Скорость
    private int fuelTankCapacity;        // Объем бака
    private double weight;               // Вес транспортного средства

    // Конструктор
    public Vehicle(int fuelTankCapacity, double weight)
    {
        this.fuelTankCapacity = fuelTankCapacity;
        fuelTank = fuelTankCapacity;
        this.weight = weight;
    }

    // Метод для заправки бака
    public void FillTank()
    {
        Console.WriteLine($"Текущий уровень топлива: {fuelTank} литров.");
        Console.WriteLine("Введите количество топлива для заправки:");

        if (int.TryParse(Console.ReadLine(), out int fuel))
        {
            if (fuel >= 0)
            {
                int potentialFuelLevel = fuelTank + fuel;

                if (potentialFuelLevel <= fuelTankCapacity)
                {
                    fuelTank = potentialFuelLevel;
                    Console.WriteLine($"В бак залито {fuel} литров топлива. Общий объем бака: {fuelTank} литров.");
                }
                else
                {
                    fuelTank = fuelTankCapacity;
                    Console.WriteLine($"Бак заполнен до объема {fuelTank} литров.");
                }
            }
            else
            {
                Console.WriteLine("Недопустимый ввод. Введите корректное значение.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Не удалось заполнить бак. Введите правильное числовое значение.");
            Console.ReadLine(); // Поглощаем неверный ввод, чтобы не влиял на последующий ввод
        }
    }

    // Метод для установки расхода топлива
    public void SetFuelConsumption()
    {
        Console.WriteLine("Введите расход топлива на 100 км:");
        if (int.TryParse(Console.ReadLine(), out int consumption))
        {
            if (consumption >= 0)
            {
                // Учитываем вес в расходе топлива
                fuelConsumptionPer100Km = consumption + (int)(weight * 0.1);
                Console.WriteLine($"Расход топлива установлен на {consumption} литров на 100 км.");
            }
            else
            {
                Console.WriteLine("Недопустимый ввод. Введите корректное значение.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Не удалось установить расход топлива.");
        }
    }

    // Метод для установки начальной скорости
    public void SetSpeed()
    {
        Console.WriteLine("Введите начальную скорость:");
        if (double.TryParse(Console.ReadLine(), out double initialSpeed))
        {
            if (initialSpeed >= 0)
            {
                speed = initialSpeed;
                Console.WriteLine($"Начальная скорость установлена на {initialSpeed} км/ч.");
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите корректное значение скорости.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Не удалось установить скорость.");
        }
    }

    // Метод для ускорения
    public void Accelerate()
    {
        Console.WriteLine("Введите скорость ускорения:");
        if (double.TryParse(Console.ReadLine(), out double acceleration))
        {
            if (acceleration >= 0)
            {
                speed += acceleration;
                Console.WriteLine($"Автомобиль разгоняется. Текущая скорость: {speed} км/ч.");
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите неотрицательное значение ускорения.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Ускорение не удалось.");
        }
    }

    // Метод для торможения
    public void Brake()
    {
        Console.WriteLine("Введите скорость торможения:");
        if (double.TryParse(Console.ReadLine(), out double braking))
        {
            if (braking >= 0 && braking <= speed)
            {
                speed -= braking;
                Console.WriteLine($"Автомобиль тормозит. Текущая скорость: {speed} км/ч.");
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите корректную скорость торможения.");
            }
        }
        else
        {
            Console.WriteLine("Неверный вход. Торможение не удалось.");
        }
    }

    // Метод для расчета расстояния
    private int CalculateDistance()
    {
        return new Random().Next(50, 201); // Случайное расстояние между 50 и 200 км
    }

    // Метод для езды
    public void Drive()
    {
        Console.WriteLine("Перед началом работы установите начальную скорость:");
        SetSpeed();

        while (true)
        {
            double maxDistance = (double)fuelTank / (fuelConsumptionPer100Km / 100.0);
            int distance = CalculateDistance();

            if (distance <= maxDistance)
            {
                double fuelConsumed = (fuelConsumptionPer100Km / 100.0) * distance;

                Console.WriteLine($"Проехать {distance} км при {speed} км/ч.");
                mileage += distance;
                fuelTank = Math.Max(0, fuelTank - (int)fuelConsumed);

                Console.WriteLine($"Остаток топлива: {fuelTank} литров.");

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Ускорение");
                Console.WriteLine("2. Тормозить");
                Console.WriteLine("3. Продолжить движение");
                Console.WriteLine("4. Выехать");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Accelerate();
                            break;
                        case 2:
                            Brake();
                            break;
                        case 3:
                            continue;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Продолжаем движение.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Недействительный вход. Продолжаем движение.");
                }
            }
            else
            {
                Console.WriteLine($"Недостаточно топлива для преодоления расстояния. Можно проехать {maxDistance} км.");
                AskForRefuel();
                return; // Выход из цикла Drive после заправки
            }
        }
    }

    // Приватный метод для запроса заправки
    private void AskForRefuel()
    {
        Console.WriteLine("Недостаточно топлива. Вы хотите заправиться? (y/n)");
        string response = Console.ReadLine();

        if (response.ToLower() == "y")
        {
            FillTank();
        }
        else
        {
            Console.WriteLine("Отказано в дозаправке. Невозможно продолжить путешествие.");
        }
    }

    // Публичный метод для получения общего пробега
    public double GetTotalMileage()
    {
        return mileage;
    }
}

// Класс Грузовик, наследующий от Транспортного средства
class Truck : Vehicle
{
    // Конструктор
    public Truck(int fuelTankCapacity) : base(fuelTankCapacity, 3.0) { }
}

// Класс Автобус, наследующий от Транспортного средства
class Bus : Vehicle
{
    private int passengerCount; // Количество пассажиров

    // Конструктор
    public Bus(int fuelTankCapacity) : base(fuelTankCapacity, 2.0)
    {
        passengerCount = 0;
    }

    // Метод для посадки пассажиров
    public void LoadPassengers()
    {
        Console.WriteLine("Введите количество пассажиров на борту:");
        if (int.TryParse(Console.ReadLine(), out int passengers))
        {
            if (passengers >= 0 && passengers <= 50)
            {
                passengerCount += passengers;
                Console.WriteLine($"{passengers} пассажиров на борту. Всего пассажиров: {passengerCount}.");
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите действительное количество пассажиров на борту (0-50).");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Посадка пассажиров не удалась.");
        }
    }

    // Метод для высадки пассажиров
    public void UnloadPassengers()
    {
        Console.WriteLine("Введите количество высаживаемых пассажиров:");
        if (int.TryParse(Console.ReadLine(), out int passengers))
        {
            if (passengers >= 0 && passengers <= passengerCount)
            {
                passengerCount -= passengers;
                Console.WriteLine($"{passengers} высадка пассажиров. Всего пассажиров: {passengerCount}.");
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите действительное количество пассажиров для высадки.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Высадка пассажиров не удалась.");
        }
    }

    // Метод для отображения количества пассажиров
    public void DisplayPassengerCount()
    {
        Console.WriteLine($"Текущее количество пассажиров: {passengerCount}.");
    }

    // Переопределенный метод для расчета расстояния для автобуса
    protected new int CalculateDistance()
    {
        // Автобус может проехать более короткое расстояние, чем другие транспортные средства
        return new Random().Next(20, 101); // Случайное расстояние
    }
}

