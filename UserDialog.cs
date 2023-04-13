using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UML2
{
    internal class UserDialog
    {
        MenuCatalog _menuCatalog;
        public UserDialog(MenuCatalog menuCatalog)
        {
            _menuCatalog=menuCatalog;
        }

        Pizza UpdateNewPizza()
        {
            Pizza updatedpizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("| Updating Pizza      |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter name of the pizza which you want to update: ");
            updatedpizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter new price: ");
            try
            {
                input = Console.ReadLine();
                updatedpizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter new pizza number: ");
            try
            {
                input = Console.ReadLine();
                updatedpizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            return updatedpizzaItem;
        }

        Pizza GetNewPizza()
        {
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("| Creating Pizza      |");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Enter name: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter pizza number: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            return pizzaItem;
        }
        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("| BIG MAMMA PIZZAMENU |");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Quit",
                "1. Create Pizza",
                "2. Print menu",
                "3. Search for pizza",
                "4. Update pizza",
                "5. Delete Pizza",
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0: //Quit
                        
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;

                    case 1: // Create Pizza
                        
                        try
                        {
                            Pizza pizza = GetNewPizza();
                            _menuCatalog.Create(pizza);
                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                       
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    
                    case 2: // Print Menu
                       
                        _menuCatalog.PrintMenu();
                        Console.Write("Hit any key to continue");
                       
                        Console.ReadKey();
                        break;
                    
                    case 3: // Serach for pizza
                        
                        Console.WriteLine($"You selected: {mainMenulist[MenuChoice]}");
                        Console.WriteLine($"Enter pizza number to search");
                        try
                        {
                            int PickedNumber = int.Parse(Console.ReadLine());
                            Console.WriteLine($"You picked number: {PickedNumber}");
                            Console.WriteLine($"You searched for pizza: {_menuCatalog.Read(PickedNumber).Number}");

                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                            Console.WriteLine();
                            Console.WriteLine($"The pizza you searched for was not found");
                        }


                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    
                    case 4: // Update Pizza

                      
                        try
                        {
                            Pizza pizza = UpdateNewPizza();
                            _menuCatalog.Update(pizza);
                            Console.WriteLine($"You updated: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza updated");
                        }

                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;

                    case 5: // Delete Pizza

                        Console.WriteLine($"You selected: 5. Delete Pizza");
                        Console.WriteLine($"Enter the number of the pizza, that you want to delete");
                        try
                        {
                            int PickedNumberD = int.Parse(Console.ReadLine());
                            Console.WriteLine($"You have picked pizza number: {PickedNumberD}, the pizza has been deleted");
                            _menuCatalog.Delete(PickedNumberD);
                        }

                        catch (Exception D)
                        {
                            Console.Write(D.Message);
                            Console.WriteLine();
                            Console.WriteLine($"The pizza does not exist and cannot be removed");
                        }

                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;
                }
            }

        }
    }
}
