using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    class Monster
    {
        public string name;
        public int HP;
        public int Attack;

        

        public Monster()
        {
            name = "Grunt";
            HP = 5;
            Attack = 1;
        }
        public Monster(string n)
        {
            name = n;
            HP = 5;
            Attack = 1;
        }
        public Monster(int HitPoints, int attk)
        {
            name = "Grunt";
            HP = HitPoints;
            Attack = attk;
        }
        public Monster(string n, int HitPoints, int attk)
        {
            name = n;
            HP = HitPoints;
            Attack = attk;
        }
    }
}
