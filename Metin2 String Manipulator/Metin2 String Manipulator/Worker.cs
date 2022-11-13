using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Metin2_String_Manipulator
{
    internal class Worker
    {
        public string Filename { get; set; }
        readonly string itemdesc = "itemdesc";

        public Worker(string filename)
        {
            this.Filename = filename;
            Work(Filename);
        }

        void Work(string filename)
        {
            Console.WriteLine($"Reading the reference {filename}.txt...");
            string[] refereneceFile = File.ReadAllLines($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\references\\{filename}.txt", Encoding.Default);
            Console.WriteLine($"Reading the main {filename}.txt...");
            string[] mainFile = File.ReadAllLines($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{filename}.txt", Encoding.Default);
            // start the merging script
            //for (int i = 0; i < mainFile.Length; i++)
            //{
            //    var tempStr = mainFile[i].Split('\t'); // take the line and split it to 2 halfs
            //    for (int j = 0; j < refereneceFile.Length; j++)
            //    {
            //        var refereneceStr = refereneceFile[j].Split('\t'); // same with the refrence file
            //        if (tempStr[0] == refereneceStr[0]) // found a match in the 1st half of two strings
            //        {
            //            tempStr[1] = refereneceStr[1]; // take the right side of the reference and assign it to right side of the main
            //            mainFile[i] = string.Join("\t", tempStr); // join the 2 halfs in one line sperated by \t again
            //        }
            //    }
            //}
            // Optimized searching
            for (int i = 0; i < mainFile.Length; i++)
            {
                var tempStr = mainFile[i].Split('\t');
                var refStr = refereneceFile.SingleOrDefault(l => l.Split('\t')[0] == tempStr[0]);
                if (refStr != null)
                {
                    tempStr[1] = refStr.Split('\t')[1];
                    if (filename == itemdesc)
                        tempStr[2] = refStr.Split('\t')[2];
                    mainFile[i] = string.Join("\t", tempStr);
                    Console.WriteLine($"{mainFile[i]}");
                }
            }
            // saving all changes to the main file
            File.WriteAllLines($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{filename}.txt", mainFile, Encoding.Default);
            Console.WriteLine("both files is matched now...");
        }
    }
}
