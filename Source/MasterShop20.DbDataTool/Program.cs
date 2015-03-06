using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MasterShop20.Website.Database;
using Newtonsoft.Json;

namespace MasterShop20.DbDataTool
{
    class Program
    {
        static readonly string _datadir = AppDomain.CurrentDomain.BaseDirectory + "DbData";

        private static void SaveDbEntriesAsJson()
        {
            var context = new MasterShopDataContext();

            if (!Directory.Exists(_datadir))
                Directory.CreateDirectory(_datadir);

            var content = JsonConvert.SerializeObject(context.Artikels.ToList());
            var path = Path.Combine(_datadir, "artikel.json");
            File.WriteAllText(path, content);

            content = JsonConvert.SerializeObject(context.Steuersatzs.ToList());
            path = Path.Combine(_datadir, "steuersatz.json");
            File.WriteAllText(path, content);

            content = JsonConvert.SerializeObject(context.Untergruppes.ToList());
            path = Path.Combine(_datadir, "untergruppe.json");
            File.WriteAllText(path, content);

            content = JsonConvert.SerializeObject(context.Hauptgruppes.ToList());
            path = Path.Combine(_datadir, "hauptgruppe.json");
            File.WriteAllText(path, content);
        }

        private static void LoadDbEntriesInDb()
        {
            var context = new MasterShopDataContext();

            var content = File.ReadAllText(Path.Combine(_datadir, "artikel.json"));
            var list = JsonConvert.DeserializeObject<List<Artikel>>(content);
            context.Artikels.InsertAllOnSubmit(list);

            var content2 = File.ReadAllText(Path.Combine(_datadir, "steuersatz.json"));
            var list2 = JsonConvert.DeserializeObject<List<Steuersatz>>(content2);
            context.Steuersatzs.InsertAllOnSubmit(list2);

            var content3 = File.ReadAllText(Path.Combine(_datadir, "untergruppe.json"));
            var list3 = JsonConvert.DeserializeObject<List<Untergruppe>>(content3);
            context.Untergruppes.InsertAllOnSubmit(list3);

            var content4 = File.ReadAllText(Path.Combine(_datadir, "hauptgruppe.json"));
            var list4 = JsonConvert.DeserializeObject<List<Hauptgruppe>>(content4);
            context.Hauptgruppes.InsertAllOnSubmit(list4);


            context.SubmitChanges();
        }


        static void Main(string[] args)
        {
            // todo: Methoden vervollständigen wenn mehr Tabellen / Tabelleneinträge kommen die wichtig sind

             //SaveDbEntriesAsJson();

             try
             {
                 if (!Directory.Exists(_datadir) || !Directory.EnumerateFiles(_datadir, "*.json").Any())
                     Console.WriteLine("Du musst das Projekt erst einmal bauen!" + Environment.NewLine +
                         Environment.NewLine + "Bauen + nochmal starten");
                 else
                     LoadDbEntriesInDb();
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }

            Console.WriteLine("Mit irgendeiner Taste beenden");
            Console.ReadKey();
        }


    }
}
