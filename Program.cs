using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace maze
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] maze =  {{1,1,0,1 },
                            {0,1,1,1 },
                            {0,1,0,1 },
                            {0,1,1,1 } };

            int[,] visited1 =   {{0,0,0,0 },
                                {0,0,0,0 },
                                {0,0,0,0 },
                                {0,0,0,0 }};
            visited1[0, 0] = 1;
            RatInAMaze ratInAMaze = new RatInAMaze();
            ratInAMaze.FindPathInMaze(maze, visited1, 0, 0, 3, 3, 1);

            Console.ReadKey();
        }
    }
}
