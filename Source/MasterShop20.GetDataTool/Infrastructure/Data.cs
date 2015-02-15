using System.Collections.Generic;
using System.Linq;

namespace MasterShop20.GetDataTool.Infrastructure
{
    public class Data
    {

        public Dictionary<string, List<string>> GetLists()
        {
            var result = new Dictionary<string, List<string>>();

            result.Add("jacken", GetJacken());
            result.Add("nintendo", GetNintendo());
            result.Add("taschen", GetTaschen());
            result.Add("trainingsanzuege", GetTrainingsanzuege());

            return result;
        }


        #region info about the data

        public static string[] GetTaschenInfo()
        {
            var idhaupt = "1";
            var idunter = "2";
            var beschreibung = "Sporttasche, adidas Performance. Aus Polyester. RV-Hauptfach mit 3 großen Steckfächern, ein großes RV-Seitenfach, an den Außenseiten: 1 Steckfach und 1 RV-Fach, Trageriemen, verstellbare Umhängeriemen, Gr. 52/29/36 cm. Vol. ca. 44l.";
            
            return new[] {idhaupt, idunter, beschreibung};
        }

        public static string[] GetJackenInfo()
        {
            var idhaupt = "1";
            var idunter = "1";
            var beschreibung =
                "Wir alle hätten gerne eine, die uns sicher durch den Alltag geleitet, so wie diese: Die warm wattierte Funktions-Jacke von Polarino wird Outdoor-Fans begeistern. Sie ist atmungsaktiv und windabweisend. Das wasserdichte Obermaterial hält einer Wassersäule von 3000 mm stand. Abnehmbare Kapuze mit Windschutz. Mit hochschließbarem Kragen, Logo-Patch am linken Ärmel, Eingrifftaschen sowie Kordelzug mit Stopper in Kapuze und Saum. Verschweißte Nähte. Die Allwetter-Jacke von Polarino ist ein ausgezeichneter Begleiter für Trekking- und Wander-Touren!";

            return new[] { idhaupt, idunter, beschreibung };
        }

        public static string[] GetTrainingsanzuInfo()
        {
            var idhaupt = "1";
            var idunter = "2";
            var beschreibung =
                "Voller Power steckt der modern designte Trainings-Anzug von Kappa. Der Logo-Print auf einer Schulter, die markanten Raglan-Ärmel und optisch hervorstechende Flatlock-Nähte geben der Jacke eine sportive Bestnote. Stehkragen, Reißverschluss, Eingrifftaschen und elastische Bündchen sorgen für einen lässigen Aufritt. Die Hose liefert einen dezent gehaltenen Kontrast, ist mit einer kleinen Logo-Stickerei aufgepeppt, wartet mit tiefen Eingrifftaschen auf und sitzt mit den elastischen Bündchen perfekt. Beim Hobby-Kick am Sonntagmorgen, bei Fitness und Laufen oder relaxt im Urlaub ist der Trainings-Anzug von Kappa einfach klasse.";

            return new string[] { idhaupt, idunter, beschreibung };
        }

        public static string[] GetNintendoInfo()
        {
            var idhaupt = "3";
            var idunter = "5";
            var beschreibung =
                " Der grafische Unterschied ist deutlich erkennbar, wenn auch kein Quantensprung. Ich habe die bessere Leistung der PS4 z.B. beim Fliegen ganz klar bemerkt, da man auch von ziemlich weit oben noch die befahrenen Straßen erkennt, während bei der PS3 keine Autos mehr erkennbar waren. Auch merkt man die höhere Leistung der PS4 daran, dass wesentlich mehr Autos gleichzeitig auf dem Screen sind und mehr Fußgänger unterwegs sind. Mir persönlich fällt es dadurch schwerer bei Missionen durch den dichten Verkehr zu kommen, was mich aber nicht stört, da es in einer riesigen Stadt auch so sein sollte...";

            return new string[] { idhaupt, idunter, beschreibung };
        }

        #endregion


        #region http - links

        private static List<string> GetTaschen()
        {
            var list = new List<string>()
            {
                "https://www.otto.de/p/shopper-gym-shopper-puma-409346505/#variationId=409346834",
                "https://www.otto.de/p/shopper-gym-shopper-puma-409346505/#variationId=409347063",
                "https://www.otto.de/p/shopper-gym-shopper-puma-409346505/#variationId=409346834",
                "https://www.otto.de/p/sporttasche-sole-grip-bag-puma-432653526/#variationId=375526187",
                "https://www.otto.de/p/sporttasche-sole-grip-bag-puma-432653526/#variationId=375517136",
                "https://www.otto.de/p/sporttasche-adidas-performance-up-graded-imported-zipper-in-2-groessen-lieferbar-406455011/#variationId=406455016",
                "https://www.otto.de/p/sporttasche-adidas-performance-up-graded-imported-zipper-in-2-groessen-lieferbar-406455011/#variationId=406455015",
                "https://www.otto.de/p/sporttasche-medium-bag-puma-437282720/#variationId=437284280",
                "https://www.otto.de/p/sporttasche-medium-bag-puma-437282720/#variationId=437284280",
                "https://www.otto.de/p/sporttasche-adidas-performance-vol-ca-44l-442308856/#variationId=442344614",
                "https://www.otto.de/p/puma-sporttbeutel-mit-schuhfach-437306710/#variationId=437306851",
                "https://www.otto.de/p/sporttasche-adidas-performance-mit-separatem-taeschchen-zum-abnehmen-442780383/#variationId=442783361",
                "https://www.otto.de/p/tasche-fundamentals-shopper-puma-437306111/#variationId=437307490",
                "https://www.otto.de/p/sport-tasche-puma-437285631/#variationId=437286229",
                "https://www.otto.de/p/sporttasche-adidas-performance-442789814/#variationId=442790612",
                "https://www.otto.de/p/umhaengetasche-boxing-printing-adidas-performance-455802903/#variationId=455803403",
                "https://www.otto.de/p/sporttasche-teambag-m-adidas-performance-411947441/#variationId=411965112",
                "https://www.otto.de/p/adidas-performance-sporttasche-mit-schuhfach-442789793/#variationId=442790834",
                "https://www.otto.de/p/sporttasche-adidas-originals-442223642/#variationId=442258757",
                "https://www.otto.de/p/rollenreisetasche-puma-437311193/#variationId=437314140",
                "https://www.otto.de/p/sporttasche-trolley-bag-adidas-performance-455804278/#variationId=455804896",
                "https://www.otto.de/p/sporttasche-mit-rollen-team-bag-xl-with-wheels-adidas-performance-455804245/#variationId=455804328",
                "https://www.otto.de/p/sporttasche-puma-437285081/#variationId=437287890",
                "https://www.otto.de/p/shiny-pu-sporttasche-taekwondo-adidas-performance-402362315/#variationId=402366482",
                "https://www.otto.de/p/adidas-performance-shopper-messenger-bag-442789824/#variationId=442792572",
                "https://www.otto.de/p/sporttasche-climacool-teambag-m-adidas-performance-411862498/#variationId=411962965"
            };

            var s = list.Distinct();
            return s.ToList();
        }

        private static List<string> GetTrainingsanzuege()
        {
            var list = new List<string>()
            {
                "https://www.otto.de/p/adidas-performance-trainingsanzug-430243064/#variationId=430244535",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432418388",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432418396",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432416611",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432416602",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432416585",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432418392",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432416597",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432418378",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432416607",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-432415434/#variationId=432418368",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-430243064/#variationId=430244535",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-430243064/#variationId=430244535",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-430243064/#variationId=430244381",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-430243064/#variationId=430244539",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-430243064/#variationId=430244383",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-430243064/#variationId=430244537",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308194",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308541",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308188",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308551",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308190",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308183",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308192",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-415305700/#variationId=415308538",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411239039",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411241424",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411253151",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411253127",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411241447",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411253139",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411253154",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411241452",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411241444",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411241435",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411253135",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411253143",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411253146",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-411203788/#variationId=411239039",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864605",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864626",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864629",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864605",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864635",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864637",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864631",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-429864521/#variationId=429864633",
                "https://www.otto.de/p/adidas-performance-trainingsanzug-338290238/#variationId=338899767"
            };

            var s = list.Distinct();

            return s.ToList();
        }

        private static List<string> GetJacken()
        {
            // jacken
            var list = new List<string>()
            {
                "https://www.otto.de/p/polarino-funktionsjacke-411768239/#variationId=411768018",
                "https://www.otto.de/p/northland-3-in-1-funktionsjacke-392689594/#variationId=392685305",
                "https://www.otto.de/p/northland-3-in-1-funktionsjacke-392689594/#variationId=392685305",
                "https://www.otto.de/p/khujo-outdoorjacke-cosma-441660363/#variationId=441662262",
                "https://www.otto.de/p/khujo-outdoorjacke-cosma-441660363/#variationId=441662262",
                "https://www.otto.de/p/helly-hansen-amsteg-3-in-1-jacke-213526350/#variationId=213534038",
                "https://www.otto.de/p/ock-damen-outdoor-5-in-1-funktionsjacke-100864402/#variationId=209908956",
                "https://www.otto.de/p/polarino-softshelljacke-436004848/#variationId=436006372",
                "https://www.otto.de/p/icepeak-caia-skijacke-415611269/#variationId=415612573",
                "https://www.otto.de/p/icepeak-cadee-softshelljacke-418430677/#variationId=418431907",
                "https://www.otto.de/p/kangaroos-sweatjacke-347733085/#variationId=347739221",
                "https://www.otto.de/p/helly-hansen-marpole-3-in-1-funktionsjacke-420045968/#variationId=420060896",
                "https://www.otto.de/p/adidas-performance-primaloftjacke-348694814/#variationId=348684658",
                "https://www.otto.de/p/the-north-face-ontario-softshelljacke-411768331/#variationId=411777441",
                "https://www.otto.de/p/ajc-steppjacke-kontrastfarbe-365329240/#variationId=365329967",
                "https://www.otto.de/p/polarino-funktionsjacke-411739037/#variationId=411739303",
                "https://www.otto.de/p/the-north-face-3-in-1-funktionsjacke-349902571/#variationId=349908875",
                "https://www.otto.de/p/helly-hansen-marpole-3-in-1-funktionsjacke-420060702/#variationId=420065021",
                "https://www.otto.de/p/bruno-banani-winterjacke-elliot-361524162/#variationId=361525373&t=%7B%22listposition%22%3A+5,+%22san_ProductLinkType%22%3A+%22size%22%7D",
                "https://www.otto.de/p/rhode-island-leichtdaunenjacke-420927670/#variationId=420931685&t=%7B%22san_ListPosition%22%3A6,+%22san_ProductLinkType%22%3A%22image%22%7D",
                "https://www.otto.de/p/killtec-skijacke-413026263/#variationId=413058842&t=%7B%22san_ListPosition%22%3A7,+%22san_ProductLinkType%22%3A%22image%22%7D",
                "https://www.otto.de/p/grey-connection-funktionsjacke-372229512/#variationId=372229666&t=%7B%22san_ListPosition%22%3A8,+%22san_ProductLinkType%22%3A%22image%22%7D",
                "https://www.otto.de/p/ziener-skijacke-425810071/#variationId=425812766",
                "https://www.otto.de/p/the-north-face-softshelljacke-411768321/#variationId=411800649",
                "https://www.otto.de/p/adidas-performance-trainingsjacke-378240129/#variationId=378241292",
                "https://www.otto.de/p/ock-funktionsjacke-280530416/#variationId=280530388",
                "https://www.otto.de/p/adidas-performance-funktions-kapuzenjacke-348771225/#variationId=348770417",
                "https://www.otto.de/p/puma-kapuzensweatjacke-210530530/#variationId=210531785",
                "https://www.otto.de/p/puma-kapuzensweatjacke-210530530/#variationId=210531785",
                "https://www.otto.de/p/lonsdale-winterjacke-359462691/#variationId=359464350",
                "https://www.otto.de/p/polarino-softshelljacke-436004850/#variationId=436010439",
                "https://www.otto.de/p/the-north-face-mcmurdo-parka-parka-411817089/#variationId=209380896",
            };
            return list;
        }

        private static List<string> GetNintendo()
        {
            var list = new List<string>()
            {
                "https://www.otto.de/p/nintendo-3ds-xl-plus-animal-crossing-vorinstalliert-konsolen-set-mit-3-jahren-garantie-458433955/#variationId=458437282-M36",
                "https://www.otto.de/p/wii-u-premium-pack-plus-wii-u-mario-kart-vorinstalliert-konsolen-set-mit-3-jahren-garantie-456582962/#variationId=456583857-M36",
                "https://www.otto.de/p/the-legend-of-zelda-majoras-mask-3d-nintendo-3ds-471142302/#variationId=471182072",
                "https://www.otto.de/p/new-nintendo-3ds-xl-metallic-schwarz-konsolen-set-mit-3-jahren-garantie-471142227/#variationId=471176474-M36",
                "https://www.otto.de/p/nintendo-3ds-xl-plus-mario-kart-7-vorinstalliert-konsolen-set-mit-3-jahren-garantie-450553766/#variationId=450554370-M36",
                "https://www.otto.de/p/nintendo-pro-controller-kabellos-schwarz-345714443/#variationId=345715246",
                "https://www.otto.de/p/nintendo-3ds-spiel-zelda-ocarina-of-time-237424973/#variationId=237428444",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-sonic-474004200/#variationId=474004201",
                "https://www.otto.de/p/nintendo-wii-u-spiel-game-wario-472370597/#variationId=472370598",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-shulk-474492923/#variationId=474492924",
                "https://www.otto.de/p/activision-nintendo-3ds-spiel-skylanders-trap-team-starter-pack-472989039/#variationId=472989040",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-bowser-474493003/#variationId=474493004",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-pit-474004191/#variationId=474004192",
                "https://www.otto.de/p/activision-wii-spiel-skylanders-trap-team-starter-pack-472370866/#variationId=472370867",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-sheik-474492855/#variationId=474492856",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-meta-knight-474492827/#variationId=474492828",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-koenig-dedede-474492963/#variationId=474492965",
                "https://www.otto.de/p/nintendo-wii-u-spiel-amiibo-smash-ike-474492881/#variationId=474492882",
                "https://www.otto.de/p/activision-wii-u-spiel-skylanders-trap-team-starter-pack-472989107/#variationId=472989108"
            };

            var s = list.Distinct();

            return s.ToList();
        }

        #endregion
    }
}
