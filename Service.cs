using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee
{
   
    public class Service
    {
        public List<Coffee> Coffees { get; set; } = new List<Coffee>();
        public List<Addition> Additions { get; set; } = new List<Addition>();
        public int ShiftCheck { get; set; }
        
        public List<Coffee> GetCoffees() 
        {
            Coffees.Add(new Coffee
            {
                Title = "Эспрессо",
                Price = 50,
            });
            Coffees.Add(new Coffee
            {
                Title = "Американо",
                Price = 60,
            });
            Coffees.Add(new Coffee
            {
                Title = "Капучино",
                Price = 80,
            });
            Coffees.Add(new Coffee
            {
                Title = "Латте",
                Price = 85,
            });
            Coffees.Add(new Coffee
            {
                Title = "Чай",
                Price = 40,
            });
            return Coffees; 
        }

        public List<Addition> GetAdditions() 
        {

            Additions.Add(new Addition
            {
                Title = "Молоко",
                Price = 10
            });
            Additions.Add(new Addition
            {
                Title = "Сахар",
                Price = 0
            });
            Additions.Add(new Addition
            {
                Title = "Сироп ванильный",
                Price = 15
            });
            Additions.Add(new Addition
            {
                Title = "Сироп карамельный",
                Price = 15
            });
            Additions.Add(new Addition
            {
                Title = "Взбитые сливки",
                Price = 20
            });
            Additions.Add(new Addition
            {
                Title = "Корица",
                Price = 5
            });
            Additions.Add(new Addition
            {
                Title = "Нет",
                Price = 0
            });

            return Additions;
        }
    }
}
