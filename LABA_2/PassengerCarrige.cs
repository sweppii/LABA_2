using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2
{
    internal class PassengerCarrige : Carriage
    {
        public int seatsCount { get; set; }
        public string comfortLevel { get; set; }
        public int Passengers { get; set; }
        public PassengerCarrige(int SeatsCount, string Id) : base("Passenger", Id)
        {
            seatsCount = SeatsCount;
        }
        public void LoadPas()
        {
            int pas;
            do
            {
                Console.WriteLine("Введіть кількість пасажирів:");
                pas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                if (pas > seatsCount)
                {
                    Console.WriteLine("Кількість пасажирів не може перевищувати кількість місць (місць 75)");
                }
            } while (pas > seatsCount);
            Console.WriteLine("Який буде рівень комфорту даного вагону: (1-Економ 2-Стандарт 3-Бізнес 4-Люкс) ");
            int comlev = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (comlev)
            {
                case 1:
                    comfortLevel = "Економ";
                    break;
                case 2:
                    comfortLevel = "Стандарт";
                    break;  
                case 3:
                    comfortLevel = "Бізнес";
                    break;
                case 4:
                    comfortLevel = "Люкс";
                    break;
            }
            Passengers = pas;

        }
        public void UpdatingPassengerCarriage()
        {
            while (true)
            {
                Console.WriteLine("Бажаєте висадити чи підсадити пассажирів ? (1 - висадити, 2 - підсадити, 3 - продовжити з тими ж пассажирами)");
                int LoadPas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                int pas;
                switch (LoadPas)
                {
                    case 1:
                        Console.Write("Введіть кількість пасажирів які вийдуть з вагону: ");
                        pas = int.Parse(Console.ReadLine());
                        Console.WriteLine("------------------------------------------------------");

                        if (pas <= Passengers)
                        {
                            Passengers -= pas;
                            Console.WriteLine($"Висаджено {pas} пасажирів");
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("З вагона не може вийти більше пасажирів, ніж там вже є \n" +
                                "------------------------------------------------------");
                        }
                        break;
                    case 2:
                        Console.Write("Введіть кількість пасажирів які сядуть у вагон: ");
                        pas = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("------------------------------------------------------");
                        if (pas+Passengers <= seatsCount)
                        {
                            Passengers += pas;
                            Console.WriteLine($"Завантажено {pas} пасажирів ");
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Кількість пасажирів не може перевищувати кількість місць");
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Невідома відповідь \n" + "------------------------------------------------------");
                        break;
                }

            }

        }
    }
}
