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
        private int maxHealth;

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

        public int MaxHealth
        {
            get { return MaxHealth; }
            set { MaxHealth = value; }
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
        public void takeDamage(double damage)
        {
            health -= damage;
        }

        public Hero()
        {
            this.damage = 5;
            this.defense = 6;
            this.health = 20;
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
