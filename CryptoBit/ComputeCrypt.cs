using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CryptoBit
{
    class ComputeCrypt
    {
        private string textBox1;
        private string textBox2;
        private bool whichCrypt;


        private int cryptInt = 0;
        private int saveInt = 0;
        private int keyLength = 64;
        private string original = "";
        private string cryptedText = "";
        private string[] readFile;
        private string[] list1 = { ".", "+", "-", "=", "/", "\\", "|", "&", "!", "%", "#", "@", "$", "^", "*", "(", ")", 
                                 "?", "<", ">", ":", ";", ",", "\"", "[", "]", "{", "}", "'", "`", "~", "_", " ", "0", "1",
                                  "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                                   "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B",
                                    "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                                     "U", "V", "W", "X", "Y", "Z"
                                 };
        private string[] list2 = new string[95];
        private string[] nums = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private List<string> tempList = new List<string>();


        public ComputeCrypt(string textBox1, string textBox2, bool whichCrypt)
        {
            this.textBox1 = textBox1;
            this.textBox2 = textBox2;
            this.whichCrypt = whichCrypt;

            readFile = File.ReadAllLines(@"Cryptokeys.txt");
        }

        public string crypt()
        {
            original = textBox2;

            //List<int> multiply = new List<int>(); // maybe for more advanced multiplication method

            int mult = 0;
            int a = textBox1.Length;

            for (int i = 0; i < a; i++) // go through serial key
            {
                for (int j = 0; j < list1.Length; j++) // check if in list1
                {
                    if (textBox1.Substring(i).Equals(list1[j].ToString()))
                    {
                        for (int k = 0; k < nums.Length; k++)
                        {
                            if (textBox1.Substring(i).Equals(nums[k].ToString())) // check if a number to multiply
                            {
                                mult += Int32.Parse(nums[k].ToString());
                            }

                        } // end for k

                        cryptInt += j;

                    } // end if statement
                } // end for j
            } // end for i

            if (mult != 0)
            {
                cryptInt *= mult;
            }

            saveInt = cryptInt;

            for (int i = 0; i < list2.Length; i++)
            {
                list2[i] = readFile[cryptInt];
                cryptInt += saveInt;
            }

            // ==========================================================================================================================
            // part that needs to be fixed


            //currently BROKEN for some reason
            if (whichCrypt == false) // encrypt
            {
                for (int i = 0; i < original.Length; i++)
                {
                    for (int j = 0; j < list2.Length; j++)
                    {
                        if (original.Substring(i).Equals(list1[j].ToString()))
                        {
                            cryptedText += list2[j].ToString() + " ";
                        }
                    }
                }

                textBox2 = cryptedText;
            } // end if

            else // decrypt
            {
                for (int i = 32; i < textBox2.Length; i++)
                {
                    for (int j = 0; j < list2.Length; j++)
                    {
                        if (textBox2.Substring(i - 32, i).Equals(list2[j].ToString())) // posibly change to i + 32
                        {
                            cryptedText += list1[j].ToString();
                        }
                    }
                }


                textBox2 = cryptedText;
            } // end else



            return textBox2;
        }

    }
}
