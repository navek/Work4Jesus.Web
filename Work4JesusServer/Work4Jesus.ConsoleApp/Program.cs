using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Work4Jesus.Domain;
using Work4JesusDataTransfert;

namespace Work4Jesus.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "demo.json";
            var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            List<Event> events = new List<Event>();
            Console.WriteLine("Path:" + path);
            for (int i = 0; i < 20; i++)
            {
                var newEvent = new Event()
                {
                    Adress = "8 allée émile roux. 77700 CHAMPS SUR MARNE",
                    Title = "House of disciple" + i,
                    AdressComplement = "Pour y accéder passer devant la maison de JUDE" + i,
                    ChurchLink = "http://eglise.champs-sur-marne.com",
                    Description = "Cette maison sert l'éternel ^^" + i,
                    KeyWord = "Jésus;Maison de Dieu;",
                    StartOfEvent = new DateTime(2016, 12, 24),
                    EndOfEvent = new DateTime(2016, 12, 30),
                    CreatedOn = new DateTime(2016, 12, 5),
                    ModifiedOn = DateTime.Now,
                    Price = 0,
                    YoutubeLink = "http://youtube.com",
                    Id = i+ 1
                };
                events.Add(newEvent);
            }

            using (var streamWriter = new StreamWriter(path))
            {
                var json = JsonConvert.SerializeObject(events);
                streamWriter.Write(json);
            }
            //var file = File.CreateText()
            Console.ReadLine();
        }

        private static  void WriteData(string filepath)
        {
            using (var stream = File.Create(filepath))
            {
            }
        }
    }
}
