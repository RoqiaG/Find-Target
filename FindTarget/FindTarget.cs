using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public struct Location
    {
        int x, y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

    }


    public static class FindTarget
    {

        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the dimention of the board and the current location of the player, calculate the min number of moves to reach the given target or return -1 if can't be reached
        /// </summary>
        /// <param name="N">board dimension</param>
        /// <param name="src">current location of the player</param>
        /// <param name="target">target location</param>
        /// <returns>min number of moves to reach the target OR -1 if can't reach the target</returns>

        public static int Play(int N, Location src, Location target)
        {
            // check the source and target locations if not valid return -1
            if (src.X < 1 || src.X > N || src.Y < 1 || src.Y > N || target.X < 1 || target.X > N || target.Y < 1 || target.Y > N)
            {
                return -1;
            }

            bool[,] discovered = new bool[N + 1, N + 1];
            Queue<Location> queue = new Queue<Location>();
            discovered[src.X, src.Y] = true;
            queue.Enqueue(src);



            //  possible moves
            int[][] Moves = new int[][]
            {
                new int[] {2,3},
                new int[] {2,-3},
                new int[] {-2,3},
                new int[] {-2,-3}
           };

            //initialize distance
            int[,] dist = new int[N + 1, N + 1];
            dist[src.X, src.Y] = 0;

            // use BFS 
            while (queue.Count > 0)
            {
                Location present = queue.Dequeue();
                //  visit all possible moves  
                foreach (int[] move in Moves)
                {
                    int x = move[0];
                    int y = move[1];
                    int newx = present.X + x;
                    int newy = present.Y + y;

                    // if we reach the target return min number of moves 
                    if (present.X == target.X && present.Y == target.Y)
                    {
                        return dist[present.X, present.Y];
                    }

                    //  if the new location is valid and not discovered(not visited) 
                    if (newx >= 1 && newx <= N && newy >= 1 && newy <= N && !discovered[newx, newy])
                    {
                        Location new_location = new Location { X = newx, Y = newy };
                        dist[newx, newy] = dist[present.X, present.Y] + 1;
                        discovered[newx, newy] = true;
                        queue.Enqueue(new_location);
                    }



                }


            }
            //target unreachable
            return -1;
        }

    }
}
#endregion



