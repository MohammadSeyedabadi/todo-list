using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warnsdorffsAlgorithmKnightsTourProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            // While we don't get a solution
            while (!new GFG().findClosedTour())
            {
                ;
            }

            Console.ReadKey();
        }
    }
}
