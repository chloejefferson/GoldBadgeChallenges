using RepoKomodoOutings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppKomodoOutings
{
    
    class KomodoOutingsUI
    {
        private KomodoOutingRepo _repo = new KomodoOutingRepo();
        
        public void Run()
        {
            SeedOutingsList();
            UIMenu();
        }

        public void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Enter the number associated with the menu item you'd like to select below:\n" +
                    "1. Add an outing\n" +
                    "2. View all outings\n" +
                    "3. View total cost of outings\n" +
                    "4. View total cost of outings by event type\n" +
                    "5. Exit application\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddOuting();
                        break;
                    case "2":
                        ViewOutings();
                        break;
                    case "3":
                        CalculateTotalCostOfOutings();
                        break;
                    case "4":
                        CalculateTotalCostOfOutingsByType();
                        break;
                    case "5":
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

        public void AddOuting()
        {
            Console.Clear();
            KomodoOuting outing = new KomodoOuting();

            Console.WriteLine("What is the event type? Enter the corresponding number below:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            outing.EventType = (EventTypeEnum)int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of attendees.");
            outing.NumberOfAttendees = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the event MM/DD/YYY.");
            outing.DateOfEvent = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the cost per person using numbers and decimal point only.");
            outing.CostPerPerson = decimal.Parse(Console.ReadLine());

            _repo.AddOutingToRepo(outing);

        }

        public void ViewOutings()
        {
            Console.Clear();
            List<KomodoOuting> outingList = _repo.GetAllOutings();

            string tableHeaders = String.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}\n\n", "ID:", "Type:", "Number of Attendees:", "Date of Event:", "Cost Per Person:", "Total Event Cost:");
            Console.WriteLine(tableHeaders);

            foreach (KomodoOuting outing in outingList)
            {
                string tableBody = String.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}\n\n", outing.EventId, outing.EventType, outing.NumberOfAttendees, outing.DateOfEvent.ToShortDateString(), outing.CostPerPerson.ToString("C"), outing.TotalEventCost.ToString("C"));
                Console.WriteLine(tableBody);
            }
        }

        public void CalculateTotalCostOfOutings()
        {
            Console.Clear();
            List<KomodoOuting> outingList = _repo.GetAllOutings();

            decimal totalcost = 0;

            foreach (KomodoOuting outing in outingList)
            {
                totalcost += outing.TotalEventCost;
            }

            Console.WriteLine($"The total costs of all outings is {totalcost.ToString("C")}.");

        }

        public void CalculateTotalCostOfOutingsByType()
        {
            Console.Clear();
            List<KomodoOuting> outingList = _repo.GetAllOutings();

            decimal golfTotalCost = 0;
            decimal bowlingTotalCost = 0;
            decimal amusementParkTotalCost = 0;
            decimal concertTotalCosts = 0;

            foreach (KomodoOuting outing in outingList)
            {
                if (outing.EventType == EventTypeEnum.Golf)
                {
                    golfTotalCost += outing.TotalEventCost;
                }
                else if (outing.EventType == EventTypeEnum.Bowling)
                {
                    bowlingTotalCost += outing.TotalEventCost;
                }
                else if (outing.EventType == EventTypeEnum.AmusementPark)
                {
                    amusementParkTotalCost += outing.TotalEventCost;
                }
                else if (outing.EventType == EventTypeEnum.Concert)
                {
                    concertTotalCosts += outing.TotalEventCost;
                }
            }

            string tableHeaders = String.Format("{0,-20} {1,-20} {2,-20} {3,-20}\n\n", "Golf:", "Bowling:", "Amusement Park:", "Concert:");
            string tableBody = String.Format("{0,-20} {1,-20} {2,-20} {3,-20}\n\n", golfTotalCost.ToString("C"), bowlingTotalCost.ToString("C"), amusementParkTotalCost.ToString("C"), concertTotalCosts.ToString("C"));

            Console.WriteLine("Total cost of all events by type:");
            Console.WriteLine(tableHeaders);
            Console.WriteLine(tableBody);
        }

        public void SeedOutingsList()
        {
            var A = new KomodoOuting(EventTypeEnum.AmusementPark, 10, new DateTime(2020, 01, 20), 50);
            var B = new KomodoOuting(EventTypeEnum.Bowling, 30, new DateTime(2020, 02, 20), 20);
            var C = new KomodoOuting(EventTypeEnum.Concert, 25, new DateTime(2020, 03, 01), 15);
            var D = new KomodoOuting(EventTypeEnum.Golf, 40, new DateTime(2020, 06, 06), 40);
            var E = new KomodoOuting(EventTypeEnum.Golf, 20, new DateTime(2020, 07, 01), 40);
            var F = new KomodoOuting(EventTypeEnum.Bowling, 5, new DateTime(2020, 08, 30), 15);

            _repo.AddOutingToRepo(A);
            _repo.AddOutingToRepo(B);
            _repo.AddOutingToRepo(C);
            _repo.AddOutingToRepo(D);
            _repo.AddOutingToRepo(E);
            _repo.AddOutingToRepo(F);
        }
    }
}
