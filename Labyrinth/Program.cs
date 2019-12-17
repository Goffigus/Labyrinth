using System;
using static System.Console;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {

            Map maze = new Map();
            Player pc = new Player(maze.getRoom(1, 0));
            string input;
            bool win;

            while(true)
            {
                WriteLine("You are in the {0} \n {1}", pc.Room.name, pc.Room.Description());
                pc.checkDoors();
                input = ReadLine();
                pc.MovePlayer(input, maze);

                if(pc.Room.Occupied)
                {
                    Monster mon = pc.Room.mon;

                    win = pc.Combat(mon);

                    if(!win)
                    {
                        break;
                    }
                }

            }

            WriteLine("GAME OVER");
       
        }
    }
}
