using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoGreeting
{
    public enum CustomerTypeEnum
    {
        Current = 1,
        Past,
        Potential,
    }
    public class KomodoGreeting
    {
        public string CustomerId
        {
            get
            {
                string id = FirstName + LastName;
                return id;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
        public string Email
        {
            get
            {
                if (CustomerType == CustomerTypeEnum.Current)
                {
                    string emailCurrent = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    return emailCurrent;
                }
                if (CustomerType == CustomerTypeEnum.Past)
                {
                    string emailPast = "It's been a long time since we've heard from you, we want you back.";
                    return emailPast;
                }
                if (CustomerType == CustomerTypeEnum.Potential)
                {
                    string emailPotential = "We currently have the lowest rates on Helicopter Insurance!";
                    return emailPotential;
                }
                return null;
            }
        }
        public KomodoGreeting()
        {

        }

        public KomodoGreeting(string firstName, string lastName, CustomerTypeEnum customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
        }
    }
}
