using System;

namespace PathFinders
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Console.WriteLine("Shortest Delivery List");
            ShortestDeliveriList sdl = new ShortestDeliveriList();
            Console.WriteLine(sdl.ToString(sdl.ClosestXdestinations(3, new int[,] { { 1, -3 }, { 1, 2 }, { 3, 4 } }, 2)));

            Console.WriteLine("Click to go next ...");
            Console.ReadLine();

        }
    }
}
