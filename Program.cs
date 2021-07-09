using System;
using System.Collections.Generic;
using System.IO;

namespace Spese
{
    class Program
    {
        static void Main(string[] args)
        {

         
            var manager = new ManagerHandler();
            var opManager = new OperationalManagerHandler();
            var ceo = new CEOHandler();

            manager.SetNext(opManager).SetNext(ceo);

            Spesa s = new Spesa();

            var requests = s.OpenFile("Spese.txt");
            foreach (var request in requests)
            {
                
                var result = manager.Handle(request.Importo);

                if (result != null)
                    Console.WriteLine($"\t{result}");
                else
                    Console.WriteLine("\t Importo troppo alto");
            }
            
        }

       

        private static void WhatchFiles()
        {
            FileSystemWatcher fsw = new();

            fsw.Path = @"C:\Users\anna.mura\Desktop\Esercitazioni\Spese\files";
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastWrite
               | NotifyFilters.LastAccess
               | NotifyFilters.FileName
               | NotifyFilters.DirectoryName;
            fsw.EnableRaisingEvents = true;

            fsw.Created += Fsw_Created;
            Console.WriteLine("Premi 'a' per uscire");
            while (Console.Read() != 'a') ;
        }

        private static void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            List<string> a = new List<string>();
           

            StreamReader reader = File.OpenText(e.FullPath);
            string line;

            while ((line = reader.ReadLine()) != null)
                a.Add(line);

          
        }
    }
}
