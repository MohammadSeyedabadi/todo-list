using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace theknights_tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] visited =   {{0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 }};
            visited[0, 0] = 1;
            KnightTour knightTour = new KnightTour();
            knightTour.FindKnightTour(visited, 0, 0, 1);

            Console.ReadKey();
        }
    }
}