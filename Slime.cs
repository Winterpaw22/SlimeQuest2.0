using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Slime
    {

        public enum Charms
        {
            REDCHARM, //Attack , Can add additional damage when you attack, Using the slime will apply fire to your sword for 2 turns, Chance to inflict burn TBA
            BLUECHARM,//Defence , Chance to negate some damage (1,5) if damage already low then enemy deals (1) damage
            PINKCHARM, //Regeneration , Use to heal yourself for 5 damage. After every battle heal for 5 health
            GREENCHARM //Extra Experience
        
        }

        private string _color;
        private int _health;
        private int _damage;
        //private bool _passive;
        private bool _king;
        private bool _hasCharm;
        private Charms _charm;
        private bool _encounter;

        #region Properties

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        //public bool Passive
        //{
        //    get { return _passive; }
        //    set { _passive = value; }
        //}

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public bool KingSlime
        {
            get { return _king; }
            set { _king = value; }
        }

        public bool HasCharm
        {
            get { return _hasCharm; }
            set { _hasCharm = value; }
        }

        public Charms AllyCharm
        {
            get { return _charm; }
            set { _charm = value; }
        }

        public bool AllyDisabler
        {
            get { return _encounter; }
            set { _encounter = value; }
        }

        #endregion


        #region SlimeMethods
        static void InitializeNewSlime(Slime slime, bool passive, Ally ally)
        {
            //A random system to handle the slime
            Random random = new Random();
            int slimeType = random.Next(1, 5);
            int charmChance = random.Next(1, 10);

            //Green Slime Builder
            if (slimeType == 1)
            {
                slime.Health = 20;
                slime.Damage = 2;
                slime.Color = "green";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.GREENCHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;
            }
            //Red Slime Builder
            else if (slimeType == 2)
            {
                slime.Health = 20;
                slime.Damage = 5;
                slime.Color = "red";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.REDCHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;
            }
            //Blue Slime Builder
            else if (slimeType == 3)
            {
                slime.Health = 30;
                slime.Damage = 4;
                slime.Color = "blue";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.BLUECHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;
            }
            //Pink Slime Builder
            else if (slimeType == 4)
            {
                slime.Health = 45;
                slime.Damage = 3;
                slime.Color = "pink";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.PINKCHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;

            }
            //Pine Slime Builder
            else
            {
                //just in case something goes wrong a slime is still initialized, although a weak one
                slime.Health = 10;
                slime.Damage = 1;
                slime.Color = "pine";
                slime.HasCharm = false;

            }
            //King Slime builder
            if (slime.KingSlime)
            {
                slime.HasCharm = false;
                slime.Health = 55;
                slime.Damage = 10;
                slime.Color = "purple";
                //if (charmChance < 5 && ally.Active)
                //{
                //    ally.Charm = Ally.Charms.GREENCHARM;
                //    slime.HasCharm = true;
                //}
                //else slime.HasCharm = false;
            }


        }



        static void Player(Player player, Slime slime, Ally ally)
        {
            Random random = new Random();
            int damage = 1;
            //
            // PLAYER MENU
            //
            Console.Clear();
            DisplayGameScreen();
            DisplayTextBoxPlayer();
            int action;
            Console.CursorVisible = true;
            Console.SetCursorPosition(29, 33);
            Console.Write($" 1  Attack");
            Console.SetCursorPosition(50, 33);
            Console.Write($"{player.Name} : {player.Health}");
            Console.SetCursorPosition(29, 34);
            Console.Write($" 2  Throw a stick");
            Console.SetCursorPosition(50, 34);

            Console.Write($"Slime:{slime.Health}");
            if (ally.Active)
            {
                Console.SetCursorPosition(29, 35);
                Console.WriteLine($" 3  Ally");
            }
            Console.SetCursorPosition(34, 36);
            Console.WriteLine("Gold: " + player.Gold);
            Console.SetCursorPosition(34, 37);
            Console.WriteLine("Experience: " + player.Experience);

            int tOb = 33;
            int tObLast = 33;
            ConsoleKeyInfo keyPress;
            bool optionSelected = false;
            Console.CursorVisible = true;
            action = 1;
            Console.SetCursorPosition(26, 33);
            Console.Write("->");
            while (!optionSelected)
            {
                keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.UpArrow)
                {

                    if (action == 2)
                    {
                        action--;
                        tOb--;
                    }
                    else if (action == 3)
                    {
                        action--;
                        tOb--;
                    }
                    Console.SetCursorPosition(26, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                }
                if (keyPress.Key == ConsoleKey.DownArrow)
                {
                    if (action == 1)
                    {
                        action++;
                        tOb++;
                    }

                    if (ally.Active)
                    {
                        if (action == 2)
                        {
                            action++;
                            tOb++;
                        }
                    }

                    Console.SetCursorPosition(26, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    optionSelected = true;
                }
                Console.SetCursorPosition(26, tObLast);

            }

            public static void SlimeATK(Player player, Slime slime)
            {

                //Setup
                ClearPlayerTextBox();
                Random random = new Random();
                int attack = random.Next(1, 2);
                int damage = 0;
                Console.SetCursorPosition(27, 34);
                //If else statement to handle what happens next
                if (attack == 1)
                {
                    Console.WriteLine("The slime lunges at your face and latches on...");

                    Thread.Sleep(1000);
                    damage = random.Next(1, slime.Damage);
                    Thread.Sleep(1000);
                }
                else if (attack == 2)
                {
                    Console.WriteLine("The slime jumps at you and lands on your foot...");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(27, 35);
                    Console.WriteLine("...");
                    //SlimeType
                    Thread.Sleep(1000);
                }
                else { Console.WriteLine("Error: No attack defined..."); }
                //Console.SetCursorPosition(27, 35);
                //if ()
                //{
                //    Console.WriteLine("You blocked the attack!");
                //    player.Defending = false;
                //}
                Console.SetCursorPosition(27, 36);
                Console.Write($"the slime deals {damage} damage.");
                player.Health = player.Health - damage;


                Thread.Sleep(1500);

            }



            static void BattleLoop(Player player, Slime slime, Ally ally)
            {
                Random random = new Random();
                do
                {
                    ClearPlayerTextBox();
                    if (slime.KingSlime)
                    {
                        DisplayKingSlime();
                    }
                    else
                    {
                        DisplaySlime(slime);
                    }
                    SlimeAndChatColor(slime);

                    Player(player, slime, ally);
                    Thread.Sleep(1000);
                    ClearPlayerTextBox();
                    if (slime.Health > 0)
                    {
                        SlimeATK(player, slime);
                    }


                } while ((player.Health > 0) && (slime.Health > 0));



                ClearPlayerTextBox();
                Console.ForegroundColor = ConsoleColor.Yellow;
                #region Gold and Experience
                int goldDrop;
                int exp;
                if (slime.KingSlime)
                {
                    goldDrop = random.Next(60, 100);
                    exp = random.Next(200, 500);
                }
                else if (slime.Color == "red")
                {
                    goldDrop = random.Next(20, 30);
                    exp = random.Next(100, 150);
                }
                else if (slime.Color == "blue")
                {
                    goldDrop = random.Next(10, 15);
                    exp = random.Next(60, 100);
                }
                else if (slime.Color == "green")
                {
                    goldDrop = random.Next(4, 7);
                    exp = random.Next(20, 60);
                }
                else
                {
                    goldDrop = random.Next(2, 5);
                    exp = random.Next(2, 30);
                }
                Console.SetCursorPosition(27, 33);
                Console.Write($"You have succeeded in battle and have recieved {goldDrop} Gold!");
                Console.SetCursorPosition(27, 34);
                Console.Write($"You gained {exp} Experience Points!");

                player.Gold = player.Gold + goldDrop;
                player.Experience = player.Experience + exp;
                #endregion



                if (slime.HasCharm)
                {
                    InitializeAlly(ally, slime, player);
                    Console.SetCursorPosition(27, 34);
                    Console.Write("You picked up a Slime charm... You put it around your neck.");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(27, 35);
                    Console.Write("A little slime appears next to you and jumps on your head");
                    Thread.Sleep(1000);
                    switch (ally.Charm)
                    {
                        case Ally.Charms.REDCHARM:
                            Console.SetCursorPosition(27, 36);
                            Console.Write("It appears the slime is wielding its own sword");
                            Thread.Sleep(2500);
                            Console.SetCursorPosition(27, 37);
                            Console.WriteLine("The slime fights along side you!");
                            Thread.Sleep(1000);
                            break;
                        case Ally.Charms.BLUECHARM:
                            Console.SetCursorPosition(27, 36);
                            Console.Write("The slime makes a small shield out of its own goo, ");
                            Thread.Sleep(2500);
                            Console.SetCursorPosition(27, 37);
                            Console.WriteLine("It seems to be trying to protect you...");
                            Thread.Sleep(1000);
                            break;
                        case Ally.Charms.PINKCHARM:
                            Console.SetCursorPosition(27, 36);
                            Console.Write("You feel your injuries heal slightly");
                            Thread.Sleep(2500);
                            Console.SetCursorPosition(27, 37);
                            Console.WriteLine("You regained 5 health!");
                            Thread.Sleep(1000);
                            player.Health = player.Health + 5;
                            if (player.Health > player.MaxHealth)
                            {
                                player.Health = player.MaxHealth;
                            }
                            break;
                        case Ally.Charms.GREENCHARM:
                            Console.SetCursorPosition(27, 36);
                            Console.Write("You start remembering more about your battle");
                            Thread.Sleep(2500);
                            Console.SetCursorPosition(27, 37);
                            Console.WriteLine("Experience boost!");
                            Thread.Sleep(1000);
                            break;
                        default:
                            Console.SetCursorPosition(27, 36);
                            Console.Write("BROKEN ERROR ERROR ERROR ERROR");
                            Thread.Sleep(2500);
                            Console.SetCursorPosition(27, 37);
                            Console.WriteLine("SOME SHIT WENT DOWN NOW FIX OR WAIT A YEAR ");
                            Thread.Sleep(99999999);
                            break;
                    }


                    DisplayContinuePrompt(103, 38);
                    ClearPlayerTextBox();

                }
                Console.ForegroundColor = ConsoleColor.Gray;

                DisplayContinuePrompt(103, 38);
            }



            static void LevelUp(Player player)
            {
                Console.Clear();
                DisplayGameScreen();
                DisplayTextBoxPlayer();
                Console.CursorVisible = false;
                Console.SetCursorPosition(44, 10);
                Console.Write("Health : " + player.MaxHealth);// left 54 for end || 57 for + 59 for health
                Console.SetCursorPosition(44, 12);
                Console.Write("Defense : " + player.Defense);// 55 for end, || 57 for + 59 for defense
                Console.SetCursorPosition(44, 14);
                Console.Write("Damage : " + player.Damage[1]);// left 54 for end || 57 for + 59 for damage
                                                              //Options Health, Defense, Attack   
                                                              //These will be added to the max
                int health = 0;
                int defense = 0;
                int damage = 0;
                int pointsAvlb = 3;
                //-------------------------------------
                Random random = new Random();
                int action;
                //Origin of tOb is unknown but now im calling it tOb as a reference to a tab. It works so shhhhh
                //
                //Cursors current position
                int tOb = 10;
                //cursors last position
                int tObLast = 10;
                // Option Positions   28 : 17,18,19 
                ConsoleKeyInfo keyPress;
                bool optionSelected = false;
                Console.CursorVisible = true;
                action = 1;
                Console.SetCursorPosition(40, 10);
                Console.Write("->");
                while (!optionSelected)
                {

                    keyPress = Console.ReadKey();
                    //Movement for cursor tOb
                    #region tOb movement
                    if (keyPress.Key == ConsoleKey.UpArrow)
                    {

                        if (action == 2)
                        {
                            action--;
                            tOb--;
                            tOb--;
                        }
                        else if (action == 3)
                        {
                            action--;
                            tOb--;
                            tOb--;
                        }
                        Console.SetCursorPosition(40, tObLast);
                        Console.Write("  ");
                        Console.SetCursorPosition(40, tOb);
                        Console.Write("->");
                        tObLast = tOb;
                    }
                    if (keyPress.Key == ConsoleKey.DownArrow)
                    {
                        if (action == 1)
                        {
                            action++;
                            tOb++;
                            tOb++;
                        }
                        else if (action == 2)
                        {
                            action++;
                            tOb++;
                            tOb++;
                        }

                        Console.SetCursorPosition(40, tObLast);
                        Console.Write("  ");
                        Console.SetCursorPosition(40, tOb);
                        Console.Write("->");
                        tObLast = tOb;
                    }
                    #endregion

                    if (keyPress.Key == ConsoleKey.RightArrow)
                    {
                        if (action == 1)
                        {
                            if (pointsAvlb > 0)
                            {
                                //57 for + 59 for health
                                health++;
                                pointsAvlb--;
                                Console.SetCursorPosition(57, 10);
                                Console.Write("+ " + health);
                            }
                        }
                        if (action == 2)
                        {
                            if (pointsAvlb > 0)
                            {
                                defense++;
                                pointsAvlb--;
                                Console.SetCursorPosition(57, 12);
                                Console.Write("+ " + defense);
                            }
                        }
                        if (action == 3)
                        {
                            if (pointsAvlb > 0)
                            {
                                damage++;
                                pointsAvlb--;
                                Console.SetCursorPosition(57, 14);
                                Console.Write("+ " + damage);
                            }
                        }

                    }
                    if (keyPress.Key == ConsoleKey.LeftArrow)
                    {
                        if (action == 1)
                        {
                            if (pointsAvlb >= 0 && health != 0)
                            {
                                health--;
                                pointsAvlb++;
                                Console.SetCursorPosition(57, 10);
                                Console.Write("+ " + health);

                            }
                            else if (health <= 0)
                            {
                                Console.SetCursorPosition(57, 10);
                                Console.Write("           ");
                            }
                        }
                        if (action == 2)
                        {
                            if (pointsAvlb >= 0 && defense != 0)
                            {
                                defense--;
                                pointsAvlb++;
                                Console.SetCursorPosition(57, 12);
                                Console.Write("+ " + defense);

                            }
                            else if (defense <= 0)
                            {
                                Console.SetCursorPosition(57, 12);
                                Console.Write("           ");
                            }
                        }
                        if (action == 3)
                        {
                            if (pointsAvlb >= 0 && damage != 0)
                            {
                                damage--;
                                pointsAvlb++;
                                Console.SetCursorPosition(57, 14);
                                Console.Write("+ " + damage);

                            }
                            else if (damage <= 0)
                            {
                                Console.SetCursorPosition(57, 14);
                                Console.Write("           ");
                            }
                        }
                    }
                    if (keyPress.Key == ConsoleKey.Enter)
                    {
                        optionSelected = true;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write("health " + health + "| Defense " + defense + "| Damage " + damage + "| Points Available " + pointsAvlb);
                    Console.SetCursorPosition(40, tObLast);

                }

                //applying the stat points to the player
                player.Health = player.Health + health;
                player.Defense = player.Defense + defense;
                player.Damage[1] = player.Damage[1] + damage;
                player.Damage[0] = player.Damage[0] + damage;
            }
            #endregion
        }
    }