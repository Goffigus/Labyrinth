using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Labyrinth
{
    class Player
    {
        string name;
        Room room;

        public Room Room //lets other classes see what room the player is in
        {
            get
            {
                return room;
            }
        }


        public Player(Room r)
        {
            name = "John Doe";
            room = r;
        }
        public Player(string n, Room r)
        {
            name = n;
            room = r;
        }

        /// <summary>
        /// Writes out which doors are availble
        /// </summary>
        public void checkDoors()
        {
            if(room.doorWallNorth)
            {
                WriteLine("There is a door to the North");
            }
            if (room.doorWallEast)
            {
                WriteLine("There is a door to the East");
            }
            if (room.doorWallSouth)
            {
                WriteLine("There is a door to the South");
            }
            if(room.doorWallWest)
            {
                WriteLine("There is a door to the West");
            }
        }

        //movement
        public void MovePlayer(string move, Map map)
        {
            move = move.ToLower();

            int xMove;
            int yMove;

            bool door;
            if(move.IndexOf("north") >= 0)
            {
                xMove = room.xCoordinate;
                yMove = room.yCoordinate - 1;
                door = room.doorWallNorth;
            } else if(move.IndexOf("south") >= 0)
            {
                xMove = room.xCoordinate;
                yMove = room.yCoordinate + 1;
                door = room.doorWallSouth;
            }
            else if (move.IndexOf("east") >= 0)
            {
                xMove = room.xCoordinate + 1;
                yMove = room.yCoordinate;
                door = room.doorWallEast;
            }
            else if (move.IndexOf("west") >= 0)
            {
                xMove = room.xCoordinate - 1;
                yMove = room.yCoordinate;
                door = room.doorWallWest;
            } else
            {
                xMove = room.xCoordinate;
                yMove = room.yCoordinate;
                door = true;
                WriteLine("You stand there confused");
            }

            if(door)
            {
                room = map.getRoom(xMove, yMove);
            } else
            {
                WriteLine("There is no door there");
            }
        }




    }
}
