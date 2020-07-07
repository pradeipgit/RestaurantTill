using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestaurantTill
{
    public class Checkout
    {
        public double totalBill(Menu menu)
        {
            if(menu == null)
            {
                throw new NullReferenceException("menu should not be null");
            }
            return Math.Round(((menu.starter.Count * (double) Menu.starterCost) + (menu.mainCourse.Count * (double) Menu.mainsCost)),2);
        }
    }
}
