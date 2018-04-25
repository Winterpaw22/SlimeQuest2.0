using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Battle
    {




        private static bool Attack(Adventurer adventurer, Universe universe, Slime slime)
        {
            Random random = new Random();
            int damage = adventurer.Damage;
            bool blocking = false;
            bool tOb = true;
            string attackMsg = "You slap the slime, YEAH F*** THAT GUY. WOOOOOOOOOOOOOOOOOO";
            if ((adventurer.PlayerWeapon == Adventurer.Weapon.BroadSword) || (adventurer.PlayerWeapon == Adventurer.Weapon.Sword))
            {
                attackMsg = "You swing your " + adventurer.PlayerWeapon + " at the slime";
                
            }
            else if ((adventurer.PlayerWeapon == Adventurer.Weapon.Dagger))
            {
                attackMsg = "You stabb the slime with your " + adventurer.PlayerWeapon;
                
            }
            else if ((adventurer.PlayerWeapon == Adventurer.Weapon.Bow))
            {
                attackMsg = "You shoot the slime with an arrow";
                
            }
            else if ((adventurer.PlayerWeapon == Adventurer.Weapon.Mace))
            {
                attackMsg = "You hit the slime with your " + adventurer.PlayerWeapon;
                
            }
            else if ((adventurer.PlayerWeapon == Adventurer.Weapon.Staff))
            {
                attackMsg = "You cast a fire spell on the slime.";
                
            }
            //
            // PLAYER MENU
            //


            //New method for handling

            TextBoxViews.DisplayCustom(universe,new string[4] { " Attack", " Throw a Rock : " + adventurer.ItemsDictionary[Item.Items.Stone]  ," Block","Use a potion : " + adventurer.ItemsDictionary[Item.Items.HealthPotion]});

            TextBoxViews.ReWriteToMessageBox(universe, "Please choose an action...",true);

            while (tOb)
            {


                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {

                    case ConsoleKey.D1:
                        TextBoxViews.ReWriteToMessageBox(universe, attackMsg + " You dealt " + damage + " damage.");
                        slime.Health -= damage;
                        tOb = false;
                        break;
                    case ConsoleKey.D2:
                        if (adventurer.ItemsDictionary[Item.Items.Stone] >= 1)
                        {
                            adventurer.ItemsDictionary[Item.Items.Stone]--;
                            damage = 2;
                            TextBoxViews.ReWriteToMessageBox(universe, "You throw a stone at the slime and deal " + damage.ToString() + " damage.");
                            slime.Health -= damage;
                            tOb = false;
                        }
                        else
                        {
                            TextBoxViews.ReWriteToMessageBox(universe, "You dont have any rocks to throw", true);
                        }
                        break;
                    case ConsoleKey.D3:
                        TextBoxViews.ReWriteToMessageBox(universe, "You get ready to block the slime's next attack.");
                        blocking = true;
                        tOb = false;
                        break;
                    case ConsoleKey.D4:
                        if (adventurer.ItemsDictionary[Item.Items.HealthPotion] > 0)
                        {
                            adventurer.ItemsDictionary[Item.Items.HealthPotion]--;
                            Adventurer.PlayerPotionHeal(adventurer, universe);
                            tOb = false;
                        }
                        else
                        {
                            TextBoxViews.WriteToMessageBox(universe, "You don't have any health potions left");
                        }
                        break;



                    case ConsoleKey.NumPad1:
                        TextBoxViews.ReWriteToMessageBox(universe, attackMsg + " You dealt " + damage + " damage.");
                        tOb = false;
                        break;
                    case ConsoleKey.NumPad2:
                        if (adventurer.ItemsDictionary[Item.Items.Stone] > 0)
                        {
                            adventurer.ItemsDictionary[Item.Items.Stone]--;
                            damage = 2;
                            TextBoxViews.ReWriteToMessageBox(universe, "You throw a stone at the slime and deal " + damage.ToString() + " damage.");
                            slime.Health -= damage;
                            tOb = false;
                        }
                        else
                        {
                            TextBoxViews.ReWriteToMessageBox(universe,"You dont have any stones to throw!");
                        }
                        break;
                    case ConsoleKey.NumPad3:
                        TextBoxViews.ReWriteToMessageBox(universe, "You get ready to block the slime's next attack.");
                        blocking = true;
                        tOb = false;
                        break;
                    case ConsoleKey.NumPad4:
                        if (adventurer.ItemsDictionary[Item.Items.HealthPotion] > 0)
                        {
                            adventurer.ItemsDictionary[Item.Items.HealthPotion]--;
                            Adventurer.PlayerPotionHeal(adventurer, universe);
                            tOb = false;
                        }
                        else
                        {
                            TextBoxViews.WriteToMessageBox(universe, "You don't have any health potions left");
                        }
                        break;


                    default:
                        TextBoxViews.ReWriteToMessageBox(universe, "Please Choose an attack using the numbers on your keyboard.", true);
                        break;
                }
            }
            return blocking;
        }


        private static void SlimeATK(Adventurer adventurer, Universe universe, Slime slime, bool blocked)
        {

            //Setup
            Random random = new Random();
            int attack = random.Next(1, 4);
            int damage = 0;
            bool tOb = true;//tOb is here to help

            //If else statement to handle what happens next
            if (!slime.PowerAttack)
            {


                if (attack == 1)
                {
                    TextBoxViews.ReWriteToMessageBox(universe, "The slime jumps at you and lands on your foot...");
                    damage = random.Next(5, slime.Damage);

                }
                else if (attack == 2)
                {
                    TextBoxViews.ReWriteToMessageBox(universe, "The slime jumps at you and hits you in the chest...");
                    damage = random.Next(5, slime.Damage);
                }
                else if (attack == 3)
                {
                    TextBoxViews.ReWriteToMessageBox(universe, "The slime readies to do a very powerful attack...");
                    slime.PowerAttack = true;
                    tOb = false;
                }

                else { TextBoxViews.WriteToMessageBox(universe, "Error: No attack defined..."); }
            }
            else if (slime.PowerAttack)
            {
                damage = random.Next(20, slime.Damage * 3);

                TextBoxViews.ReWriteToMessageBox(universe, "The slime slams into you with a lot of force.");

                
            }
            else
            {
                TextBoxViews.ReWriteToMessageBox(universe, "Not supposed to HAPPEN");
            }



            if (tOb)
            {


                if (blocked)
                {
                    TextBoxViews.ReWriteToMessageBox(universe, "You blocked the slime's attack");
                    slime.PowerAttack = false;
                }
                else if (slime.PowerAttack)
                {

                    if (damage > 29)
                    {
                        TextBoxViews.ReWriteToMessageBox(universe, "The slime hits you for a whopping " + damage + " damage! Thats a lot of damage.");
                    }
                    else
                    {
                        TextBoxViews.ReWriteToMessageBox(universe, "The slime hits you for a whopping " + damage + " damage!");
                    }
                    slime.PowerAttack = false;
                    adventurer.Health -= damage;
                }
                else
                {
                    TextBoxViews.ReWriteToMessageBox(universe, $"The slime deals {damage} damage.");
                    adventurer.Health = adventurer.Health - damage;
                }
            }
            

        }



        public static bool BattleLoop(Adventurer adventurer, Universe universe, Slime slime)
        {
            TextBoxViews.ClearMapBox();
            TextBoxViews.RedrawBox(universe, 6);

            bool blocked;
            bool stillAlive = true;

            TextBoxViews.ReWriteToMessageBox(universe, "A slime attacks!");
            Random random = new Random();
            do
            {

                TextDrawings.DisplaySlime(slime);

                TextBoxViews.WriteToEvent("Slime : " + slime.Health);
                TextBoxViews.DisplayPlayerInfo(adventurer);

                blocked = Attack(adventurer,universe, slime);

                TextBoxViews.WriteToEvent("Slime : " + slime.Health);

                if (slime.Health > 0)
                {
                    SlimeATK(adventurer,universe, slime,blocked);
                }


            } while ((adventurer.Health > 0) && (slime.Health > 0));
            if (adventurer.Health > 0)
            {
                int coinDrop;
                int gelDrop;
                int expGain;

                coinDrop = random.Next(10, 30);
                gelDrop = random.Next(5, 15);
                expGain = random.Next(10, slime.ExpGiv);

                TextBoxViews.WriteToMessageBox(universe, $"You have succeeded in battle and have recieved {coinDrop} coins and {gelDrop} gel.");

                adventurer.Coins += coinDrop;
                adventurer.ItemsDictionary[Item.Items.SlimeGel] += gelDrop;
                adventurer.Experinece += expGain;
                if (adventurer.Experinece >= adventurer.MaxExperience)
                {
                    Adventurer.PlayerLevelUp(adventurer, universe);
                }

            }
            else
            {
                stillAlive = false;
            }
            TextBoxViews.ClearMapBox();
            TextBoxViews.RemoveContent(universe, 3);
            TextBoxViews.DisplayMenu(universe);
            TextBoxViews.DisplayPlayerInfo(adventurer);

            return stillAlive;
        }
    }
}

