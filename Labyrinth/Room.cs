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


        public Room()
        {
            name = "Room";
            description = "This appears to be an empty room";
            doorWallNorth = false;
            doorWallEast = false;
            doorWallSouth = false;
            doorWallWest = false;
        }

        public Room(string roomName, string roomDescription)
        {
            name = roomName;
            description = roomDescription;
        }
    }
}
