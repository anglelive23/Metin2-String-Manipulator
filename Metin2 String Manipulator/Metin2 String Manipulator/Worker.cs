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
