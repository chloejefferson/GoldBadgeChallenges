using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoKomodoGreen
{
    public class KomodoGreenRepo
    {
        private readonly List<KomodoGreen> _carRepo = new List<KomodoGreen>();
        private int _modelIdCounter = 0;

        public void AddCar(KomodoGreen car)
        {
            car.ModelId = _modelIdCounter + 1;
            _carRepo.Add(car);
            _modelIdCounter++;
        }

        public List<KomodoGreen> GetAllCars()
        {
            return _carRepo;
        }

        public KomodoGreen GetCarByModelId(int id)
        {
            foreach (KomodoGreen car in _carRepo)
            {
                if (car.ModelId == id)
                {
                    return car;
                }
            }
            return null;
        }

        public bool UpdateCar(int id, KomodoGreen updatedCar)
        {
            KomodoGreen existingCar = GetCarByModelId(id);

            if (existingCar != null)
            {
                existingCar.CarType = updatedCar.CarType;
                existingCar.Name = updatedCar.Name;
                existingCar.Details = updatedCar.Details;
                return true;
            }
            return false;
        }

        public bool DeleteCar(int id)
        {
            KomodoGreen car = GetCarByModelId(id);
            if(_carRepo.Remove(car))
            {
                return true;
            }
            return false;
        }
    }
}
