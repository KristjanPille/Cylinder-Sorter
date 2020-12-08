using System;
using System.Collections.Generic;
using CylinderSorter.Domain;

namespace CylinderSorter
{
    public static class CylinderListCreator
    {
        public static List<Cylinder> CreateListOfCylinders(int numberOfCylinders)
        {
            var cylinderList = new List<Cylinder>();
                
            for (int i = 0; i < numberOfCylinders; i++)
            {
                cylinderList.Add(CreateCylinder(i));
            }

            return cylinderList;
        }

        private static Cylinder CreateCylinder(int cylinderId)
        {
            // Creates new Cylinder object with random values.
            // For testing purposes range will be from 1 to 100.
            Cylinder cylinder = new Cylinder();
            cylinder.ID = cylinderId;
            
            // Potential memory issue with generating randoms.
            cylinder.Diameter = new Random().Next(1, 100);
            cylinder.Height = new Random().Next(1, 100);
            
            cylinder.Volume = Math.PI * (cylinder.Diameter / 2) * (cylinder.Diameter / 2) * cylinder.Height;

            return cylinder;
        }
    }
}