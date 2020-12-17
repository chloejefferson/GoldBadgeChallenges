using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoKomodoGreen;

namespace UnitTestsKomodoGreen
{
    [TestClass]
    public class KomodoGreenUnitTests
    {
        private KomodoGreenRepo _carRepo = new KomodoGreenRepo();
        private KomodoGreen _car1 = new KomodoGreen();
        private KomodoGreen _car2 = new KomodoGreen();
        private KomodoGreen _car3 = new KomodoGreen();
        private KomodoGreenListRepo _listRepo = new KomodoGreenListRepo();
        private KomodoGreenList _list1 = new KomodoGreenList();
        private KomodoGreenList _list2 = new KomodoGreenList();
        private List<KomodoGreen> _sampleListToAdd = new List<KomodoGreen>();


        [TestInitialize]
        public void Arrange()
        {
            _carRepo = new KomodoGreenRepo();
            _car1 = new KomodoGreen(CarTypeEnum.electric, "Tesla", "It's a Tesla.");
            _car2 = new KomodoGreen(CarTypeEnum.electric, "Zoom", "It's a Zoom.");
            _car3 = new KomodoGreen(CarTypeEnum.gas, "Ford", "It's a regular Ford.");

            _carRepo.AddCar(_car1);
            _carRepo.AddCar(_car2);

            _sampleListToAdd.Add(_car3);

            _listRepo = new KomodoGreenListRepo();
            _list1 = new KomodoGreenList(CarListTypeEnum.Electric);
            _list2 = new KomodoGreenList(CarListTypeEnum.Gas);

            _listRepo.CreateCarList(_list1);
        }
        [TestMethod]
        public void KomodoGreenRepo_AddCar_ShouldNotBeNull()
        {
            Assert.IsNotNull(_carRepo.GetCarByModelId(_car1.ModelId));
        }

        [TestMethod]
        public void KomodoGreenRepo_GetAllCars_ShouldNotBeNull()
        {
            Assert.IsNotNull(_carRepo.GetAllCars());
        }

        [TestMethod]
        public void KomodoGreenRepo_GetCarByModelId_ShouldNotBeNull()
        {
            Assert.IsNotNull(_carRepo.GetCarByModelId(_car2.ModelId));
        }

        [TestMethod]
        public void KomodoGreenRepo_UpdateCar_ShouldBeTrue()
        {
            Assert.IsTrue(_carRepo.UpdateCar(_car1.ModelId, _car3));
        }

        [TestMethod]
        public void KomodoGreenRepo_DeleteCar_ShouldBeTrue()
        {
            Assert.IsTrue(_carRepo.DeleteCar(_car2.ModelId));
        }

        [TestMethod]
        public void KomodoGreenListRepo_CreateCarList_ShouldNotBeNull()
        {
            Assert.IsNotNull(_listRepo.GetCarListById(_list1.CarListId));
        }

        [TestMethod]
        public void KomodoGreenListRepo_GetAllCarLists_ShouldNotBeNull()
        {
            Assert.IsNotNull(_listRepo.GetAllCarLists());
        }

        [TestMethod]
        public void KomodoGreenListRepo_GetCarListById_ShouldNotBeNull()
        {
            Assert.IsNotNull(_listRepo.GetCarListById(_list1.CarListId));
        }

        [TestMethod]
        public void KomodoGreenListRepo_UpdateCarList_ShouldBeTrue()
        {
            Assert.IsTrue(_listRepo.UpdateCarList(_list1.CarListId, _list2.CarListType));
        }

        [TestMethod]
        public void KomodoGreenListRepo_DeleteCarList_ShouldBeTrue()
        {
            Assert.IsTrue(_listRepo.DeleteCarList(_list1.CarListId));

        }
    }
}
