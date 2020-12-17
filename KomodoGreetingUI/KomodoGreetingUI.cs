using RepoKomodoGreeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetingUI
{
    class KomodoGreetingUI
    {
        private KomodoGreetingRepo _customerRepo = new KomodoGreetingRepo();

        public void Run()
        {
            SeedCustomerList();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please open window in full screen for best visibility.\n\nEnter the number associated with the menu number below:\n" +
                    "1. Add new customer\n" +
                    "2. View all customers\n" +
                    "3. Update existing customer\n" +
                    "4. Delete a customer\n" +
                    "5. Exit application\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CustomerAdd();
                        break;
                    case "2":
                        CustomersView();
                        break;
                    case "3":
                        CustomerUpdate();
                        break;
                    case "4":
                        CustomerDelete();
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

        private void CustomerAdd()
        {
            Console.Clear();
            KomodoGreeting newCustomer = new KomodoGreeting();

            Console.WriteLine("Enter the First Name of the customer.");
            newCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Last Name of the customer.");
            newCustomer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the number associated with the type of customer below:\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            newCustomer.CustomerType = (CustomerTypeEnum)int.Parse(Console.ReadLine());

            _customerRepo.AddCustomerToList(newCustomer);
        }

        private void CustomersView()
        {
            Console.Clear();
            List<KomodoGreeting> listOfCustomers = _customerRepo.GetCustomerList();

            string tableHeader = String.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-60}\n\n", "ID:", "First Name:", "Last Name:", "Type:", "Email:");
            Console.WriteLine(tableHeader);

            foreach (KomodoGreeting customer in listOfCustomers)
            {
                string tableBody = String.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-60}\n\n", customer.CustomerId, customer.FirstName, customer.LastName, customer.CustomerType, customer.Email);
                Console.WriteLine(tableBody);
            }
        }

        private void CustomerUpdate()
        {
            Console.Clear();
            CustomersView();

            Console.WriteLine("Enter the ID of the customer you'd like to update,");
            string originalId = Console.ReadLine();

            KomodoGreeting updatedCustomer = new KomodoGreeting();
            Console.WriteLine("Enter the First Name of the customer.");
            updatedCustomer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Last Name of the customer.");
            updatedCustomer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the number associated with the type of customer below:\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            updatedCustomer.CustomerType = (CustomerTypeEnum)int.Parse(Console.ReadLine());

            bool wasUpdated = _customerRepo.UpdateCustomer(originalId, updatedCustomer);

            if(wasUpdated)
            {
                Console.WriteLine("Customer was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not be updated. Try again.");
            }

        }

        private void CustomerDelete()
        {
            Console.Clear();
            CustomersView();

            Console.WriteLine("\nEnter the ID of the customer you'd like to remove.");
            bool wasDeleted = _customerRepo.DeleteCustomer(Console.ReadLine());

            if(wasDeleted)
            {
                Console.WriteLine("Customer was successfuly deleted");
            }
            else
            {
                Console.WriteLine("Could not be deleted. Try again.");
            }
        }

        private void SeedCustomerList()
        {
            var A = new KomodoGreeting("Haley", "Jackson", CustomerTypeEnum.Current);
            var B = new KomodoGreeting("Jack", "Henson", CustomerTypeEnum.Past);
            var C = new KomodoGreeting("Jordan", "Brooks", CustomerTypeEnum.Potential);

            _customerRepo.AddCustomerToList(A);
            _customerRepo.AddCustomerToList(B);
            _customerRepo.AddCustomerToList(C);
        }
    }
}
