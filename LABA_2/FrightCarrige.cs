using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2
{
    public enum CargoList
    {
        Metal = 1,
        Wood = 2,
        Plastic = 3,
        Glass = 4,
        Gas = 5,
        Oil = 6,
        Other = 7,
    }
    internal class FrightCarrige: Carriage
    {
        public double maxLoadCapacity {  get; set; }
        public CargoList cargoType { get; set; }
        public string CargoType {  get; set; }
        public double Load { get; set; }
        public FrightCarrige(string id) : base("Fright", id)
        {
            Load = 0;
        }
        public void LoadFright()
        {
            Console.WriteLine("Оберіть матеріал, який буде перевезений вантажним вагоном:");
            foreach (var cargo in Enum.GetValues(typeof(CargoList)))
            {
               Console.WriteLine($"{(int)cargo}.{cargo}");
            }
            CargoList chosenCargo = (CargoList)Enum.Parse(typeof(CargoList), Console.ReadLine());
            Console.WriteLine("------------------------------------------------------");
            CargoType = chosenCargo.ToString();
            if (chosenCargo == CargoList.Other)
            {
                Console.Write("Введіть назву матеріалу: ");
                CargoType = Console.ReadLine();
            }
            switch (chosenCargo)
            {
                case CargoList.Metal:
                    maxLoadCapacity = 100;
                    break;
                case CargoList.Wood:
                    maxLoadCapacity = 90;
                    break;
                case CargoList.Plastic:
                    maxLoadCapacity = 80;
                    break;
                case CargoList.Glass:
                    maxLoadCapacity = 50;
                    break;
                case CargoList.Gas:
                case CargoList.Oil:
                case CargoList.Other:
                    maxLoadCapacity = 120;
                    break;
            }
            double cargoWeight;
            do
            {
                Console.Write("Введіть вагу вантажу: (кг)");
                cargoWeight = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                if (cargoWeight > maxLoadCapacity)
                {
                    Console.WriteLine("Вага вантажу не може перевидщувати макисмальне значення (максимум - {0})", maxLoadCapacity);
                }
            }while(cargoWeight > maxLoadCapacity);

            Load = cargoWeight;
            Console.WriteLine($"Вантаж {CargoType} завантажено.");
            Console.Clear();

        }
        public void UpdatingFrightCarriage()
        {
            while (true)
            {
                Console.WriteLine("Дані вагону: \n" +
                                          $"Тип матеріалу: {CargoType}\n" +
                                          $"Вага вантажу: {Load} \n" +
                                          $"Максимальная допустима вага: {maxLoadCapacity}\n" +
                                          $"------------------------------------------------------");
                Console.WriteLine("Бажаєте завантажити чи розвантажити вагон ? (1 - завантажити, 2 - розвантажити, 3 - повністю розвантажити,  4 - продовжити з таким самим вантажом)");
                int LoadPas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------");
                int frig;
                switch (LoadPas)
                {
                    case 1:
                        if (CargoType!="")
                        {
                            Console.Write("Яку кількість вантажу ви хочете завантажити: (кг)");
                            frig = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (frig + Load <= maxLoadCapacity)
                            {
                                Load += frig;
                                Console.WriteLine($"Завантажено ще {frig} кг вантажу, натисніть Enter щоб продовжити");
                                Console.ReadLine();
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Сумарна вага вантажу не може перевищувати максимальну вантажопідйомність вагону");
                            }
                        }
                        else
                        {
                            LoadFright();
                            return;
                        }
                        break;
                    case 2:
                        if (Load == 0)
                        {
                            Console.WriteLine("Пустий вагон розвантажити не можна");
                        }
                        else
                        {
                            Console.Write("Яку кількість вантажу ви хочете розвантажити: (кг) ");
                            frig = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (frig + Load > maxLoadCapacity)
                            {
                                Load -= frig;
                                Console.WriteLine($"Розвантажено {frig} кг вантажу, нажміть Enter щоб продовжити");
                                Console.ReadLine();
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Неможна розвантажити більше кг ванжтажу, ніж є у вагоні");
                            }
                        }
                        break;
                    case 3:
                        CargoType = "";
                        Load = 0;
                        maxLoadCapacity = 0;
                        Console.WriteLine("Вагон повністю розвантажено, нажміть Enter щоб продовжити");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Невідома відповідь");
                        break;
                }

            }

        }
    }
}
