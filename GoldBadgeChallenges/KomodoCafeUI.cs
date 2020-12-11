using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    class KomodoCafeUI
    {
        private KomodoCafeMenuRepository _menuList = new KomodoCafeMenuRepository();

        public void Run()
        {
            SeedMenuList();
            UIMenu();
        }
        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Enter the number associated with the menu number below:\n" +
                    "1. Add item to menu\n" +
                    "2. Remove item from menu\n" +
                    "3. View all menu items on list.\n" +
                    "4. Exit application\n");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        ViewMenuItemsList();
                        break;
                    case "4":
                        Console.WriteLine("Thanks, goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddMenuItem()
        {
            Console.Clear();
            KomodoCafeMenu newMenuItem = new KomodoCafeMenu();

            Console.WriteLine("Enter the meal number for the new menu item.");
            newMenuItem.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name of the new menu item.");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description for the new menu item.");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the ingredients for the new menu item.");
            newMenuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter the price for the new menu item.");
            newMenuItem.Price = decimal.Parse(Console.ReadLine());

            _menuList.AddMenuItemToList(newMenuItem);
        }
        private void ViewMenuItemsList()
        {
            Console.Clear();
            List<KomodoCafeMenu> listofMenuItems = _menuList.GetMenuItemsList();

            foreach(KomodoCafeMenu menuItem in listofMenuItems)
            {
                Console.WriteLine($"Meal Number: {menuItem.MealNumber}\n" +
                    $"Meal Name: {menuItem.MealName}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Ingredients: {menuItem.Ingredients}\n" +
                    $"Price: ${menuItem.Price}\n\n");
            }
        }
        private void RemoveMenuItem()
        {
            ViewMenuItemsList();
            Console.WriteLine("\n Enter the meal number of the menu item you'd like to remove.");
            int mealNumber = int.Parse(Console.ReadLine());

            bool wasRemoved = _menuList.RemoveMenuItemFromList(mealNumber);

            if (wasRemoved)
            {
                Console.WriteLine("The menu item was removed successfully.");
            }
            else
            {
                Console.WriteLine("I had some trouble removing that menu item. Try again.");
            }
        }
        private void SeedMenuList()
        {
            KomodoCafeMenu A = new KomodoCafeMenu(1, "Burger", "2 patty burger and fries", "Patty, bun, tomato, lettuce, onion, ketchup, mustard, pickle, special sauce, potatoes", 7.25m);
            KomodoCafeMenu B = new KomodoCafeMenu(2, "Nachos", "Chips, veggies and special sauce--a customer favorite!", "Tortilla chips, black olives, onions, tomatoes, bell peppers, special sauce", 8.50m);
            KomodoCafeMenu C = new KomodoCafeMenu(3, "Chili", "Hearty bean chili bowl to keep you warm in the winter!", "Beans, tomatoes, onions, jalapenos, rice, special sauce", 6.25m);

            _menuList.AddMenuItemToList(A);
            _menuList.AddMenuItemToList(B);
            _menuList.AddMenuItemToList(C);
        }
    }
}
