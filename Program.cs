namespace coffee
{
    public class Program
    {
        public static Service ServiceHere { get; set; } = new Service();
        public static List<Coffee> Coffees { get; set; } = ServiceHere.GetCoffees();
        public static List<Addition> Additions { get; set; } = ServiceHere.GetAdditions();
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите операцию");
                Console.WriteLine("1.Новый заказ");
                Console.WriteLine("2.Report");

                int.TryParse(Console.ReadLine(), out int operation);

                switch (operation)
                {
                    default:
                        Console.WriteLine("Неправильно введена операция - введите номер операции без лишних знаков");
                        break;

                    case 1:
                        CreateOrder();
                        break;

                    case 2:
                        Report();
                        break;

                }
            }
        }

        public static void CreateOrder()
        {
            Coffee coffeeChoiceded = new Coffee();

            Console.WriteLine("Выберите напиток");
            for(int i = 0; i < Coffees.Count; i++) 
            {
                Console.WriteLine($"{i+1}. {Coffees[i].Title}");
            }
            int.TryParse(Console.ReadLine(), out int coffeeChoiced);

            Console.WriteLine("Хотите отменить заказ? да/нет");
            string del = Console.ReadLine();
            if (del == "да")
            {
                Main();
            }
            else if (del == "нет")
            {
                AddAddition(Coffees[coffeeChoiced - 1]);
            }
            else
            {
                Console.WriteLine("неправильный ввод");
                Main();
            }
        }
        public static void Report()
        {
            Console.WriteLine($"Общая выручка - {ServiceHere.ShiftCheck}");
        }

        public static void CreateCheck(Coffee xoffee)
        {
            int allCheck2 = 0;

            string check = "=== ЧЕК === \n Напиток:";
            check += xoffee.Title;
            check += $" - {xoffee.Price}.";
            foreach (Addition addition in xoffee.Additions)
            {
                check += $"\n + {addition.Title} - {addition.Price} руб.";
                allCheck2 += addition.Price;
            }
            allCheck2 += xoffee.Price;
            check += $"Итого {allCheck2} руб.";

            ServiceHere.ShiftCheck += allCheck2;

            Console.WriteLine(check);

            Console.WriteLine("Хотите отменить заказ? да/нет");
            string del = Console.ReadLine();
            if (del == "да")
            {
                Main();
            }
            else if (del == "нет")
            {
                Console.WriteLine("Введите сумму наличными");
                int.TryParse(Console.ReadLine(), out int daliDeneg);
                string result = "";

                if (allCheck2 > daliDeneg)
                {
                    result += "Недостаточно средств";
                }
                else if (allCheck2 == daliDeneg)
                {
                    result += "Спасибо за покупку!";
                }
                else
                {
                    result += $"Ваша сдача {daliDeneg - allCheck2} руб.";
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("неправильный ввод");
                Main();
            }

           
        }

        public static void AddAddition(Coffee xoffee)
        {
            bool addAdd = true;
            bool addAdditionsSame = true;

            while(addAdd == true)
            {
                Console.WriteLine("Выберите добавку");
                for (int i = 0; i < Additions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Additions[i].Title}");
                }
                int.TryParse(Console.ReadLine(), out int additioChoiced);

                Console.WriteLine("Хотите отменить заказ? да/нет");
                string del = Console.ReadLine();
                if (del == "да")
                {
                    Main();
                }
                else if (del == "нет")
                {
                    if (xoffee.Additions.Count == 0)
                    {
                        xoffee.Additions.Add(Additions[additioChoiced - 1]);
                    }
                    else
                    {
                        foreach (Addition addition in xoffee.Additions)
                        {
                            if (addition == Additions[additioChoiced - 1])
                            {
                                Console.WriteLine("нельзя выбрать одну и ту же добавку");
                                addAdditionsSame = false;
                            }
                            else
                            {
                                addAdditionsSame = true;

                            }
                        }
                        if (addAdditionsSame = true)
                        {
                            xoffee.Additions.Add(Additions[additioChoiced - 1]);
                        }
                    }

                    Console.WriteLine("Добавить еще? да/нет");
                    string answer = Console.ReadLine();
                    if (answer == "да")
                    {
                        addAdd = true;
                    }
                    else
                    {
                        addAdd = false;
                        CreateCheck(xoffee);
                    }
                }
                else
                {
                    Console.WriteLine("неправильный ввод");
                    Main();
                }

              
            }
        }
    }
}
