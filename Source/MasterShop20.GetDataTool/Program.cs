using System;
using System.IO;
using MasterShop20.GetDataTool.Infrastructure;
using MasterShop20.Website.Database;
using Newtonsoft.Json;

namespace MasterShop20.GetDataTool
{
    class Program
    {
        /* todo: LIES DAS
         * tool das nur schnell heruntergeschrieben wurde, sehr unsauber und unübersichtlich zudem liegt mir regex nicht
         * zuerst muss das die datenbank existieren -> alos das erstell-xxxx skript im management-studio ausführen; einfach
         * ein abfragefenster öffnen und copy paste Dannach werden die connection-string hier drinnen nicht übereinstimmen
         * also die .dmbl im database-ordner des .website projekts öffnen 
         * (falls es geöffnet werden kann, wenn nicht dann: die .dmbl Datei löschen, rechtsklick auf den Ordner Database, 
         * add new item, Reiter Data und neue Linq to Sql - Datei erstellen, dann den Server-Explorere öffnen, auf connect
         * to database klicken , microsoft sql server auswählen, hacken bei always use this selection rausnehmen, auf
         * refrash klicken, warten, express server auwählen, bei select or enter a database name: die zuvor über das script
         * erstellte datenbank auswählen, auf test connection, klicken, sollte klappen, auf okay, falls sie geöffnet werden 
         * kann, die tabellen rausläschen)
         * dann im server explorer die datenbank auf klicken, auf die tabellen, die tabellen makieren und in das fenster
         * ziehen, oder per doppelklick rein bringen nochmal alles bauen lassen, also oben im solution-explorer rechtslick
         * auf die solution (Solution 'MasterShop20' (2 projects)) und rebuild solution auswählen, warten bis unten links
         * ready angezeigt wird und dann kann das tool ausgeführt werden, also entweder als startup projekt setzen über 
         * rechtsklick auf das projekt und auf set as StartUp Project klicken, dann starten mit F5 oder wieder mit rechtsklick...
         * wenn wir das nun jedes mal machen müssen, sollten wird connection-string nicht per default eintragen lassen,
         * sondern ihn auslagern, oder wir checken die .dmbl datei nicht mehr mit ein
         */
        
        // todo: ich werde das nochmal hübscher schreiben ggf. wies ich jetzt wie ich an eine script über die einträge in
        // der sql-db komme, denn das management studio exportiert irgendwie nur das schema aber nicht die einträge

        //static void Main(string[] args)
        //{
        //    var lists = new Data().GetLists();

        //    var down = new GetHtmlSite();
        //    var creator = new Creator();

        //    foreach (var infoList in lists)
        //    {
        //        var anzahl = infoList.Value.Count;

        //        var counter = 0;
        //        var error = 0;

        //        Console.WriteLine("start for: " + infoList.Key);

        //        foreach (var link in infoList.Value)
        //        {
        //            counter++;
        //            Console.WriteLine("Nr. " + counter + " von " + anzahl);

        //            var content = down.DownloadPage(link);

        //            if (string.IsNullOrEmpty(content))
        //            {
        //                Console.WriteLine("content is empty at link: " + link);
        //                error++;
        //                continue;
        //            }

        //            try
        //            {
        //                var article = creator.CreateArticle(content, infoList.Key);
        //                Console.WriteLine("article created");

        //                if (article == null)
        //                    throw new Exception(link);

        //                UploadToDb(article);
        //                Console.WriteLine("article is in db");
        //            }
        //            catch (Exception)
        //            {
        //                Console.WriteLine("fatal");
        //                error++;
        //            }

        //        }

        //        Console.WriteLine("errors : " + error);
        //    }

        //    Console.ReadKey();
        //}


        //private static void UploadToDb(Artikel artikel)
        //{
        //    var msdc = new MasterShopDataContext();
        //    msdc.Artikels.InsertOnSubmit(artikel);
        //    msdc.SubmitChanges();
        //}

        static void Main(string[] args)
        {
            // todo: Methoden vervollständigen wenn mehr Tabellen / Tabelleneinträge kommen die wichtig sind
            SaveDbEntriesAsJson();


        }

        static readonly string _datadir = AppDomain.CurrentDomain.BaseDirectory + "DbData";

        private static void SaveDbEntriesAsJson()
        {
            var context = new MasterShopDataContext();

            var content = JsonConvert.SerializeObject(context.Artikels);
            var path = Path.Combine(_datadir, "artikel.json");
            File.WriteAllText(path, content);

            content = JsonConvert.SerializeObject(context.Steuersatzs);
            path = Path.Combine(_datadir, "steuersatz.json");
            File.WriteAllText(path, content);

            content = JsonConvert.SerializeObject(context.Untergruppes);
            path = Path.Combine(_datadir, "untergruppe.json");
            File.WriteAllText(path, content);

            content = JsonConvert.SerializeObject(context.Hauptgruppes);
            path = Path.Combine(_datadir, "hauptgruppe.json");
            File.WriteAllText(path, content);
        }

    }
}
