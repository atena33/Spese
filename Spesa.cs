using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spese
{
    public class Spesa
    {
        

        public  string Data { get; set; }
        public  string Categoria { get; set; }
        public  string Descrizione { get; set; }
        public  int Importo { get; set; }

        public Spesa(string data, string categoria, string descrizione, int importo)
        {
            Data = data;
            Categoria = categoria;
            Descrizione = descrizione;
            Importo = importo;
        }
        public Spesa()
        {

        }
        
        public  List<Spesa> OpenFile(string spese)
        {
            List<Spesa> a = new List<Spesa>();
            try
            {

                StreamReader reader = File.OpenText(Path.Combine(@"C:\Users\anna.mura\Desktop\Esercitazioni\Spese\files", spese));

                var data = reader.ReadLine();
                var categoria = reader.ReadLine();
                var descrizione = reader.ReadLine();
                var importo = int.Parse(reader.ReadLine());
                
                Spesa s = new Spesa(data, categoria, descrizione, importo);
                a.Add(s);
             }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Errore: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Errore Generico: {ex.Message}");
            }

            return a;
        }
    }
}
