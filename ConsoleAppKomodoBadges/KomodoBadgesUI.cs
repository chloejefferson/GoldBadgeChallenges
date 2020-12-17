using RepoKomodoBadges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppKomodoBadges
{
    class KomodoBadgesUI
    {
        private KomodoBadgeRepo _badgeRepo = new KomodoBadgeRepo();

        public void Run()
        {
            SeedBadgeList();
            UIMenu();
        }

        public void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Enter the number associated with the menu item you'd like to select below:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit application\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
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
        private void AddBadge()
        {
            Console.Clear();

            KomodoBadge newBadge = new KomodoBadge();
            _badgeRepo.AddABadge(newBadge);

            Console.WriteLine("Enter the doors you would like to make accessible for this new badge. Use ONLY A COMMA to separate each door.");
            List<string> listOfDoors = Console.ReadLine().ToUpper().Split(',').ToList();

            newBadge.Doors = listOfDoors;
        }

        private void EditBadge()
        {
            Console.Clear();
            ListBadges();

            Console.WriteLine("Enter the ID of the badge you'd like to edit.");

            int originalBadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("What would you like to do with the badge? Enter the corresponding number below:\n" +
                "1. Remove a door\n" +
                "2. Remove all doors\n" +
                "3. Add a door\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter the door you'd like to remove.");
                    string removeADoor = Console.ReadLine().ToUpper();
                    bool doorWasRemoved =_badgeRepo.RemoveADoor(originalBadgeId, removeADoor);
                    if (doorWasRemoved)
                    {
                        Console.WriteLine($"The door {removeADoor} has been successfully removed from badge ID {originalBadgeId}.");
                    }
                    else
                    {
                        Console.WriteLine($"The door {removeADoor} could not be removed from badge ID {originalBadgeId}.");
                    }
                    break;
                case "2":
                    bool doorsWereRemoved = _badgeRepo.RemoveAllDoors(originalBadgeId);
                    if (doorsWereRemoved)
                    {
                        Console.WriteLine($"All doors have been successfully removed from {originalBadgeId}.");
                    }
                    else
                    {
                        Console.WriteLine($"The doors could not be removed from {originalBadgeId}.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter the door you'd like to add.");
                    string addADoor = Console.ReadLine().ToUpper();
                    bool doorWasAdded = _badgeRepo.AddADoor(originalBadgeId, addADoor);
                    if (doorWasAdded)
                    {
                        Console.WriteLine($"The door {addADoor} has been successfully added to badge ID {originalBadgeId}.");
                    }
                    else
                    {
                        Console.WriteLine($"The door {addADoor} could not be added to badge ID {originalBadgeId}.");
                    }
                    break;
                default:
                    Console.WriteLine("I didn't understand your entry. You'll be returned to the main menu.");
                    break;
            }
        }

        private void ListBadges()
        {
            Console.Clear();
            Dictionary<int, KomodoBadge> badgeDictionary = _badgeRepo.GetBadgeDictionary();

            string tableHeaders = String.Format("{0,-20} {1,-40}", "ID:", "Accessible Doors:\n\n");
            Console.WriteLine(tableHeaders);

            foreach (var badge in badgeDictionary.Values)
            {
                string tableBody = String.Format("{0,-20}", badge.BadgeId);
                foreach (string door in badge.Doors)
                {
                    tableBody = tableBody + door + "  ";
                }
                Console.WriteLine(tableBody);
                Console.WriteLine();
            }
        }

        private void SeedBadgeList()
        {
            List<string> adminDoors = new List<string>();
            adminDoors.Add("A1");
            adminDoors.Add("A2");
            adminDoors.Add("A3");
            List<string> securityDoors = new List<string>();
            securityDoors.Add("A1");
            securityDoors.Add("A2");
            securityDoors.Add("A3");
            securityDoors.Add("A4");
            securityDoors.Add("A5");
            var A = new KomodoBadge(adminDoors);
            var B = new KomodoBadge(securityDoors);
            var C = new KomodoBadge(securityDoors);
            var D = new KomodoBadge(adminDoors);

            _badgeRepo.AddABadge(A);
            _badgeRepo.AddABadge(B);
            _badgeRepo.AddABadge(C);
            _badgeRepo.AddABadge(D);
        }
    }
}
