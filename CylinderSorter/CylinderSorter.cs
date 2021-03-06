﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CylinderSorter.Domain;

namespace CylinderSorter
{
    /*
        Cylinder sorter class
    */
    public class CylinderSorter
    {
        /*
         Takes list of cylinders and sorts it by volume.
         Duplicates are moved to new list and any additional
         duplicates from that list are moved to new list and so on
         until all cylinders are sorted in optimal way.
         For the sake of test, return type is string.
        */
        public static string CylinderListSorter(List<Cylinder> cylinderList)
        {
            List<List<Cylinder>> nestedCylinderList = new List<List<Cylinder>>();
            
            cylinderList = cylinderList.OrderBy(a=>a.Volume).Reverse().ToList();
            
            // Creates a list that has no duplicates.
            var noneDuplicateList = GetNoneDuplicateList(cylinderList);
            nestedCylinderList.Add(noneDuplicateList);
            
            // List with left over duplicates.
            List<Cylinder> result = cylinderList.Except(noneDuplicateList).OrderBy(a=>a.Volume).Reverse().ToList();

            while (result.Count > 0)
            {
                var nonDuplicateList = GetNoneDuplicateList(result);
                
                nestedCylinderList.Add(nonDuplicateList);

                result = result.Except(nonDuplicateList).OrderBy(a=>a.Volume).Reverse().ToList();
            }
            
            StringBuilder sb = new StringBuilder();
            foreach (var list in nestedCylinderList)
            {
                foreach (var item in list)
                {
                    sb.AppendFormat("Cylinder ID: " + item.ID + ", Cylinder Volume: " + item.Volume + "{0}", Environment.NewLine);
                }
                sb.AppendFormat("-----------------------------------------{0}", Environment.NewLine);
            }
            
            return sb.ToString();
        }

        // Returns list without duplicates
        private static List<Cylinder> GetNoneDuplicateList(List<Cylinder> cylinderList)
        {
            return cylinderList.GroupBy(x => x.Volume).Select(y => y.FirstOrDefault()).ToList();
        }
    }
}