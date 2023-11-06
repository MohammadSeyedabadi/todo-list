using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace warnsdorffsAlgorithmKnightsTourProblem
{
    public class GFG
    {

        public static int N = 8;

        // Move pattern on basis of the change of
        // x coordinates and y coordinates respectively
        public int[] cx = new int[] { 1, 1, 2, 2, -1, -1, -2, -2 };
        public int[] cy = new int[] { 2, -2, 1, -1, 2, -2, 1, -1 };

        // function restricts the knight to remain within
        // the 8x8 chessboard
        bool limits(int x, int y)
        {
            return ((x >= 0 && y >= 0) && (x < N && y < N));
        }

        /* Checks whether a square is valid and
        empty or not */
        bool isempty(int[] a, int x, int y)
        {
            return ((limits(x, y)) && (a[y * N + x] < 0));
        }

        /* Returns the number of empty squares
        adjacent to (x, y) */
        int getDegree(int[] a, int x, int y)
        {
            int count = 0;
            for (int i = 0; i < N; ++i)
                if ( isempty( a, (x + cx[i]), (y + cy[i]) ) )
                    count++;

            return count;
        }

        // Picks next point using Warnsdorff's heuristic.
        // Returns false if it is not possible to pick
        // next point.
        Cell nextMove(int[] a, Cell cell)
        {
            int min_deg_idx = -1, c,
                min_deg = (N + 1), nx, ny;

            // Try all N adjacent of (*x, *y) starting
            // from a random adjacent. Find the adjacent
            // with minimum degree.
            Random random = new Random();
            int start = random.Next(0, 1000);
            for (int count = 0; count < N; ++count)
            {
                int i = (start + count) % N;
                nx = cell.x + cx[i];
                ny = cell.y + cy[i];
                if ( (isempty(a, nx, ny)) && ( c = getDegree(a, nx, ny) ) < min_deg )
                {
                    min_deg_idx = i;
                    min_deg = c;
                }
            }

            // IF we could not find a next cell
            if (min_deg_idx == -1)
                return null;

            // Store coordinates of next point
            nx = cell.x + cx[min_deg_idx];
            ny = cell.y + cy[min_deg_idx];

            // Mark next move
            a[ny * N + nx] = a[(cell.y) * N +
                               (cell.x)] + 1;

            // Update next point
            cell.x = nx;
            cell.y = ny;

            return cell;
        }

        /* displays the chessboard with all the
        legal knight's moves */
        void print(int[] a)
        {
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                    Console.Write( a[j * N + i].ToString("00") + "  " );
                Console.Write("\n\n");
            }
        }

        /* checks its neighbouring squares */
        /* If the knight ends on a square that is one
        knight's move from the beginning square,
        then tour is closed */
        bool neighbour(int x, int y, int xx, int yy)
        {
            for (int i = 0; i < N; ++i)
                if ( ( (x + cx[i]) == xx) && ( (y + cy[i]) == yy) )
                    return true;

            return false;
        }

        /* Generates the legal moves using warnsdorff's
        heuristics. Returns false if not possible */
        public bool findClosedTour()
        {
            // Filling up the chessboard matrix with -1's
            int[] a = new int[N * N];
            for (int i = 0; i < N * N; ++i)
                a[i] = -1;

            // initial position
            int sx = 3;
            int sy = 2;

            // Current points are same as initial points
            Cell cell = new Cell(sx, sy);

            // Keep picking next points using
            // Warnsdorff's heuristic
            Cell ret = null;

            //   drawBoard(a, ret);

            a[cell.y * N + cell.x] = 1; // Mark first move.

           
           // drawBoard(a, ret);

            // Keep picking next points using
            // Warnsdorff's heuristic
           // Cell ret = null;

            for (int i = 0; i < N * N - 1; ++i) {
                ret = nextMove(a, cell);
                drawBoard(a, ret);
                if (ret == null)
                    return false;
            }

            // Check if tour is closed (Can end
            // at starting point)
            if (!neighbour(ret.x, ret.y, sx, sy)) 
                return false;
            
                

            print(a);
           
           // drawBoard(a,ret);
            return true;
        }

        private void drawBoard(int[] a, Cell ret)
        {
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if (a[j * N + i] == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("00  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (ret != null)
                    {
                        if (i == ret.x && j == ret.y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("**  ");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.Write(a[j * N + i].ToString("00") + "  ");
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("**  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }

                Console.Write("\n\n");
            }
            Thread.Sleep(100);
            for (int i = 0; i < a.Length; i++) {
                if (a[i] == 64)
                {
                    Console.ReadKey();
                }
            }
                Console.Clear();
        }
    }
}