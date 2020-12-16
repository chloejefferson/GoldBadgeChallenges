using RepoKomodoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppKomodoClaims
{
    class KomodoClaimsUI
    {
        private KomodoClaimRepo _claimRepo = new KomodoClaimRepo();

        public void Run()
        {
            SeedClaimsList();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello. Please open the console app in full screen for optimal display readability.\n\n");
                Console.WriteLine("Enter the number associated with the menu item you'd like to select below:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim.\n" +
                    "4. Exit application\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewClaims();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        AddNewClaim();
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
        private void ViewClaims()
        {
            Console.Clear();

            Queue<KomodoClaim> listOfClaims = _claimRepo.GetClaimsList();

            string tableHeaders = String.Format("{0,-20} {1,-20} {2,-80} {3,-20} {4,-20} {5,-20} {6,-20}\n\n", "ID:", "Type:", "Description:", "Amount ($):", "Date of Incident:", "Date of Claim:", "Claim is Valid:");
            Console.WriteLine(tableHeaders);

            foreach (KomodoClaim claim in listOfClaims)
            {
                string tableBody = String.Format("{0,-20} {1,-20} {2,-80} {3,-20} {4,-20} {5,-20} {6,-20}\n\n", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount.ToString("C"), claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid);
                Console.WriteLine(tableBody);
                Console.WriteLine();
            }
        }
        private void TakeCareOfClaim()
        {
            Console.Clear();
            KomodoClaim claim = _claimRepo.ViewNextClaim();

            string tableHeaders = String.Format("{0,-20} {1,-20} {2,-80} {3,-20} {4,-20} {5,-20} {6,-20}\n\n", "ID:", "Type:", "Description:", "Amount ($):", "Date of Incident:", "Date of Claim:", "Claim is Valid:");
            Console.WriteLine(tableHeaders);

            string tableBody = String.Format("{0,-20} {1,-20} {2,-80} {3,-20} {4,-20} {5,-20} {6,-20}\n\n", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount.ToString("C"), claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid);
            Console.WriteLine(tableBody);
            Console.WriteLine("\n\nDo you want to take care of this claim? Type y for yes and n for no");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "y":
                    _claimRepo.TakeCareOfNextClaim();
                    Console.WriteLine("This claim will be removed from the queue.");
                    break;
                case "n":
                    Console.WriteLine("This claim will not be removed from the queue. However, you will always have to complete the queue in the order it was added. You cannot skip items in the queue.");
                    break;
                default:
                    Console.WriteLine("I did not understand your response.");
                    break;
            }

        }
        private void AddNewClaim()
        {
            Console.Clear();
            KomodoClaim newClaim = new KomodoClaim();
            Console.WriteLine("Enter the number associated with the claim type from the following:\n" +
                "1.Car\n" +
                "2.Home\n" +
                "3.Theft.");
            int claimType = int.Parse(Console.ReadLine());
            newClaim.ClaimType = (ClaimTypeEnum)claimType;

            Console.WriteLine("Enter a description of the claim.");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount requested for the claim using numbers and decimals only to represent the value.");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident using the following format: MM / DD / YYYY");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the claim using the following format: MM / DD / YYYY");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimRepo.AddClaim(newClaim);
        }

        private void SeedClaimsList()
        {
            var car1 = new KomodoClaim(ClaimTypeEnum.Car, "Bear jumped onto my car.", 2600, new DateTime(2020, 12, 1), new DateTime(2020, 12, 2));
            var home1 = new KomodoClaim(ClaimTypeEnum.Home, "Bear jumped off my car and onto my home.", 5000, new DateTime(2020, 12, 1), new DateTime(2020, 12, 3));
            var theft1 = new KomodoClaim(ClaimTypeEnum.Theft, "I later realized bear stole my prized posessions when on my home.", 15000, new DateTime(2020, 12, 1), new DateTime(2021, 1, 4));
            _claimRepo.AddClaim(car1);
            _claimRepo.AddClaim(home1);
            _claimRepo.AddClaim(theft1);
        }
    }
}
