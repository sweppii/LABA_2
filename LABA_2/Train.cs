using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2
{
    internal class Train
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int way {  get; set; }
        public int stops { get; set; }
        public List<Carriage> Carriages { get; set; }
        public string routeNumber { get; set; }
        public Train (string id)
        {
            Id = id;
            Carriages = new List<Carriage>();
        }
        public void CreateTrain ()
        {
            Console.WriteLine("Введіть назву потягу:");
            Name = Console.ReadLine();
            Console.WriteLine("------------------------------------------------------");
            bool AddingCarriages = true;
            while (AddingCarriages)
            {
                Console.WriteLine("Який тип вагона ви хочете додати? (1 - пасажирський, 2 - спальний, 3 - ресторан, 4 - вантажний)");
                int CarriageType = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Скільки вагонів ви хочете додати?");
                int CarriageCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                for (int i = 0; i < CarriageCount; i++)
                {
                    AddCarriage(CarriageType);
                }
                Console.WriteLine("Бажаєте додати інший тип вагону? (1 - так, 2 - ні)");
                string User = Console.ReadLine();
                Console.WriteLine("------------------------------------------------------");
                switch (User)
                {
                    case "1":
                        AddingCarriages = true;
                        break;
                    case "2":
                        AddingCarriages = false;
                        break;
                    default:
                        AddingCarriages = false;
                        break;
                }
            }
            Console.Clear();
            RemoveCarriage();
            Console.Clear();
        }
        public void AddCarriage (int CarriageType)
        {
            string id = (Carriages.Count + 1).ToString();
            switch (CarriageType)
            {
                case 1:
                    if (Carriages.Any(c => c is FrightCarrige))
                    {
                        Console.WriteLine("Пасажирський вагон не може існувати у потязі разом з вантажними вагонами \n" +
                            "------------------------------------------------------");
                        return;
                    }
                    PassengerCarrige PasCarriage = new PassengerCarrige(75, id);
                    PasCarriage.LoadPas();
                    Carriages.Add(PasCarriage);
                    break;
                case 2:
                    if (Carriages.Any(c => c is FrightCarrige))
                    {
                        Console.WriteLine("Спальний вагон не може існувати у потязі разом з вантажними вагонами \n" +
                            "------------------------------------------------------");
                        return;
                    }
                    SleepingCarrige SleepCarriage = new SleepingCarrige(15, id);
                    SleepCarriage.LoadSleepPas();
                    Carriages.Add(SleepCarriage);
                    break;
                case 3: 
                    DiningCarriage diningCarriage = new DiningCarriage (id, true);
                    diningCarriage.LoadDining();
                    Carriages.Add(diningCarriage);
                    break;
                case 4:
                    if (Carriages.Any(c => c is PassengerCarrige))
                    {
                        Console.WriteLine("Вантажний вагон не може існувати у потязі разом з пасажирськими вагонами \n" + "------------------------------------------------------");
                        return;
                    }
                    FrightCarrige frightCarrige = new FrightCarrige (id);
                    frightCarrige.LoadFright();
                    Carriages.Add (frightCarrige);
                    break;
                  

                
                    
            }
        }
        public void ShowCarriages()
        {
            Console.WriteLine("Список всіх вагонів:\n" +
                "----------------------------------------------------");
            foreach (Carriage carriage in Carriages)
            {
                Console.WriteLine($"ID: {carriage.Id}, Тип: {carriage.Type}");
                if (carriage is PassengerCarrige passengerCarriage)
                {
                    Console.WriteLine($"Кількість пасажирів: {passengerCarriage.Passengers}\n" +
                                      $"Максимальна кількість місць: {passengerCarriage.seatsCount}\n" +
                                      $"Рівень комфорту: {passengerCarriage.comfortLevel}\n" +
                                      $"------------------------------------------------------");
                }
                else if (carriage is SleepingCarrige sleepingCarrige)
                {
                    Console.WriteLine($"Кількість пасажирів: {sleepingCarrige.Passengers}\n" +
                                     $"Максимальна кількість місць: {sleepingCarrige.maxPassengers}\n" +
                                     $"Чи є душові кабінки: {sleepingCarrige.hasShowers}\n" +
                                     $"Кількість купе: {sleepingCarrige.compartmensCount}\n" +
                                     $"------------------------------------------------------");
                }
                else if (carriage is DiningCarriage diningCarriage)
                {
                    Console.WriteLine($"Кількість обідів: {diningCarriage.currentdinners}\n" +
                                     $"Максимальна кількість обідів: {diningCarriage.maxdinners}\n" +
                                     $"Чи є кухня: {diningCarriage.hasKitchen}\n" +
                                     $"Кількість столиків: {diningCarriage.tablesCount}\n" +
                                     $"------------------------------------------------------");
                }
                else if (carriage is FrightCarrige frightCarrige)
                {
                    Console.WriteLine($"Тип матеріалу: {frightCarrige.CargoType}\n" +
                                     $"Вага вантажу: {frightCarrige.Load} \n" +
                                     $"Максимальная допустима вага: {frightCarrige.maxLoadCapacity}\n" +
                                     $"------------------------------------------------------");
                }
            }
        }
        public void RemoveCarriage()
        {
            string DeleteOrNot = "";
            while (true)
            {
                ShowCarriages();
                Console.WriteLine("Бажаєте видалити вагон ? (1 - так, 2 - ні)");
                DeleteOrNot = Console.ReadLine();
                switch (DeleteOrNot)
                {
                    case "1":
                        Console.Write("Введіть номер вагону, який ви хочете видалити: ");
                        int IdOfDeletedCarriage = Convert.ToInt32(Console.ReadLine());
                        if (IdOfDeletedCarriage > 0 && IdOfDeletedCarriage <= Carriages.Count)
                        {
                            Carriages.RemoveAt(IdOfDeletedCarriage - 1);
                            for (int i = IdOfDeletedCarriage - 1; i < Carriages.Count; i++)
                            {
                                Carriages[i].Id = (i + 1).ToString();
                            }
                            Console.WriteLine("Вагон успішно видалено, натисність Enter щоб продовдити \n");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Вагону з таким ID не існує, натисність Enter щоб продовдити \n");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Введіть 1, щоб видалити вагон, або 2, щоб завершити");
                        break;
                }
            }
        }
        public int SumPassangers()
        {
            int sumpas = 0;
            foreach(var carriage in Carriages)
            {
                if (carriage is PassengerCarrige passengerCarriage)
                {
                    sumpas+=passengerCarriage.Passengers;
                }
                else if (carriage is SleepingCarrige sleepingCarriage)
                {
                    sumpas+=sleepingCarriage.Passengers;
                }
                else
                {
                    sumpas += 0;
                }
            }
            return sumpas;
        }
        public void Filtcar()
        {
            while (true)
            {
                int filtcar = 0;
                Console.WriteLine("Чи хочете побачити інформацію тільки про деякі види не вьем забіл как назівается(1 - так 2 ні)");
                filtcar = Convert.ToInt32(Console.ReadLine());
                if (filtcar == 2) return;
                Console.Clear();
                Console.WriteLine("Які вагони ви хочете побачити(............)");
                filtcar = Convert.ToInt32(Console.ReadLine());

                foreach (Carriage carriage in Carriages)
                {
                    switch (filtcar)
                    {
                        case 1:
                            if (carriage is PassengerCarrige passengerCarriage)
                            {
                                Console.WriteLine($"ID: {carriage.Id}, Тип: {carriage.Type}");
                                Console.WriteLine($"Кількість пасажирів: {passengerCarriage.Passengers}\n" +
                                                  $"Максимальна кількість місць: {passengerCarriage.seatsCount}\n" +
                                                  $"Рівень комфорту: {passengerCarriage.comfortLevel}\n" +
                                                  $"------------------------------------------------------");
                            }; 
                            break;
                        case 2:
                            if (carriage is SleepingCarrige sleepingCarrige)
                            {
                                Console.WriteLine($"ID: {carriage.Id}, Тип: {carriage.Type}");
                                Console.WriteLine($"Кількість пасажирів: {sleepingCarrige.Passengers}\n" +
                                                 $"Максимальна кількість місць: {sleepingCarrige.maxPassengers}\n" +
                                                 $"Чи є душові кабінки: {sleepingCarrige.hasShowers}\n" +
                                                 $"Кількість купе: {sleepingCarrige.compartmensCount}\n" +
                                                 $"------------------------------------------------------");
                            };
                            break;
                        case 3:
                            if (carriage is DiningCarriage diningCarriage)
                            {
                                Console.WriteLine($"ID: {carriage.Id}, Тип: {carriage.Type}");
                                Console.WriteLine($"Кількість обідів: {diningCarriage.currentdinners}\n" +
                                                 $"Максимальна кількість обідів: {diningCarriage.maxdinners}\n" +
                                                 $"Чи є кухня: {diningCarriage.hasKitchen}\n" +
                                                 $"Кількість столиків: {diningCarriage.tablesCount}\n" +
                                                 $"------------------------------------------------------");
                            };
                            break;
                        case 4:
                            if (carriage is FrightCarrige frightCarrige)
                            {
                                Console.WriteLine($"ID: {carriage.Id}, Тип: {carriage.Type}");
                                Console.WriteLine($"Тип матеріалу: {frightCarrige.CargoType}\n" +
                                                 $"Вага вантажу: {frightCarrige.Load} \n" +
                                                 $"Максимальная допустима вага: {frightCarrige.maxLoadCapacity}\n" +
                                                 $"------------------------------------------------------");
                            };
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void UpdateTrain()
        {
            while (true)
            {
                ShowCarriages();
                Console.WriteLine("Бажаєте відредагувати вагони?(1 - так 2 - ні)");
                int usup = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                if (usup == 1)
                {
                    Console.WriteLine("Який вагон ви хочете відредагувати: (введіть id вагону)");
                    int idcar = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------");
                    foreach (var carriage in Carriages)
                    {
                        if (idcar == Convert.ToInt32(carriage.Id))
                        {
                            if (carriage is PassengerCarrige passengerCarriage)
                            {
                                passengerCarriage.UpdatingPassengerCarriage();
                            }
                            else if (carriage is SleepingCarrige sleepingCarriage)
                            {
                                sleepingCarriage.UpdatingSleepingCarriage();
                            }
                            else if (carriage is DiningCarriage diningCarriage)
                            {
                                diningCarriage.UpdatingDiningCarriage();
                            }
                            else if (carriage is FrightCarrige frightCarriage)
                            {
                                frightCarriage.UpdatingFrightCarriage();
                            }
                        }
                    }
                }
                else { return; }
            }
        }
        public void TrainSim()
        {
            Console.Clear();
            Console.WriteLine("Введіть довжину маршруту (км):");
            way = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Поїзд починає рух, натисніть Enter щоб продовжити\n" + "------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            Random random = new Random();
            int stop = 0;
            int waystop = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"Зупинка: #{++stop}");
                stops = random.Next( 50, 100 );
                waystop += stops;
                Console.WriteLine("Від попередньої зупинки поїзд " + Name + $" проїхав {stops} км \n" +
                                 $"Від початку маршруту - {waystop} км, натисніть Enter, щоб продовжити");
                Console.ReadLine();
                Console.Clear();
                Filtcar();
                Console.Clear();
                UpdateTrain();

            }while ( waystop < way );
            Console.Clear();
            Console.WriteLine("Вітаю! Ви проїхали весь запланований вами маршрут! \n" +
                              "Ось всі дані про потяг: \n" +
                              "------------------------------------------------------\n" +
                              $"Назва потягу: {Name} \n" +
                              $"Загальний подоланий шлях: {waystop} \n" +
                              $"Кількість зупинок: {stop}\n"+
                              $"Витрачений час на подорож (при швидкості 60 км/год) :{Math.Round(waystop / 60.0, 1)}\n"+
                              $"Загальна кількість пасажирів: {SumPassangers()}");
            ShowCarriages();
            Console.ReadLine ();

        }

    }
}
