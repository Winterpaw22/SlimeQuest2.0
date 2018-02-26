using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Validators
    {
        public static int ValidInt()
        {
            bool validIntResponse = false;
            int validInt = 16;
            string invalidInt;
            while (!validIntResponse)
            {
                TextBoxViews.ClearInput();
                Console.SetCursorPosition(7,56);
                invalidInt = Console.ReadLine();

                if (int.TryParse(invalidInt, out validInt))
                {
                    validIntResponse = true;
                }
                else
                {
                    TextBoxViews.ErrorTextBox("Error: you need to enter a valid real Interger");
                }
            }
            TextBoxViews.ClearInputBox();
            return validInt;
        }

        public static Adventurer.Weapon WeaponValidation()
        {
            Adventurer.Weapon weapon = Adventurer.Weapon.Sword;
            bool loop = true;
            string response;
            
            while (loop)
            {
                TextBoxViews.ClearInput();
                Console.SetCursorPosition(4, 56);
                response = Console.ReadLine();
                switch (response.ToUpper())
                {
                    case "BOW":
                        weapon = Adventurer.Weapon.Bow;
                        loop = false;
                        break;
                    case "SWORD":
                        weapon = Adventurer.Weapon.Sword;
                        loop = false;
                        break;
                    case "STAFF":
                        weapon = Adventurer.Weapon.Staff;
                        loop = false;
                        break;

                    case "BROADSWORD":
                        weapon = Adventurer.Weapon.BroadSword;
                        loop = false;
                        break;

                    case "DAGGER":
                        weapon = Adventurer.Weapon.Dagger;
                        loop = false;
                        break;

                    case "MACE":
                        weapon = Adventurer.Weapon.Mace;
                        loop = false;
                        break;

                    default:
                        TextBoxViews.ErrorTextBox("Invalid Weapon Please type in a valid weapon from the provided above");
                        break;
                }
            }
            TextBoxViews.ClearInputBox();
            return weapon;
        }

        public static Adventurer.Race RaceValidation()
        {
            Adventurer.Race race = Adventurer.Race.Orc;
            bool loop = true;
            string response;
            while (loop)
            {
                TextBoxViews.ClearInput();
                Console.SetCursorPosition(4, 56);
                response = Console.ReadLine();
                switch (response.ToUpper())
                {
                    case "HUMAN":
                        race = Adventurer.Race.Human;
                        loop = false;
                        break;
                    case "SLIME":
                        race = Adventurer.Race.Slime;
                        loop = false;
                        break;
                    case "ORC":
                        race = Adventurer.Race.Orc;
                        loop = false;
                        break;
                    default:
                        TextBoxViews.ErrorTextBox("Invalid Race Please type in a valid race from the provided above");
                        break;
                }
            }
            TextBoxViews.ClearInputBox();
            return race;
        }
    }
}
