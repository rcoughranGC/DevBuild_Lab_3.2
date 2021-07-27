using System;
using System.Collections.Generic;

namespace DevBuild_Lab3_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, decimal> menu = new Dictionary<string, decimal>();
            menu["Nachos"] = 4.99m;
            menu["Hot Dog"] = 2.99m;
            menu["Small Popcorn"] = 2.99m;
            menu["Large Popcorn"] = 4.99m;
            menu["Giant Pretzel"] = 3.99m;
            menu["Super Nachos"] = 8.99m;
            menu["Domestic Beer"] = 3.99m;
            menu["Imported Beer"] = 4.99m;
            menu["Bottled Water"] = 2.99m;

            Console.WriteLine(" ~  CURRENT MENU  ~ ");
            Console.WriteLine("_____________________");
            foreach (var item in menu)
            {
                Console.Write(item.Key.PadRight(17));
                Console.WriteLine(item.Value);
            }

            bool quit = false;
            while (!quit)
            {
                bool itemAlreadyExists = false;
                Console.WriteLine("\nPress: A to add item | R to remove item | C to change a price | V to view menu | Q to quit");
                string input = Console.ReadLine().ToUpper();

                if (input == "A")
                {
                    Console.Write("Please enter the name of the new item: (or type CANCEL) ");
                    string newItem = Console.ReadLine();
                    if (newItem.ToUpper().Trim() != "CANCEL")
                    {
                        foreach (var item in menu) //CheckForItem
                        {
                            if (item.Key.ToLower() == newItem.ToLower().Trim())
                            {
                                Console.WriteLine("Item was already found on the menu.");
                                itemAlreadyExists = true;
                            }
                        }
                        if (itemAlreadyExists == false)
                        {
                            Console.Write($"Please enter the price of {newItem} ");
                            decimal newItemPrice = decimal.Parse(Console.ReadLine());
                            menu[newItem] = newItemPrice;
                            Console.WriteLine("Added!");
                        }
                    }
                    
                }
                else if (input == "R")
                {
                    Console.Write("Please enter the name of the item to be removed: (or type CANCEL) ");
                    string removeItem = Console.ReadLine();
                    if (removeItem.ToUpper().Trim() != "CANCEL")
                    {
                        //Check for item
                        foreach (var item in menu)
                        {
                            if (item.Key.ToLower() == removeItem.ToLower().Trim())
                            {
                                removeItem = item.Key; //correct casing differences
                                itemAlreadyExists = true;
                            }
                        }
                        if (itemAlreadyExists)
                        {
                            Console.WriteLine($"{removeItem} removed.");
                            menu.Remove(removeItem);
                        }
                        else
                        {
                            Console.WriteLine("Item was not found. Please try again.");
                        }
                    }
                        
                }
                else if (input == "C")
                {
                    Console.Write("Please enter the name of the item: (or type CANCEL) ");
                    string changeItem = Console.ReadLine();
                    if (changeItem.ToUpper().Trim() != "CANCEL")
                    {
                        //Check for item
                        foreach (var item in menu)
                        {
                            if (item.Key.ToLower() == changeItem.ToLower().Trim())
                            {
                                changeItem = item.Key; //correct casing differences
                                itemAlreadyExists = true;
                            }
                        }
                        if (itemAlreadyExists)
                        {
                            Console.Write($"\n**{changeItem} is currently priced at {menu[changeItem]}** \nEnter the new price: (or type CANCEL) ");
                            string enteredPrice = Console.ReadLine();
                            if (enteredPrice.ToUpper().Trim() != "CANCEL")
                            {
                                Decimal.TryParse(enteredPrice, out decimal newPrice);
                                while (newPrice == 0)
                                {
                                    Console.Write("Invalid price. Please re-enter: ");
                                    Decimal.TryParse(Console.ReadLine(), out newPrice);
                                }
                                Console.WriteLine($"{changeItem} changed from {menu[changeItem]} to {newPrice}");
                                menu[changeItem] = newPrice;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Item was not found. Please try again.");
                        }
                    }
                        
                }
                else if (input == "V")
                {
                    Console.WriteLine();
                    Console.WriteLine(" ~  CURRENT MENU  ~ ");
                    Console.WriteLine("_____________________");
                    foreach (var item in menu)
                    {
                        Console.Write(item.Key.PadRight(17));
                        Console.WriteLine(string.Format($"{item.Value:0.00}"));
                        //Console.WriteLine(string.Format($"{item.Key}: {item.Value:0.00}"));
                    }
                }
                else if (input == "Q")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection" + "\nPlease enter A, R, C, V, or Q");
                }
            }
        }
    }
}
