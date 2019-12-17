using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    class Map
    {
        static Monster dragon = new Monster("Tiny Dragon", 10, 3);
        static Monster grunt = new Monster();

        Room entrance = new Room("Entrance", "This is an ominous room");
        Room hallway = new Room("The Hall", "The Hall stretches before you, you feel a draft", grunt);
        Room foyer = new Room("Foyer", "There is nothing of intrest here");
        Room bedroom = new Room("Master Bedroom", "The room is messy but the bed looks comfortable");
        Room closet = new Room("The Closet", "There is a dragon in here", dragon);

        Room[,] maze = new Room[3, 3];

        public Map()
        {
            maze[0, 2] = bedroom;
            maze[1, 0] = entrance; maze[1, 1] = hallway; maze[1, 2] = foyer;
            maze[2, 2] = closet;
            doorSetup();
        }

        public Room getRoom(int x, int y)
        {
            return maze[x, y];
        }

        private void doorSetup()
        {
            int north;
            int east;
            int south;
            int west;

            for(int y = 0; y < maze.GetLength(1); ++y)
            {
                for(int x = 0; x < maze.GetLength(0); ++x)
                {
                    if(maze[x,y] != null)
                    {
                        maze[x, y].xCoordinate = x;
                        maze[x, y].yCoordinate = y;
                        north = y - 1;
                        east = x + 1;
                        south = y + 1;
                        west = x - 1;

                        if( north >= 0)
                        {
                            if(maze[x,north] != null)
                            {
                                maze[x, y].doorWallNorth = true;

                                WriteLine("{0} North door unlocked {1}, {2}", maze[x, y].name, x, y);

                            }
                        }
                        if (west >= 0)
                        {
                            if (maze[west, y] != null)
                            {
                                maze[x, y].doorWallWest = true;
                                WriteLine("{0} West door unlocked {1}, {2}", maze[x, y].name, x, y);
                            }
                        }
                        if (south < maze.GetLength(1))
                        {
                            if (maze[x, south] != null)
                            {
                                maze[x, y].doorWallSouth = true;
                                WriteLine("{0} South door unlocked {1}, {2}", maze[x, y].name, x, y);
                            }
                        }
                        if (east < maze.GetLength(0))
                        {
                            if (maze[east, y] != null)
                            {
                                maze[x, y].doorWallEast = true;
                                WriteLine("{0} East door unlocked  {1}, {2}", maze[x, y].name, x, y);
                            }
                        }
                    }
                }              
            }
        }
    }
}
