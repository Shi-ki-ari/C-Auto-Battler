﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProjec
{
    public class GameLogic
    {
        private MonsterFactory monsterFactory;

        private Hero hero;
        private Monster monster {  get; set; }
        private bool isGameOver;
        private bool isHeroTurn;
        private bool inCombat = true;

        public GameLogic()
        {
            this.hero = new Hero();
            this.monsterFactory = new MonsterFactory(hero);
            this.monster = monsterFactory.getRandomMonster(); 
        }


        public void StartGame()
        {

            while (!isGameOver)
            {
                initiativeRoll(hero, monster);
                switch (monster)
                {
                    case Goblin goblin:
                        Console.WriteLine("It's a pathetic Goblin!");
                        break;

                    case Orc orc:
                        Console.WriteLine("It's a fearsome Orc!");
                        break;

                    case Wyrmling wyrmling:
                        Console.WriteLine("It's a mighty Wyrmling!");
                        break;

                    default:
                        Console.WriteLine("Unknown monster type");
                        break;
                }
                while (inCombat)
                {

                    //Combat
                    if (isHeroTurn)
                    {
                        Console.WriteLine("Hero's turn");
                        hero.Attack(monster);
                        System.Threading.Thread.Sleep(4000);
                        isHeroTurn = false;
                    }
                    else
                    {
                        Console.WriteLine("Monster's turn");
                        monster.Attack(hero);
                        System.Threading.Thread.Sleep(4000);
                        isHeroTurn = true;
                    }

                    if (hero.Health <= 0)
                    {
                        EndGame();
                    }
                    else if (monster.Health <= 0)
                    {
                        Console.WriteLine("The hero is victorious");
                        Console.WriteLine($"The hero has {hero.Health} health left");
                        hero.Health += 5;
                        if (hero.Health > hero.MaxHealth)
                        {
                            hero.Health = hero.MaxHealth;
                        }
                        Console.WriteLine($"Hero heals for 5 health and has {hero.Health} health");

                        // Spawn new monster for next round
                        monster = monsterFactory.getRandomMonster();
                        break;
                    }

                }

                //Pick level up;
                hero.Level = hero.Level + 1;
                Console.WriteLine("Pick stat to level");
                Console.Write("1. Damage\n2. Health\n");
                string input = Console.ReadLine();
                switch (input) { 
                    case "1":
                        hero.Damage += 1;
                        Console.WriteLine("Hero damage increased by 1");
                        break;
                    case "2":
                        hero.MaxHealth += 3;
                        hero.Health += 3; 

                        Console.WriteLine("Hero health increased by 3");
                        break;

                }

            }
        }

        private void EndGame()
        {
            isGameOver = true;
            Console.WriteLine("Game Over! Hero has been defeated.");
        }

        public void initiativeRoll(Hero hero, Monster monster)
        {

                int heroRoll = new Random().Next(1, 21) + hero.Speed;
                int monsterRoll = new Random().Next(1, 21) + monster.Speed;

                if (heroRoll > monsterRoll)
                {
                    Console.WriteLine("Hero goes first!");
                    isHeroTurn = true;
                }
                else if (monsterRoll > heroRoll)
                {
                    Console.WriteLine("Monster goes first!");
                    isHeroTurn = false;
                }
                else
                {
                    Console.WriteLine("It's a tie! Rolling again...");
                }
            return;
        }

    }
}
