using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoOutings
{
    public enum EventTypeEnum
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert,
    }
    public class KomodoOuting
    {
        public int EventId { get; set; }
        public EventTypeEnum EventType { get; set; }
        public decimal NumberOfAttendees { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalEventCost
        {
            get
            {
                decimal calculation = CostPerPerson * NumberOfAttendees;
                return calculation;
            }
        }

        public KomodoOuting()
        {

        }

        public KomodoOuting(EventTypeEnum eventType, decimal numberOfAttendees, DateTime dateOfEvent, decimal costPerPerson)
        {
            EventType = eventType;
            NumberOfAttendees = numberOfAttendees;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
        }
    }
    //public class KomodoOutingList
    //{
    //public string ListName { get; set; }
    //public List<KomodoOuting> ListOfOutings { get; set; } = new List<KomodoOuting>();

    //public KomodoOutingList()
    //{

    //}

    //public KomodoOutingList(string listName, List<KomodoOuting> listOfOutings)
    //{
    //ListName = listName;
    //ListOfOutings = listOfOutings;
    //}

    //public void AddOutingToList(List<KomodoOuting> outingsToAdd)
    //{
    //ListOfOutings.AddRange(outingsToAdd);
    //}
    //}
}
