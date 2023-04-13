using System;

namespace UML2
{
    public class Store
    {
        MenuCatalog menuCatalog;

        public Store()
        { 
            menuCatalog = new MenuCatalog();
        }
        public void Test()
        {
            Pizza p1 = new Pizza() { Number = 1, Name = "Hawaii", Price = 50 };
            menuCatalog.Create(p1);

            Pizza p2 =new Pizza() { Number = 2, Name = "Pepperoni", Price = 55 };
            menuCatalog.Create(p2);

            Pizza p3 =new Pizza() { Number = 3, Name = "Potato", Price = 60 };
            menuCatalog.Create(p3);

            Pizza p4 =new Pizza() { Number = 4, Name = "Kebab", Price = 65 };
            menuCatalog.Create(p4);

            Pizza p5 =new Pizza() { Number = 5, Name = "Vesuvio", Price = 70 };
            menuCatalog.Create(p5);

        }

        public void Run()
        {
            new UserDialog(menuCatalog).Run();

        }
    }
}