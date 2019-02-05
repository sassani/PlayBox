using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinders
{
    class ShortestDeliveriList
    {
        /// <summary>
        /// Return a list of delivery points (list<int,int>)
        /// </summary>
        /// <param name="numDestinations"></param>
        /// <param name="allLocations"></param>
        /// <param name="numDeliveries"></param>
        /// <returns>List<List<int>></returns>
        public List<List<int>> ClosestXdestinations(int numDestinations,
                                                    int[,] allLocations,
                                                    int numDeliveries)
        {
            SortedSet<Node> list = new SortedSet<Node>();
            for (int i = 0; i < numDestinations; i++)
            {
                list.Add(new Node(allLocations[i, 0], allLocations[i, 1]));
            }
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < numDeliveries; i++)
            {
                Node closest = list.Min();
                result.Add(new List<int> { closest.X, closest.Y });
                list.Remove(closest);
            }
            return result;
        }

        public string ToString(List<List<int>> data)
        {
            string result = "";
            foreach (var item in data)
            {
                result += $"[{item[0]}, {item[1]}]\n";
            }
            return result;
        }
    }

    class Node : IComparable<Node>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Dist { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
            Dist = (x * x) + (y * y);
        }

        public int CompareTo(Node obj)
        {
            if (Dist.CompareTo(obj.Dist) != 0)
            {
                return Dist.CompareTo(obj.Dist);
            }
            return X.CompareTo(obj.X);
        }
    }
}
