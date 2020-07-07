using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace RestaurantTill
{
    public class Menu
    {
        public List<string> starter { get; set; }
        public List<string> mainCourse { get; set; }

        public static readonly float starterCost = 4.40f;
        public static readonly float mainsCost = 7.00f;

        public Menu()
        {
            starter = new List<string>();
            mainCourse = new List<string>();
        }
        public void addStarter(string starterItem)
        {
            starter.Add(starterItem);
        }

        public void addMain(string mainItem)
        {
            mainCourse.Add(mainItem);
        }

        public void deleteStarter(string starterItem)
        {
            starter.Remove(starterItem);
        }
        public void deleteMain(string mainItem)
        {
            mainCourse.Remove(mainItem);
        }

        public void clearMenu()
        {
            starter.Clear();
            mainCourse.Clear();
        }
    }
}
