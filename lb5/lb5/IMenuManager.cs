using System.Collections.Generic;

namespace RestaurantSystem
{
    public interface IMenuManager
    {
        void ShowMenu();
        MenuItem FindItemByName(string name);
        List<MenuItem> FindItemsByCategory(string category);
    }
}