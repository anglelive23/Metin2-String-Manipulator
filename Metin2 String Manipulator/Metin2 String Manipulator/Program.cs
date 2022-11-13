using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin2_String_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the file to work on.");
            Console.WriteLine("1-locale_game.txt\n2-locale_interface.txt\n3-itemdesc.txt\n4-item_names.txt\n5-mob_names.txt");
            var userInput = int.Parse(Console.ReadLine());
            Worker worker;
            switch (userInput)
            {
                case 1:
                    worker = new Worker("locale_game");
                    break;
                case 2:
                    worker = new Worker("locale_interface");
                    break;
                case 3:
                    worker = new Worker("itemdesc");
                    break;
                case 4:
                    worker = new Worker("item_names");
                    break;
                case 5:
                    worker = new Worker("mob_names");
                    break;
                default:
                    Console.WriteLine("Wrong Entry.");
                    break;
            }
            Console.ReadLine();
        }
    }
}
