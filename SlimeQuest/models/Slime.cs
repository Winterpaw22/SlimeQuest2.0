﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{ 
    class Slime
    {
        private ConsoleColor _color;
        private int _health;
        private int _damage;

        public int ExpGiv { get; set; }


        public bool PowerAttack { get; set; }

        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }



        /// <summary>
        /// regular enemies in field
        /// </summary>
        /// <param name="slime"></param>
        public static void InitializeNewSlime(Slime slime)
        {
            //A random system to handle the slime
            Random random = new Random();
            int slimeType = random.Next(1, 4);

            //Green Slime Builder
            if (slimeType == 1)
            {
                slime.Health = 20;
                slime.Damage = 10;
                slime.Color = ConsoleColor.DarkGreen;
                slime.PowerAttack = false;
                slime.ExpGiv = 10;

            }
            //Red Slime Builder
            else if (slimeType == 2)
            {
                slime.Health = 40;
                slime.Damage = 18;
                slime.Color = ConsoleColor.DarkRed;
                slime.PowerAttack = false;
                slime.ExpGiv = 20;



            }
            //Blue Slime Builder
            else if (slimeType == 3)
            {
                slime.Health = 30;
                slime.Damage = 15;
                slime.Color = ConsoleColor.DarkBlue;
                slime.PowerAttack = false;
                slime.ExpGiv = 15;
            }

            //Pine Slime Builder
            else
            {
                //just in case something goes wrong a slime is still initialized, although a weak one
                slime.Health = 10;
                slime.Damage = 5;
                slime.Color = ConsoleColor.Green;
                slime.PowerAttack = false;
                slime.ExpGiv = 8;
            }
           
        }


        /// <summary>
        /// overload for deadly enemies
        /// </summary>
        /// <param name="slime"></param>
        /// <param name="deadlyFirstAttack"></param>
        public static void InitializeNewSlime(Slime slime, bool deadlyFirstAttack)
        {
            //A random system to handle the slime
            Random random = new Random();
            int slimeType = random.Next(1, 4);

            //Green Slime Builder
            if (slimeType == 1)
            {
                slime.Health = 20;
                slime.Damage = 10;
                slime.Color = ConsoleColor.DarkGreen;
                slime.PowerAttack = false;
                slime.ExpGiv = 14;

            }
            //Red Slime Builder
            else if (slimeType == 2)
            {
                slime.Health = 20;
                slime.Damage = 18;
                slime.Color = ConsoleColor.DarkRed;
                slime.PowerAttack = false;
                slime.ExpGiv = 29;



            }
            //Blue Slime Builder
            else if (slimeType == 3)
            {
                slime.Health = 30;
                slime.Damage = 15;
                slime.Color = ConsoleColor.DarkBlue;
                slime.PowerAttack = false;
                slime.ExpGiv = 19;
            }

            //Pine Slime Builder
            else
            {
                //just in case something goes wrong a slime is still initialized, although a weak one
                slime.Health = 10;
                slime.Damage = 5;
                slime.Color = ConsoleColor.Green;
                slime.PowerAttack = false;
                slime.ExpGiv = 15;
            }

            if (deadlyFirstAttack)
            {
                slime.Health = 50;
                slime.Damage = 20;
                slime.Color = ConsoleColor.DarkMagenta;

                slime.ExpGiv = 50;
                slime.PowerAttack = true;
            }
        }
    }
}
