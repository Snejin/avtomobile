class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите транспорт:");
        Console.WriteLine("1. Грузовик");
        Console.WriteLine("2. Автобус");

        if (int.TryParse(Console.ReadLine(), out int vehicleChoice))
        {
            Console.WriteLine("Введите начальную емкость бака:");
            if (int.TryParse(Console.ReadLine(), out int initialFuel))
            {
                Vehicle selectedVehicle = null;

                switch (vehicleChoice)
                {
                    case 1:
                        selectedVehicle = new Truck(initialFuel);
                        break;
                    case 2:
                        selectedVehicle = new Bus(initialFuel);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор автомобиля. Выход из программы.");
                        return;
                }

                selectedVehicle.SetFuelConsumption();

                while (true)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Установить начальную скорость");
                    Console.WriteLine("2. Ускорение");
                    Console.WriteLine("3. Тормозить");
                    Console.WriteLine("4. Заполнить бак");
                    Console.WriteLine("5. Начать движение");
                    Console.WriteLine("6. Выход");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                selectedVehicle.SetSpeed();
                                break;
                            case 2:
                                selectedVehicle.Accelerate();
                                break;
                            case 3:
                                selectedVehicle.Brake();
                                break;
                            case 4:
                                selectedVehicle.FillTank();
                                break;
                            case 5:
                                if (selectedVehicle is Bus bus)
                                {
                                    Console.WriteLine("Выберите действие для автобуса:");
                                    Console.WriteLine("7.Загрузить пассажиров");
                                    Console.WriteLine("8.Выгрузить пассажиров");
                                    Console.WriteLine("9.Отобразить количество пассажиров");

                                    if (int.TryParse(Console.ReadLine(), out int busChoice))
                                    {
                                        switch (busChoice)
                                        {
                                            case 7:
                                                bus.LoadPassengers();
                                                break;
                                            case 8:
                                                bus.UnloadPassengers();
                                                break;
                                            case 9:
                                                bus.DisplayPassengerCount();
                                                break;
                                            default:
                                                Console.WriteLine("Недействительное действие автобуса. Продолжаем движение.");
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
                                    selectedVehicle.Drive();
                                }
                                break;
                            case 6:
                                double totalMileage = selectedVehicle.GetTotalMileage();
                                Console.WriteLine($"Общий пробег: {totalMileage} км. Выход из программы.");
                                return;
                            default:
                                Console.WriteLine("Неверный выбор. Пожалуйста, выберите еще раз.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите еще раз.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Недопустимый ввод. Программа завершена.");
            }
        }
        else
        {
            Console.WriteLine("Недопустимый ввод. Программа завершена.");
        }
    }
}