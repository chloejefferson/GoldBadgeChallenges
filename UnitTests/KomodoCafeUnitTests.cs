using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repos;

namespace UnitTests
{
    [TestClass]
    public class KomodoCafeUnitTests
    {
        private KomodoCafeMenuRepository _repo;
        private KomodoCafeMenu _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoCafeMenuRepository();
            _menuItem = new KomodoCafeMenu(1, "burger", "a big burger", "burger ingredients", 7.03m);
            _repo.AddMenuItemToList(_menuItem);

        }
        [TestMethod]
        public void AddMenuItemToList_ShouldNotBeNull()
        {
            KomodoCafeMenuRepository repo = new KomodoCafeMenuRepository();
            KomodoCafeMenu menuItem = new KomodoCafeMenu(2, "salad", "a big salad", "salad ingredients", 8.35m);
            repo.AddMenuItemToList(menuItem);
            KomodoCafeMenu menuItemFromList = repo.GetMenuItemByMealNumber(2);
            Assert.IsNotNull(menuItemFromList);
        }
        [TestMethod]
        public void GetMenuItemsList_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetMenuItemsList());

        }
        [TestMethod]
        public void RemoveMenuItemFromList_BoolShouldBeTrue()
        {
            Assert.IsTrue(_repo.RemoveMenuItemFromList(_menuItem.MealNumber));

        }
        [TestMethod]
        public void GetMenuItemByMealNumber_ShouldNotBeNull()
        {
            Assert.IsNotNull(_repo.GetMenuItemByMealNumber(_menuItem.MealNumber));
        }
    }
}
