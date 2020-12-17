using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoGreen
{
    public enum CarListTypeEnum
    {
        Electric = 1,
        Hybrid,
        Gas,
    }
    public class KomodoGreenList
    {
        public int CarListId { get; set; }
        public CarListTypeEnum CarListType { get; set; }
        public List<KomodoGreen> CarList { get; set; } = new List<KomodoGreen>();
        public KomodoGreenList()
        {

        }
        public KomodoGreenList(CarListTypeEnum carListType, List<KomodoGreen> carList)
        {
            CarListType = carListType;
            CarList = carList;
        }

        public KomodoGreenList(CarListTypeEnum carListType)
        {
            CarListType = carListType;
        }

        public void AddCarToList(List<KomodoGreen> listOfCarsToAdd)
        {
            CarList.AddRange(listOfCarsToAdd);
        }

        public void RemoveCarFromList(KomodoGreen carToRemove)
        {
            CarList.Remove(carToRemove);
        }
    }
}
