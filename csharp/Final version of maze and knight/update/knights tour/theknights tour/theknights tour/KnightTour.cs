using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace theknights_tour
{
    class KnightTour
    {
        int[] pathRow1 = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] pathCol1 = { 1, 2, 2, 1, -1, -2, -2, -1 };
        bool canRunInitialMove = true;

        public bool FindKnightTour(int[,] visited, int row, int col, int move)
        {
            if (move == 64)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(visited[i, j].ToString("00") + "  ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                return true;
            }
            else
            {
                for (int index = 0; index < pathRow1.Length; index++)
                {
                    int rowNew = row + pathRow1[index];
                    int colNew = col + pathCol1[index];
                    if (IfValidMove(visited, rowNew, colNew))
                    {
                        move++;
                        visited[rowNew, colNew] = move;
                        drawBoard(rowNew, colNew, visited, move);
                        if (FindKnightTour(visited, rowNew, colNew, move))
                        {
                            return true;
                        }
                        move--;
                        visited[rowNew, colNew] = 0;
                        drawBoard(row, col, visited, move);
                    }
                }
            }
            return false;
        }

        private bool IfValidMove(int[,] visited, int rowNew, int colNew)
        {
            if ((rowNew >= 0) && (rowNew < 8) && (colNew >= 0) && (colNew < 8) && (visited[rowNew, colNew] == 0))
            {
                return true;
            }
            return false;
        }

        private void drawBoard(int rowNew, int colNew, int[,] visited, int move)
        {
            /*  Console.Clear();  */

          /*  int[,] board = {{0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 },
                                {0,0,0,0,0,0,0,0 }};*/

            if (canRunInitialMove)
            {
                initialMove();
                canRunInitialMove = false;
            }

            visited[rowNew, colNew] = move;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (visited[i, j] == move)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("**" + "  ");
                    }
                    else if (visited[i, j] != 00) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(visited[i, j].ToString("00") + "  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(visited[i, j].ToString("00") + "  ");
                    }
                    
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Thread.Sleep(1000);
            Console.Clear();
        }

        private void initialMove()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  00  00  00  00  00  00  00\n\n00  00  00  00  00  00  00  00\n\n00  00  00  00  00  00  00  00\n\n00  00  00  00  00  00  00  00\n\n00  00  00  00  00  00  00  00\n\n00  00  00  00  00  00  00  00\n\n00  00  00  00  00  00  00  00\n\n00  00  00  00  00  00  00  00");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}