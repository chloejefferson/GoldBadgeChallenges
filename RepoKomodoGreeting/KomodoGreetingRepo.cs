using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoGreeting
{
    public class KomodoGreetingRepo
    {
        private readonly List<KomodoGreeting> _customersToGreetRepo = new List<KomodoGreeting>();

        public void AddCustomerToList(KomodoGreeting customer)
        {
            _customersToGreetRepo.Add(customer);
        }

        public List<KomodoGreeting> GetCustomerList()
        {
            return _customersToGreetRepo;
        }

        public KomodoGreeting GetCustomerById(string id)
        {
            foreach (KomodoGreeting customer in _customersToGreetRepo)
            {
                if(customer.CustomerId == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public bool UpdateCustomer(string originaliD, KomodoGreeting updatedCustomer)
        {
            KomodoGreeting originalCustomer = GetCustomerById(originaliD);

            if (originalCustomer != null)
            {
                originalCustomer.FirstName = updatedCustomer.FirstName;
                originalCustomer.LastName = updatedCustomer.LastName;
                originalCustomer.CustomerType = updatedCustomer.CustomerType;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCustomer(string id)
        {
            KomodoGreeting customer = GetCustomerById(id);

            if(customer == null)
            { 
                return false;
            }

            int initialCount = _customersToGreetRepo.Count;
            _customersToGreetRepo.Remove(customer);

            if(initialCount == _customersToGreetRepo.Count + 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
