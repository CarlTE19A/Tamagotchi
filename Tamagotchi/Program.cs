using System;
using System.Collections.Generic;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            bool looping = true;
            int activeTamagotchi = 0;
            List<TamagotchiClass> tamagotchis = new List<TamagotchiClass>();

            Console.WriteLine("Its time to get your first Tamagotchi");
            NewTamagotchi();
            while(looping == true)
            {
                Console.Clear();
                foreach (TamagotchiClass tamagotchi in tamagotchis)
                {
                    tamagotchi.Tick();
                    if(tamagotchi.GetAlive() == false)
                    {
                        Console.WriteLine(tamagotchi.name + " has passed away");
                    }
                }
                if(tamagotchis[activeTamagotchi].GetAlive() == true)
                {
                    Talk();
                }
                else
                {
                    Index();
                }
            }

            void Talk()
            {
                Console.WriteLine($"Active Tamagotchi is: {tamagotchis[activeTamagotchi].name}");
                tamagotchis[activeTamagotchi].PrintStats();
                Console.WriteLine("What do you want to do?");
                string text = Console.ReadLine();
                text = text.ToLower();
                if(text == "help")
                {
                    Console.WriteLine("Help : Opens this menu");
                    Console.WriteLine("Index : Opens the index of all your Tamagotchis");
                    Console.WriteLine("New : Tired of this tamagotchi, get a new one");
                    Console.WriteLine("Feed : Feeds your active tamagotchi");
                    Console.WriteLine("Hi : Say hi to your little criter");
                    Console.WriteLine("Teach: Teach your little friend a new word");
                }
                else if(text == "index")
                {
                    Index();
                }
                else if(text == "new")
                {
                    NewTamagotchi();
                }
                else if(text == "feed")
                {
                    tamagotchis[activeTamagotchi].Feed();
                }
                else if(text == "hi")
                {
                    tamagotchis[activeTamagotchi].Hi();
                }
                else if(text == "teach")
                {
                    Console.WriteLine("Time to teach your tamagotchi a new word or phrase, what is it?");
                    string word = Console.ReadLine();
                    while(word == "")
                    {
                        Console.WriteLine("That is not a word or phrase, try again");
                        word = Console.ReadLine();
                    }
                    tamagotchis[activeTamagotchi].Teach(word);
                    Console.WriteLine("Try saying hi to your tamagotchi now that he knows how to say someting new");
                }
                else
                {
                    Console.WriteLine("Psst you can get help by writeing help");
                }
                Console.ReadLine();
            }
            void NewTamagotchi()
            {
                Console.WriteLine("Enter a name for your new Tamagotchi");
                string name = Console.ReadLine();
                while(name == "")
                {
                    Console.WriteLine("That is not a name, try again");
                    name = Console.ReadLine();
                }
                tamagotchis.Add(new TamagotchiClass(name, tamagotchis.Count));
            }
            void Index()
            {
                Console.WriteLine("Your Tamagotchis are :");
                foreach (TamagotchiClass tamagotchi in tamagotchis)
                {
                    Console.WriteLine(tamagotchi.name);
                }
            }
        }
    }
}
