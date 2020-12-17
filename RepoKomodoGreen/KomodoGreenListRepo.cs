using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoGreen
{
    public class KomodoGreenListRepo
    {
        private readonly List<KomodoGreenList> _carListRepo = new List<KomodoGreenList>();
        private int _carListIdCounter = 0;

        public void CreateCarList(KomodoGreenList carList)
        {
            carList.CarListId = _carListIdCounter + 1;
            _carListRepo.Add(carList);
            _carListIdCounter++;
        }


        public List<KomodoGreenList> GetAllCarLists()
        {
            return _carListRepo;
        }

        public KomodoGreenList GetCarListById(int carListId)
        {
            foreach (KomodoGreenList carList in _carListRepo)
            {
                if (carList.CarListId == carListId)
                {
                    return carList;
                }
            }
            return null;
        }

        public bool UpdateCarList(int carListId, CarListTypeEnum updatedCarListType)
        {
            KomodoGreenList existingCarList = GetCarListById(carListId);
            if (existingCarList != null)
            {
                existingCarList.CarListType = updatedCarListType;
                return true;
            }
            return false;
        }

        public bool DeleteCarList(int carListId)
        {
            KomodoGreenList carListToRemove = GetCarListById(carListId);
            if (_carListRepo.Remove(carListToRemove))
            {
                return true;
            }
            return false;
        }
    }
}
