﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CryptoBit
{
    public partial class Form1 : Form
    {
        CheckBox lastChecked;
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

        public Form1()
        {
            InitializeComponent();
            readFile = File.ReadAllLines(@"Cryptokeys.txt");
            lastChecked = checkBox3;
        }

        // Generate serial key
        private void button1_Click(object sender, EventArgs e)
        {
            SerialKey sk = new SerialKey(keyLength);
            textBox1.Text = sk.generateKey();
        }

        // Encrypt
        private void button2_Click(object sender, EventArgs e)
        {
            ComputeCrypt cc = new ComputeCrypt(textBox1.Text, textBox2.Text, false);
            textBox2.Text = cc.crypt();
        }

        // Decrypt
        private void button3_Click(object sender, EventArgs e)
        {
            ComputeCrypt cc = new ComputeCrypt(textBox1.Text, textBox2.Text, true);
            textBox2.Text = cc.crypt();
        }

        // 8-bit
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            keyLength = 8;
            checkState(lastChecked, checkBox6);
            lastChecked = checkBox6;
        }

        // 16-bit
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            keyLength = 16;
            checkState(lastChecked, checkBox1);
            lastChecked = checkBox1;
        }

        // 32-bit
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            keyLength = 32;
            checkState(lastChecked, checkBox2);
            lastChecked = checkBox2;
        }

        // 64-bit
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            keyLength = 64;
            checkState(lastChecked, checkBox3);
            lastChecked = checkBox3;
        }

        // 128-bit
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            keyLength = 128;
            checkState(lastChecked, checkBox4);
            lastChecked = checkBox4;
        }

        // 256-bit
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            keyLength = 256;
            checkState(lastChecked, checkBox5);
            lastChecked = checkBox5;
        }

        // controls checkboxes checked state
        private void checkState(CheckBox lastChecked, object sender) // not sure what to do with object sender
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        
    }
}
