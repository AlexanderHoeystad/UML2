using System;
using System.Collections.Generic;
namespace UML2
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;
        Dictionary<int, Pizza> _items;
        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
            _items = new Dictionary<int, Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
            _items.Add(p.Number, p);
        }


        public  Pizza Read(int Number)
        {
            foreach(var p in _pizzas) 
            {
                if (p.Number == Number)
                {
                    return p;
                }
            }
            return null;
            //return _pizzas.Find(p => p.Number == Number);
            //return _pizzas[Number];
        }

        public void Update(Pizza p)
        {
            _pizzas[p.Number] = p;
        }

        public void Delete(int Number)
        {
            if (_pizzas.Contains(_pizzas[Number]))
            {
                _pizzas.Remove(_pizzas[Number]);
            }
        }

        public void PrintMenu()
        {
            foreach (Pizza p in _pizzas) 
            {
                Console.WriteLine(p);
            }
        }

    }
}