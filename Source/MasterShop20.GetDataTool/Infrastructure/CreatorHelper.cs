using MasterShop20.Website.Database;

namespace MasterShop20.GetDataTool.Infrastructure
{
    public class CreatorHelper
    {
        public static Artikel GetMainArtikel(string listtype, out string beschreibung)
        {
            beschreibung = string.Empty;
            int idhaupt, idunter;
            string[] dataarray;

            switch (listtype)
            {
                case "jacken":
                    dataarray = Data.GetJackenInfo();
                    int.TryParse(dataarray[0], out idhaupt);
                    int.TryParse(dataarray[1], out idunter);
                    beschreibung = dataarray[2];
                    break;

                case "taschen":
                    dataarray = Data.GetTaschenInfo();
                    int.TryParse(dataarray[0], out idhaupt);
                    int.TryParse(dataarray[1], out idunter);
                    beschreibung = dataarray[2];
                    break;

                case "nintendo":
                    dataarray = Data.GetNintendoInfo();
                    int.TryParse(dataarray[0], out idhaupt);
                    int.TryParse(dataarray[1], out idunter);
                    beschreibung = dataarray[2];
                    break;

                case "trainingsanzuege":
                    dataarray = Data.GetTrainingsanzuInfo();
                    int.TryParse(dataarray[0], out idhaupt);
                    int.TryParse(dataarray[1], out idunter);
                    beschreibung = dataarray[2];
                    break;

                default:
                    return null;
            }

            return new Artikel { IdSteuersatz = 1, IdHauptgruppe = idhaupt, IdUntergruppe = idunter };
        }



    }
}
