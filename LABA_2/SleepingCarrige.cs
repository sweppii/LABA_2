using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2
{
    internal class SleepingCarrige : Carriage
    {
        public int compartmensCount {  get; set; }
        public bool hasShowers { get; set; }
        public int maxPassengers { get; set; }
        public int currentPassengers { get; set; }
        public SleepingCarrige(int compatmenCount, string id) : base("Sleeping", id)
        {
            compartmensCount = compatmenCount;
            maxPassengers = 60;
            currentPassengers = 0;
        }
        public void LoadSleepPas()
        {
            int pas;
            do
            {
                Console.WriteLine("Введіть кількість пасажирів:");
                pas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                if (pas > maxPassengers)
                {
                    Console.WriteLine("Кількість пасажирів не може перевищувати кількість місць (місць 60)");
                }
            } while (pas > maxPassengers);
            currentPassengers= pas;
            Console.WriteLine("Чи є душеві кабіни у вагоні? (1 - так, 2 - ні)");
            int temp = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (temp == 1)
            {
                hasShowers = true;
            }else if(temp != 1)
            {
                hasShowers = false;
            }
        }
        public void UpdatingSleepingCarriage()
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
                        Console.Clear();

                        if (pas <= currentPassengers)
                        {
                            currentPassengers -= pas;
                            Console.WriteLine($"Висаджено {pas} пасажирів");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("З вагона не може вийти більше пасажирів, ніж там вже є");
                        }
                        break;
                    case 2:
                        Console.Write("Введіть кількість пасажирів які сядуть у вагон: ");
                        pas = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (pas + currentPassengers <= maxPassengers)
                        {
                            currentPassengers += pas;
                            Console.WriteLine($"Завантажено {pas} пасажирів");
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
                        Console.WriteLine("Невідома відповідь");
                        break;
                }

            }

        }
    }

}
