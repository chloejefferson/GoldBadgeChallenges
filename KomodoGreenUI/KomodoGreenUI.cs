using RepoKomodoGreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenUI
{
    class KomodoGreenUI
    {
        private KomodoGreenRepo _carRepo = new KomodoGreenRepo();
        private KomodoGreenListRepo _carListRepo = new KomodoGreenListRepo();

        public void Run()
        {
            SeedData();
            UIMenu();
        }

        public void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please open window in full screen for best visibility.\n\nEnter the number associated with the menu number below:\n\n" +
                    "Cars Menu:\n" +
                    "1. View all cars\n" +
                    "2. Add new car\n" +
                    "3. Update a car\n" +
                    "4. Delete a car\n\n" +
                    "Car List Menu:\n" +
                    "5. View all car lists\n" +
                    "6. Add a car list\n" +
                    "7. Update a car list\n" +
                    "8. Delete a car list\n\n" +
                    "9. Exit application\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CarsView();
                        break;
                    case "2":
                        CarAdd();
                        break;
                    case "3":
                        CarUpdate();
                        break;
                    case "4":
                        CarDelete();
                        break;
                    case "5":
                        CarsListView();
                        break;
                    case "6":
                        CarListAdd();
                        break;
                    case "7":
                        CarListUpdate();
                        break;
                    case "8":
                        CarListDelete();
                        break;
                    case "9":
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

        public void CarsView()
        {
            Console.Clear();
            List<KomodoGreen> allCars = _carRepo.GetAllCars();
            CarTableHeader();
            foreach (KomodoGreen car in allCars)
            {
                string tableBody = String.Format("{0,-20} {1,-20} {2,-20} {3,-60}\n\n", car.ModelId, car.CarType, car.Name, car.Details);
                Console.WriteLine(tableBody);
            }
        }

        public void CarAdd()
        {
            Console.Clear();
            KomodoGreen newCar = new KomodoGreen();

            Console.WriteLine("Enter the number assocated with the car type to be added\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas");
            newCar.CarType = (CarTypeEnum)int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name of the new car.");
            newCar.Name = Console.ReadLine();

            Console.WriteLine("Enter any details for the new car.");
            newCar.Details = Console.ReadLine();

            _carRepo.AddCar(newCar);
        }

        public void CarUpdate()
        {
            Console.Clear();
            CarsView();
            Console.WriteLine("Enter the Model ID of the car you'd like to update.");
            int originalId = int.Parse(Console.ReadLine());

            KomodoGreen updatedCar = new KomodoGreen();
            Console.WriteLine("Enter the number assocated with the updated car type.\n" +
                            "1. Electric\n" +
                            "2. Hybrid\n" +
                            "3. Gas");
            updatedCar.CarType = (CarTypeEnum)int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the updated name of the car.");
            updatedCar.Name = Console.ReadLine();

            Console.WriteLine("Enter the updated details for the car.");
            updatedCar.Details = Console.ReadLine();

            bool wasUpdated = _carRepo.UpdateCar(originalId, updatedCar);

            if (wasUpdated)
            {
                Console.WriteLine("Car was successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not be updated. Try again.");
            }
        }

        public void CarDelete()
        {
            Console.Clear();
            CarsView();

            Console.WriteLine("\nEnter the ID of the car you'd like to remove.");
            bool wasDeleted = _carRepo.DeleteCar(int.Parse(Console.ReadLine()));

            if (wasDeleted)
            {
                Console.WriteLine("Car was successfuly deleted");
            }
            else
            {
                Console.WriteLine("Could not be deleted. Try again.");
            }
        }

        public void CarsListView()
        {
            Console.Clear();
            List<KomodoGreenList> allCarLists = _carListRepo.GetAllCarLists();
            //string tableHeader = String.Format("{0,-20} {1,-20} {2,-20} {3,-20}, {4,-20}, {5,-20}\n\n", "Car List ID:", "Car List Name:", "Car Model ID:", "Car Type:", "Car Name:", "Car Details:");
            foreach (KomodoGreenList carList in allCarLists)
            {
                DisplayCarList(carList);
            }
        }

        public void CarListAdd()
        {
            Console.Clear();
            KomodoGreenList newCarList = new KomodoGreenList();

            Console.WriteLine("Enter the number assocated with the car list type you'd like to add.\n" +
                            "1. Electric\n" +
                            "2. Hybrid\n" +
                            "3. Gas");
            newCarList.CarListType = (CarListTypeEnum)int.Parse(Console.ReadLine());

            _carListRepo.CreateCarList(newCarList);

            Console.WriteLine("Your car list has been created. To add cars to this list, select the update car list option on the main menu.");
        }

        public void CarListUpdate()
        {
            Console.Clear();
            CarsListView();

            Console.WriteLine("Enter the ID of the car list you'd like to update");
            int existingCarListId = int.Parse(Console.ReadLine());
            KomodoGreenList listToUpdate = _carListRepo.GetCarListById(existingCarListId);

            Console.WriteLine($"What would you like to update in List ID {listToUpdate.CarListId}? Enter the corresponding number:\n" +
                $"1. Add car(s) to list\n" +
                $"2. Remove car from list.\n" +
                $"3. Update car list type\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CarsView();
                    Console.WriteLine($"Please enter the model IDs of the cars you'd like to add to List ID {listToUpdate.CarListId} separated ONLY by commas.");
                    List<string> listOfCarIdsAsString = Console.ReadLine().Split(',').ToList();

                    var listOfCarsToAdd = new List<KomodoGreen>();

                    foreach (string idAsString in listOfCarIdsAsString)
                    {
                        int id = int.Parse(idAsString);

                        KomodoGreen carToAdd = _carRepo.GetCarByModelId(id);
                        listOfCarsToAdd.Add(carToAdd);
                    }

                    listToUpdate.AddCarToList(listOfCarsToAdd);

                    Console.WriteLine("To view any changes to car lists, view all car lists in the main menu.");

                    break;
                case "2":
                    Console.WriteLine($"Please enter the model ID of the car you'd like to delete from List ID {listToUpdate.CarListId}.");
                    listToUpdate.RemoveCarFromList(_carRepo.GetCarByModelId(int.Parse(Console.ReadLine())));

                    Console.WriteLine("To view any changes to car lists, view all car lists in the main menu.");
                    break;
                case "3":
                    KomodoGreenList updatedCarList = new KomodoGreenList();

                    Console.WriteLine("Enter the number assocated with the updated car list.\n" +
                                    "1. Electric\n" +
                                    "2. Hybrid\n" +
                                    "3. Gas");

                    updatedCarList.CarListType = (CarListTypeEnum)int.Parse(Console.ReadLine());

                    _carListRepo.UpdateCarList(listToUpdate.CarListId,updatedCarList.CarListType);

                    Console.WriteLine("To view any changes to car lists, view all car lists in the main menu.");
                    break;
                default:
                    Console.WriteLine("You must enter a valid entry. You will be returned to the main menu.");
                        break;
            }
            
        }

        public void CarListDelete()
        {
            CarsListView();
            Console.WriteLine("Enter the ID of the car list you'd like to delete.");
            bool wasDeleted = _carListRepo.DeleteCarList(int.Parse(Console.ReadLine()));
            if (wasDeleted)
            {
                Console.WriteLine("The car list was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The car list could not be deleted. Try again.");
            }
        }

        public void DisplayCarList(KomodoGreenList carList)
        {
            Console.WriteLine($"List ID: {carList.CarListId}");
            Console.WriteLine($"List Type: {carList.CarListType}");
            Console.WriteLine("Cars in This List:");
            CarTableHeader();
            foreach (KomodoGreen car in carList.CarList)
            {
                string tableBody = String.Format("{0,-20} {1,-20} {2,-20} {3,-60}\n\n", car.ModelId, car.CarType, car.Name, car.Details);
                Console.WriteLine(tableBody);
            }

        }

        public void CarTableHeader()
        {
            string tableHeader = String.Format("{0,-20} {1,-20} {2,-20} {3,-60}\n\n", "Model ID:", "Type:", "Name:", "Details:");
            Console.WriteLine(tableHeader);
        }

        public void SeedData()
        {
            var A = new KomodoGreen(CarTypeEnum.electric, "Tesla", "The it car.");
            var B = new KomodoGreen(CarTypeEnum.hybrid, "Hyundai", "A reasonable car.");
            var C = new KomodoGreen(CarTypeEnum.gas, "Ford", "A normal truck.");
            var D = new KomodoGreen(CarTypeEnum.electric, "BMW", "Looks like it's from the future.");

            _carRepo.AddCar(A);
            _carRepo.AddCar(B);
            _carRepo.AddCar(C);
            _carRepo.AddCar(D);

            List<KomodoGreen> electricList = new List<KomodoGreen>();
            electricList.Add(A);
            electricList.Add(D);

            var A1 = new KomodoGreenList(CarListTypeEnum.Electric, electricList);
            var B1 = new KomodoGreenList(CarListTypeEnum.Gas);

            _carListRepo.CreateCarList(A1);
            _carListRepo.CreateCarList(B1);
        }
    }
}
