using System;
using System.Collections.Generic;
using CylinderSorter.Domain;

namespace CylinderSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            int cylindersToCreate = 500;
            
            // Creates Cylinders with random height & diameter.
            List<Cylinder> cylinders = CylinderListCreator.CreateListOfCylinders(cylindersToCreate);
            
            // Returns sorted cylinders.
            String sortedCylindersList = CylinderSorter.CylinderListSorter(cylinders);
            
            Console.WriteLine(sortedCylindersList);
        }
    }
}