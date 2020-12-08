using System;
using System.Collections.Generic;
using CylinderSorter.Domain;

namespace CylinderSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int cylindersToCreate = 50;
            
            // Creates Cylinders with random height & diameter.
            List<Cylinder> cylinders = CylinderListCreator.CreateListOfCylinders(cylindersToCreate);
            
            // Returns sorted cylinders.
            List<List<Cylinder>> nestedCylinderList = CylinderSorter.CylinderListSorter(cylinders);

            
            // Shows each list of cylinders separately.
            foreach (var list in nestedCylinderList)
            {
                foreach (var item in list)
                {
                    Console.WriteLine("Cylinder ID: " + item.ID + ", Diameter: " + item.Diameter + ", Height: " + item.Height + ", Volume: " + item.Volume);
                }
                Console.WriteLine("----------------------------------------------");
            }
        }
    }
}