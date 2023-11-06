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


        public void FindPathInMaze(int[,] maze, int[,] visited, int[,] ratReturns, int row, int col, int desRow, int desCol, int move)
        {
            if ((row == desRow) && (col == desCol))
            {
                for (int i = 0; i < visited.GetLength(0); i++)
                {
                    for (int j = 0; j < visited.GetLength(1); j++)
                    {
                        if (visited[i, j] == 01 || visited[i, j] > 01)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(visited[i, j].ToString("00") + "  ");
                        }
                        else if (maze[i, j] == 01)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("01" + "  ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("00" + "  ");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }

                playBeep();

                Console.WriteLine("press any key to continue");

                Console.ReadKey();
                /*   Environment.Exit(0);*/
                drawBoard(row, col, maze, visited, ratReturns);
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
                        drawBoard(rowNew, colNew, maze, visited, ratReturns);
                        FindPathInMaze(maze, visited,ratReturns, rowNew, colNew, desRow, desCol, move);
                        move--;
                        visited[rowNew, colNew] = 0;
                        ratReturns[rowNew, colNew] = 1;
                        drawBoard(row, col, maze, visited, ratReturns);
                    }
                }
            }
        }

        bool CanWeMove(int[,] maze, int[,] visited, int rowNew, int colNew)
        {
            if ((rowNew >= 0) && (rowNew < 10) && (colNew >= 0) && (colNew < 10) && (maze[rowNew, colNew] == 1) && (visited[rowNew, colNew] == 0))
            {
                return true;
            }
            return false;
        }


        private void drawBoard(int rowNew, int colNew, int[,] maze, int[,] visited, int[,] ratReturns)
        {
            Console.Clear();

            if (canRunInitialMove)
            {
                initialMove(maze);
                canRunInitialMove = false;
            }
            int temp = maze[rowNew, colNew];
            maze[rowNew, colNew] = 5;

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == 05)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("05" + "  ");

                    }
                    else if (visited[i, j] != 0) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("++" + "  ");
                    }
                    else if (ratReturns[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("//" + "  ");
                    }
                    else if (maze[i, j] == 01)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("01" + "  ");
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(maze[i, j].ToString("00") + "  ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Thread.Sleep(100);
            Console.Clear();
            maze[rowNew, colNew] = temp;
        }

        private void initialMove(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 05)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(board[i, j].ToString("00") + "  ");
                    }
                    else if (board[i, j] == 01)
                    {
                        if (i == 0 && j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("05" + "  ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(board[i, j].ToString("00") + "  ");
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(board[i, j].ToString("00") + "  ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Thread.Sleep(100);
            Console.Clear();
        }

        private void playBeep()
        {
            // Set the Frequency 
            int frequency1 = 1500;
            int frequency2 = 2000;
            int frequency3 = 2500;

            // Set the Duration 
            int duration = 300;

            int n = 4;

            // Play beep sound n times 
            for (int i = 0; i < n; i++)
            {
                Console.Beep(frequency1, duration);
            }
            for (int i = 0; i < n; i++)
            {
                Console.Beep(frequency2, duration);
            }

            for (int i = 0; i < n; i++)
            {
                Console.Beep(frequency3, duration);
            }
            Console.Beep(frequency3, 950);
        }
    }
}