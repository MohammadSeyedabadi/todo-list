using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace maze
{
    class RatInAMaze
    {
        int[] Path_Row = { 0, 0, 1, -1 };
        int[] Path_Col = { 1, -1, 0, 0 };

        bool canRunInitialMove = true;

        public void FindPathInMaze(int[,] maze, int[,] visited, int row, int col, int desRow, int desCol, int move)
        {
            if ((row == desRow) && (col == desCol))
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(visited[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("press any key to continue");

                Console.ReadKey();
             /*   Environment.Exit(0);*/
            }
            else
            {
                for (int index = 0; index < Path_Row.Length; index++)
                {
                    int rowNew = row + Path_Row[index];
                    int colNew = col + Path_Col[index];
                    if (CanWeMove(maze, visited, rowNew, colNew))
                    {
                        move++;
                        visited[rowNew, colNew] = move;
                        drawBoard(rowNew,colNew);
                        FindPathInMaze(maze, visited, rowNew, colNew, desRow, desCol, move);
                        move--;
                        visited[rowNew, colNew] = 0;
                    }
                }
            }
        }

        bool CanWeMove(int[,] maze, int[,] visited, int rowNew, int colNew)
        {
            if ((rowNew >= 0) && (rowNew < 4) && (colNew >= 0) && (colNew < 4) && (maze[rowNew, colNew] == 1) && (visited[rowNew, colNew] == 0))
            {
                return true;
            }
            return false;
        }


        private void drawBoard(int rowNew, int colNew)
        {
            Console.Clear();

            int[,] board =  {{1,1,0,1 },
                            {0,1,1,1 },
                            {0,1,0,1 },
                            {0,1,1,1 } };

            if (canRunInitialMove)
            {
                initialMove();
                canRunInitialMove = false;
            }

            board [rowNew,colNew] = 5;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            Thread.Sleep(4000);
            Console.Clear();
        }

        private void initialMove()
        {
            Console.Write("5 1 0 1\n0 1 1 1\n0 1 0 1\n0 1 1 1");
            Thread.Sleep(4000);   
            Console.Clear();
        }
    }
}
