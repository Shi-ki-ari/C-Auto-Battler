using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace RandomProjec
{

    public class Monster
    {
        public Random rand = new Random(); //Random for this class
        protected string name { get; set; }
        protected string type { get; set; }
        protected double health { get; set; }
        protected double damage { get; set; }

        protected double defense { get; set; }
        protected double accuracy { get; set; }
        protected int speed { get; set; }

        public Hero TargetHero { get; set; }

        public Monster(Hero hero)
        {
            TargetHero = hero;
        }
        Random roll = new Random();

        public double Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
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
        public void Attack(Hero hero)
        {

            if (roll.Next(1, 21) * accuracy > hero.Defense)
            {
                Console.WriteLine($"Monster attacks and hits for {damage}");
                hero.takeDamage(damage);
            }
            else
            {
                Console.WriteLine("Monster attacks and misses!");
            }
        }


        public void takeDamage(double damage)
        {
            health -= damage;
        }


    }


    public class Goblin : Monster
    {
        private string weapon { get; set; }

        private string[] goblinWeapons = { "shortsword", "shortaxe", "club" };

        public Goblin(Hero hero) : base(hero)
        {
            this.weapon = goblinWeapons[rand.Next(goblinWeapons.Length)];
            this.health = 10;
            this.damage = 3;
            this.defense = 2;
            this.accuracy = 0.8;
            this.speed = 0;
        }
    }

    public class Orc : Monster
    {
        private string[] orcArmors = { "leather", "chainmail", "plate" };
        private string[] orcWeapons = { "longsword", "battleaxe", "warhammer" };
        private string weapon { get; set; }
        private string armor { get; set; }

        public Orc(Hero hero) : base(hero)
        {
            this.weapon = orcArmors[rand.Next(orcArmors.Length)];
            this.armor = orcWeapons[rand.Next(orcWeapons.Length)];
            this.health = 15;
            this.damage = 4;
            this.defense = 3;
            this.accuracy = 0.75;
            this.speed = 0;

        }

    }

    public class Wyrmling : Monster
    {
        private string type { get; set; }
        private string[] types = { "fire", "ice", "lightning" };

        public Wyrmling(Hero hero) : base(hero)
        {
            this.type = types[rand.Next(types.Length)];
            this.health = 20;
            this.damage = 5;
            this.defense = 4;
            this.accuracy = 0.7;
            this.speed = 0;

        }

    }


    public class MonsterFactory
    {
        private Hero hero;
        public List<Monster> monsters;
        Random random = new Random();

        public MonsterFactory(Hero hero)
        {
            this.hero = hero;
            this.monsters = new List<Monster>
        {
            createGoblin(hero),
            createOrc(hero),
            createWyrmling(hero)
        };
        }

        private Monster createGoblin(Hero hero)
        {
            return new Goblin(hero);
        }

        private Monster createOrc(Hero hero)
        {
            return new Orc(hero);
        }

        private Monster createWyrmling(Hero hero)
        {
            return new Wyrmling(hero);
        }

        public Monster getRandomMonster()
        {
            int index = random.Next(monsters.Count);
            return monsters[index];
        }
    }

}

