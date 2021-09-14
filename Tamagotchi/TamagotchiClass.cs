using System;
using System.Collections.Generic;
namespace Tamagotchi
{
    class TamagotchiClass
    {
        public string name;
        public int id;
        private int hunger = 0;
        private int boredom = 0;
        private List<String> words = new List<String>();
        private bool isAlive = true;
        private Random generator = new Random();
        public TamagotchiClass(string _name, int _id)
        {
            name = _name;
            id = _id;
        }
        public void Tick()
        {
            hunger += generator.Next(0, 2);
            boredom += generator.Next(0, 2);
            if(hunger > 10 || boredom > 10)
            {
                isAlive = false;
                return;
            }
        }
        public void Hi()
        {
            if(words.Count > 0)
            {
                Console.WriteLine(words[generator.Next(0, words.Count)]);
            }
            else
            {
                Console.WriteLine("dodo dada");
                Console.WriteLine($"Maybe you should try and teach {name} a new word");
            }
            ReduceBoredom();
        }
        public void Teach(string word)
        {
            words.Add(word);
            ReduceBoredom();
        }
        public void PrintStats()
        {
            if(isAlive == true)
            {
                Console.WriteLine($"{name} is alive");
                Console.WriteLine($"Hunger : {hunger}");
                Console.WriteLine($"Boredom : {boredom}");
            }
            if(isAlive == false)
            {
                Console.WriteLine($"{name} is sadly dead");
            }
        }
        public bool GetAlive()
        {
            return(isAlive);
        }
        private void ReduceBoredom()
        {
            boredom -= generator.Next(1, 3);
            if(boredom < 0)
            {
                boredom = 0;
            }
        }
        public void Feed()
        {
            hunger -= generator.Next(1, 3);
            if(hunger < 0)
            {
                hunger = 0;
            }
        }
    }
}