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
        public int HP = 20; 

        public Room Room //lets other classes see what room the player is in
        {
            get
            {
                return room;
            }
        }

        public string Name //lets other classes see what room the player is in
        {
            get
            {
                return name;
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

        public Player(string n, Room r, int HitPoints)
        {
            name = n;
            room = r;
            HP = HitPoints;
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

        public bool Combat(Monster mon)
        {
            bool win;
            string input;

            Random d6 = new Random();
            int roll;
            while (this.HP > 0 && mon.HP > 0)
            {
                WriteLine("There is a {0} here attacking you", mon.name);
                WriteLine("What do you do? (Attack, Dodge, or Block)");
                input = ReadLine();
                input = input.ToLower();
                roll = d6.Next(1, 7);
                if (input.IndexOf("attack") >= 0)
                {
                    mon.HP -= roll;
                    WriteLine("You attack doing {0} damage", roll);
                    if (mon.HP > 0)
                    {
                        this.HP -= mon.Attack;

                    }
                }
                else if (input.IndexOf("dodge") >= 0)
                {

                    if (roll > 5)
                    {
                        WriteLine("You Dodge and do a light strike!");
                        mon.HP -= d6.Next(1, 3);
                    }
                    else if (roll > 2)
                    {
                        WriteLine("You Dodge!");
                    }
                    else
                    {
                        WriteLine("Well you tried to dodge...");
                        this.HP -= Convert.ToInt32(mon.Attack * 1.5);
                    }
                }
                else if (input.IndexOf("block") >= 0)
                {
                    if (roll > 5)
                    {
                        WriteLine("You do a great block! Good job!");
                    }
                    else
                    {
                        WriteLine("You block but it still hurt a little");
                        this.HP -= mon.Attack / 2;
                    }
                }
                else
                {
                    WriteLine("You wave your hands in the air confused");
                    this.HP -= mon.Attack * 3;
                }

                WriteLine("The {0} has {1} hp and you have {2} hp left...\n good luck", mon.name, mon.HP, this.HP);
            }

            if (this.HP < 1)
            {
                WriteLine("The {0} killed {1}, ate the corpse, and lived happily ever after", mon.name, this.Name);
                win = false;
            }
            else
            {
                WriteLine("You defeated the {0}! You will eat well tonight. \n +1 Gold", mon.name);
                win = true;
                Room.Occupied = false;
            }

            return win;
        }




    }
}
