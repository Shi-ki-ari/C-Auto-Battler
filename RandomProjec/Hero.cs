using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProjec
{
    public class Hero
    {
        private string name { get; set; }
        private double health;
        private double damage;

        private double defense;
        private double accuracy { get; set; }
        private int level { get; set; }
        private int speed;

        public double Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public double Defense
        {
            get { return defense; }
            set { defense = value; }
        }
        public double Health
        {
            get { return health; }
            set { health = value; }
        }

        private int maxHealth;

        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }



        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public void takeDamage(double incomingDamage)
        {
            double mitigated = Math.Max(1, incomingDamage - defense);
            health -= mitigated;
            Console.WriteLine($"Hero takes {mitigated} damage after mitigation. Health is now {health}");
        }


        public Hero()
        {
            this.damage = 8;
            this.defense = 6;
            this.health = 20;
            this.maxHealth = 20;
            this.accuracy = 1; 
            this.level = 1;
            this.speed = 1;
        }

        public void Attack(Monster monster)
        {
            if (new Random().Next(1, 21)* accuracy > monster.Defense)
            {
                Console.WriteLine($"Hero attacks and hits for {damage}");
                monster.takeDamage(damage);
            }
            else
            {
                Console.WriteLine("Hero attacks and misses!");
            }
        }
    }
}
