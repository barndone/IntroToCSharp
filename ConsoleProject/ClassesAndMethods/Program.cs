using System;

namespace AIE
{
    class Program
    {
        //program entry point
        static void Main()
        {
            Fighter partyMemberA = new Fighter("Tim");
            Fighter partyMemberB = new Fighter("Larry");
            Fighter partyMemberC = new Fighter("Cleetus");

            Fighter zombieA = new Fighter();
            Fighter zombieB = new Fighter();
            Fighter zombieC = new Fighter();

            Fighter[] party = new Fighter[3] {partyMemberA, partyMemberB, partyMemberC};
            Fighter[] enemies = new Fighter[3] {zombieA, zombieB, zombieC};

            string userInput = "";

            int partyInitiativeTracker = 0;
            int tempInt = 0;

            Random rnd = new Random();


            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Turn # " + (i + 1));

                //zombie attacks first because it's a jumpscare zombie
                if (i % 2 == 0)
                {
                    int rndTarget = rnd.Next(0, 3);

                    if (party[rndTarget].IsDead())
                    {
                        foreach(Fighter fighter in party)
                        {
                            if (fighter.IsDead())
                            {
                                Console.WriteLine("Finding Valid Target...");
                            }
                            else
                            {
                                Console.WriteLine(party[partyInitiativeTracker].GetName() + " attacked the zombie.");
                                fighter.takeDamage(party[partyInitiativeTracker]);
                                Console.WriteLine(fighter.GetName() + " has " + fighter.currentHP + " Health remaining!");
                                break;
                            }
                        }
                    }

                    Console.WriteLine("Zombie attacked the player.");
                    party[rndTarget].takeDamage(enemies[partyInitiativeTracker]);

                    if (party[rndTarget].isGuarding)
                    {
                        party[rndTarget].Guard();
                    }
                    Console.WriteLine(party[rndTarget].GetName() + " has " + party[rndTarget].currentHP + " Health remaining!");
                }
                //the player strikes back!
                else
                {
                    if (party[partyInitiativeTracker].IsDead())
                    {
                        Console.WriteLine(party[partyInitiativeTracker].GetName() + " is dead....");
                    }
                    else
                    {
                        Console.WriteLine("What would you like to do?\n\n1 - Attack\n2 - Defend");
                        if (party[partyInitiativeTracker].healCooldown == 0)
                        {
                            Console.WriteLine("3 - Heal");
                        }
                        else
                        {
                            Console.WriteLine("Heal on cooldown for " + party[partyInitiativeTracker].healCooldown + " turn(s)");
                            party[partyInitiativeTracker].healCooldown--;
                        }
                        userInput = Console.ReadLine();
                        if (userInput == "1")
                        {
                            Console.WriteLine("Choose a target to attack: ");
                            for (int z = 0; z < enemies.Length; z++)
                            {
                                if (enemies[z].IsDead())
                                {
                                    Console.WriteLine(z + 1 + " - " + enemies[z].GetName() + " is defeated!");
                                }
                                else
                                {
                                    Console.WriteLine(z + 1 + " - " + enemies[z].GetName());
                                }
                            }
                            userInput = Console.ReadLine();
                            //fail case, target a dead zombie, attack the next in line
                            if (userInput == "1" && enemies[0].IsDead())
                            {
                                Console.WriteLine("Invalid Target");
                                foreach (Fighter z in enemies)
                                {
                                    if (z.IsDead())
                                    {
                                        Console.WriteLine("Finding Valid Target...");
                                    }
                                    else
                                    {
                                        Console.WriteLine(party[partyInitiativeTracker].GetName() + " attacked the zombie.");
                                        z.takeDamage(party[partyInitiativeTracker]);
                                        Console.WriteLine(z.GetName() + " has " + z.currentHP + " Health remaining!");
                                        break;
                                    }
                                }
                            }
                            else if (userInput == "2" && enemies[1].IsDead())
                            {
                                Console.WriteLine("Invalid Target");
                                foreach (Fighter z in enemies)
                                {
                                    if (z.IsDead())
                                    {
                                        Console.WriteLine("Finding Valid Target...");
                                    }
                                    else
                                    {
                                        Console.WriteLine(party[partyInitiativeTracker].GetName() + " attacked the zombie.");
                                        z.takeDamage(party[partyInitiativeTracker]);
                                        Console.WriteLine(z.GetName() + " has " + z.currentHP + " Health remaining!");
                                        break;
                                    }
                                }
                            }
                            else if (userInput == "3" && enemies[2].IsDead())
                            {
                                Console.WriteLine("Invalid Target");
                                foreach (Fighter z in enemies)
                                {
                                    if (z.IsDead())
                                    {
                                        Console.WriteLine("Finding Valid Target...");
                                    }
                                    else
                                    {
                                        Console.WriteLine(party[partyInitiativeTracker].GetName() + " attacked the zombie.");
                                        z.takeDamage(party[partyInitiativeTracker]);
                                        Console.WriteLine(z.GetName() + " has " + z.currentHP + " Health remaining!");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                int.TryParse(userInput, out tempInt);
                                Console.WriteLine(party[partyInitiativeTracker].GetName() + " attacked the zombie.");
                                enemies[tempInt - 1].takeDamage(party[partyInitiativeTracker]);
                                Console.WriteLine(enemies[tempInt - 1].GetName() + " has " + enemies[tempInt - 1].currentHP + " Health remaining!");
                            }
                        }
                        else if (userInput == "2")
                        {
                            Console.WriteLine(party[partyInitiativeTracker].GetName() + " guarded against the attacker");
                            party[partyInitiativeTracker].Guard();
                        }
                        else if (userInput == "3")
                        {
                            if (party[partyInitiativeTracker].healCooldown == 0)
                            {
                                Console.WriteLine(party[partyInitiativeTracker].GetName() + " healed themselves.");
                                party[partyInitiativeTracker].Heal();
                                Console.WriteLine(party[partyInitiativeTracker].GetName() + " has " + party[partyInitiativeTracker].currentHP + " health remaining");
                                party[partyInitiativeTracker].healCooldown = 2;
                            }
                            //invalid input, heal cd is on cooldown, default to attack
                            else
                            {
                                Console.WriteLine("Invalid Action");
                                foreach (Fighter z in enemies)
                                {
                                    if (z.IsDead())
                                    {
                                        Console.WriteLine("Finding Valid Target...");
                                    }
                                    else
                                    {
                                        Console.WriteLine(party[partyInitiativeTracker].GetName() + " attacked the zombie.");
                                        z.takeDamage(party[partyInitiativeTracker]);
                                        Console.WriteLine(z.GetName() + " has " + z.currentHP + " Health remaining!");
                                        break;
                                    }
                                }
                            }
                        }
                        //invalid command, default to attack
                        else
                        {
                            Console.WriteLine("Invalid Action");
                            foreach (Fighter z in enemies)
                            {
                                if (z.IsDead())
                                {
                                    Console.WriteLine("Finding Valid Target...");
                                }
                                else
                                {
                                    Console.WriteLine(party[partyInitiativeTracker].GetName() + " attacked the zombie.");
                                    z.takeDamage(party[partyInitiativeTracker]);
                                    Console.WriteLine(z.GetName() + " has " + z.currentHP + " Health remaining!");
                                    break;
                                }
                            }
                        }
                        if (partyInitiativeTracker == 2)
                        {
                            partyInitiativeTracker = 0;
                        }
                        else
                        {
                            partyInitiativeTracker++;
                        }
                    }

                    if ((party[0].currentHP <= 0 && party[1].currentHP <= 0 && party[2].currentHP <= 0) ||
                        (enemies[0].currentHP <= 0 && enemies[1].currentHP <= 0 && enemies[2].currentHP <= 0))
                    {
                        if ((party[0].currentHP <= 0 && party[1].currentHP <= 0 && party[2].currentHP <= 0))
                        {
                            Console.WriteLine("GAME OVER\nThe Zombie Killed Your Party :'(");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The party has won! :D");
                            break;
                        }
                    }
                }
            }
        }
    }
}