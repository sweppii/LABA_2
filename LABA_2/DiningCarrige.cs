using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2
{
    internal class DiningCarriage : Carriage
    {
        public int tablesCount { get; set; }
        public bool hasKitchen { get; set; }
        public int maxdinners { get; set; }
        public int currentdinners {  get; set; }
        public DiningCarriage(string id, bool HasKitchen) : base("Dining", id)
        {
            tablesCount = 30;
            HasKitchen = hasKitchen;
            maxdinners = 200;
        }
        public void LoadDining()
        {
            int dinners;
            do
            {
                Console.WriteLine("Введіть кількість обідів:");
                dinners = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (dinners > maxdinners)
                {
                    Console.WriteLine("Кількість обідів не може перевищувати макисмальну кількість (максимум - {0})]\n" + "------------------------------------------------------", maxdinners);
                }
            }
            while (dinners > maxdinners);
            currentdinners = dinners;
        }
        public void UpdatingDiningCarriage()
        {
            while (true)
            {
                Console.WriteLine("Бажаєте поповнити кількість обідів ? (1 - так, 2 - ні)");
                int LoadPas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                int din;
                switch (LoadPas)
                {
                    case 1:
                        Console.Write("Введіть кількість обідів для поповнення: ");
                        din = int.Parse(Console.ReadLine());
                        Console.Clear();

                        if (din + currentdinners <= maxdinners)
                        {
                            currentdinners += din;
                            Console.WriteLine($"Додано {din} обідів \n" +
                                $"------------------------------------------------------");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Сумарна кількість обідів не може перевищувати максимальну кількість (максимум - 200) \n " +
                                "------------------------------------------------------");
                        }
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Невідома відповідь \n" + "------------------------------------------------------");
                        break;
                }

            }

        }
    }
}
