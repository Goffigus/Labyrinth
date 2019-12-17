using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    class Room
    {
        public string name;
        string description;
        public bool doorWallNorth;
        public bool doorWallEast;
        public bool doorWallSouth;
        public bool doorWallWest;

        public bool Occupied;
        public Monster mon;

        public int xCoordinate;
        public int yCoordinate;


        public Room()
        {
            name = "Room";
            description = "This appears to be an empty room";
            doorWallNorth = false;
            doorWallEast = false;
            doorWallSouth = false;
            doorWallWest = false;
            Occupied = false;
        }

        public Room(string roomName, string roomDescription)
        {
            name = roomName;
            description = roomDescription;
            Occupied = false;
        }
        public Room(string roomName, string roomDescription, Monster m)
        {
            name = roomName;
            description = roomDescription;
            mon = m;
            Occupied = true;
        }

        public string Description()
        {
            return description;
        }
    }
}
