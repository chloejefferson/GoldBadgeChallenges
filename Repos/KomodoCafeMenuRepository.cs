using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class KomodoCafeMenuRepository
    {
        private readonly List<KomodoCafeMenu> _menuItemsList = new List<KomodoCafeMenu>();

        public void AddMenuItemToList (KomodoCafeMenu menuItem)
        {
            _menuItemsList.Add(menuItem);
        }
        public List<KomodoCafeMenu> GetMenuItemsList()
        {
            return _menuItemsList;
        }
        public bool RemoveMenuItemFromList(int mealNumber)
        {
            KomodoCafeMenu menuItem = GetMenuItemByMealNumber(mealNumber);

            if(menuItem == null)
            {
                return false;
            }
            int initialCount = _menuItemsList.Count;
            _menuItemsList.Remove(menuItem);

            if(initialCount == (_menuItemsList.Count + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public KomodoCafeMenu GetMenuItemByMealNumber(int mealNumber)
        {
            foreach(KomodoCafeMenu menuItem in _menuItemsList)
            {
                if(menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}
