using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirvinClientGenerator
{
    internal class Program
    {
        struct ColourKey
        {
            public ConsoleColor color;
            public char key;

            public ColourKey(ConsoleColor Color, char Key)
            {
                this.color = Color;
                this.key = Key;
            }
        }

        static void ColorWrite(string rawtext, bool endline)
        {
            //all avaliable colours, for more just make the array bigger
            ColourKey[] Pallete = new ColourKey[6];
            Pallete[0] = new ColourKey(ConsoleColor.Red, '~');
            Pallete[1] = new ColourKey(ConsoleColor.Green, '`');
            Pallete[2] = new ColourKey(ConsoleColor.Blue, '^');
            Pallete[3] = new ColourKey(ConsoleColor.Yellow, '*');
            Pallete[4] = new ColourKey(ConsoleColor.DarkMagenta, '_'); //ConsoleColor does not contain purple
            Pallete[5] = new ColourKey(ConsoleColor.White, '$');

            foreach (char c in rawtext)
            {
                bool CanWrite = true;
                foreach (ColourKey ck in Pallete)
                {
                    if (c == ck.key)
                    {
                        Console.ForegroundColor = ck.color;
                        CanWrite = false;
                    }
                }

                if (CanWrite)
                {
                    Console.Write(c);
                }

            }

            Console.ResetColor();

            // true function works like writeline(), false works like write()
            if (endline)
            {
                Console.WriteLine();
            }

        }

        public static void ControllerGenerate(Object cscpath, Object bip)
        {
            // TODO: Make compiling process
        }
        public static void ReceiverGenerate(Object cscpath, Object bip)
        {
            // TODO: Make compiling process
        }

        public static bool StartGeneratingCon(Object cscpath, Object bip)
        {
            try
            {
                ControllerGenerate(cscpath, bip);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool StartGeneratingRec(Object cscpath, Object bip)
        {
            try
            {
                ReceiverGenerate(cscpath, bip);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        async static void Main(string[] args)
        {
            Console.Title = "Birvin Client Generator (Alpha 0.1.0, Build No. 1)";
            Console.WriteLine("______ ___________ _   _ _____ _   _ \r\n| ___ \\_   _| ___ \\ | | |_   _| \\ | |\r\n| |_/ / | | | |_/ / | | | | | |  \\| |\r\n| ___ \\ | | |    /| | | | | | | . ` |\r\n| |_/ /_| |_| |\\ \\\\ \\_/ /_| |_| |\\  |\r\n\\____/ \\___/\\_| \\_|\\___/ \\___/\\_| \\_/\r\n                                     \r\n                                     ", true);
            Console.WriteLine("Please enter your BIRVIN Server IP Address");
            Object bip = Console.ReadLine();
            Console.WriteLine("Please state the path to a CSC file for preferrably .NET Framework 4.7.2");
            Object cscpath = Console.ReadLine();
            Console.WriteLine("Generating controller");
            ControllerGenerate(cscpath, bip);
            ColorWrite("`[SUCCESS]$ Finished - ControllerGenerate", true);
            Console.WriteLine("Generating receiver");
            ReceiverGenerate(cscpath, bip);
            ColorWrite("`[SUCCESS]$ Finished - ReceiverGenerate", true);
            ColorWrite("^[INFO]$ Use the planter generator to make the infector", true);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


        }
    }
}
