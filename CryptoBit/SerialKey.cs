using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoBit
{
    class SerialKey
    {

        private int keyLength;
        private string[] list1 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o",
                            "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D",
                            "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S",
                            "T", "U", "V", "W", "X", "Y", "Z" };
        private int[] list2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public SerialKey(int keyLength)
        {
            this.keyLength = keyLength;
        }

        public string generateKey()
        {
            Random rnd = new Random();
            int chance = 0;
            string key = "";

            for (int i = 0; i < keyLength; i++)
            {
                chance = rnd.Next(100);
                if (chance >= 50)
                {
                    chance = rnd.Next(list1.Length);
                    key += list1[chance];
                }
                else
                {
                    chance = rnd.Next(list2.Length);
                    key += list2[chance];
                }
            }


            return key;

        }

    }
}
