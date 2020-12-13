using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo_menu_Repository
{
    public enum IDontKnow
    {
        //put switch in here
        
    }

    // poco
    public class MenuContent
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        

        public MenuContent () { }

        public MenuContent(int mealnumber, string mealName, string description, double price)
        {
            MealNumber = mealnumber;
            MealName = mealName;
            Description = description;
            Price = price;
            


        }
    }
}
