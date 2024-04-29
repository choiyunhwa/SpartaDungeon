using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Voidling : IEnemy
    {
        public String name { get; set; }
        public int level { get; set; }
        public int hleath { get; set; }
        public int damage { get; set; }
        public bool isDead { get; set; }

        public Voidling()
        {
            name = "공허충";
            level = 3;
            hleath = 10;
            damage = 7;
            isDead = false;
        }

        public int Attack()
        {
            int range = (int)(((float)damage / 10) + 0.5);
            Random rand = new Random();
            return rand.Next(damage - range, damage + range + 1);
        }

        public bool Die()
        {
            if (hleath == 0)
                return true;

            else return false;
        }
    }
}
