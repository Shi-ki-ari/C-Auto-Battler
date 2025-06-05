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

        protected double health;
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


        public void takeDamage(double incomingDamage)
        {
            double mitigated = Math.Max(1, incomingDamage - defense);
            health -= mitigated;
            Console.WriteLine($"Monster takes {mitigated} damage after mitigation. Health is now {health}");
        }




    }


    public class Goblin : Monster
    {
        private string weapon { get; set; }

        private string[] goblinWeapons = { "shortsword", "shortaxe", "club" };

        public Goblin(Hero hero) : base(hero)
        {
            this.weapon = goblinWeapons[rand.Next(goblinWeapons.Length)];
            this.health = 5;
            this.damage = 5;
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
            this.health = 10;
            this.damage = 8;
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
            this.health = 15;
            this.damage = 12;
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
            // instead of returning the same instance, create a new monster each time:
            Monster monsterToClone = monsters[index];

            if (monsterToClone is Goblin)
                return new Goblin(hero);
            else if (monsterToClone is Orc)
                return new Orc(hero);
            else if (monsterToClone is Wyrmling)
                return new Wyrmling(hero);
            else
                return monsterToClone; // fallback
        }

    }

}

