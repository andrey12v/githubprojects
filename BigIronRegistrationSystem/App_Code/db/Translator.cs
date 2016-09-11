using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace db
{
    public class Translator
    {
        public Translator()
        {
        }

        public static string DirectTranslation(string inpPhrase)
        {

            string resultPhrase = "";
            char[] arrPhrase = inpPhrase.ToLowerInvariant().ToCharArray();

            for (int i = 0; i < arrPhrase.Length; i++)
            {
                switch (Convert.ToString(arrPhrase[i]))
                {
                    case "a":
                        return inpPhrase;
                    case "b":
                        return inpPhrase;
                    case "c":
                        return inpPhrase;
                    case "d":
                        return inpPhrase;
                    case "e":
                        return inpPhrase;
                    case "f":
                        return inpPhrase;
                    case "g":
                        return inpPhrase;
                    case "h":
                        return inpPhrase;
                    case "i":
                        return inpPhrase;
                    case "j":
                        return inpPhrase;
                    case "k":
                        return inpPhrase;
                    case "l":
                        return inpPhrase;
                    case "m":
                        return inpPhrase;
                    case "n":
                        return inpPhrase;
                    case "o":
                        return inpPhrase;
                    case "p":
                        return inpPhrase;
                    case "q":
                        return inpPhrase;
                    case "r":
                        return inpPhrase;
                    case "s":
                        return inpPhrase;
                    case "t":
                        return inpPhrase;
                    case "u":
                        return inpPhrase;
                    case "v":
                        return inpPhrase;
                    case "w":
                        return inpPhrase;
                    case "x":
                        return inpPhrase;
                    case "y":
                        return inpPhrase;
                    case "z":
                        return inpPhrase;
                }
            }



            //return Convert.ToString(Convert.ToInt32(arrPhrase[0]));

            for (int i = 0; i < arrPhrase.Length; i++)
            {
                switch (Convert.ToInt32(arrPhrase[i]))
                {
                    case 1072:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "A";
                        }
                        else
                        {
                            resultPhrase += "a";
                        }
                        break;
                    case 1073:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "B";
                        }
                        else
                        {
                            resultPhrase += "b";
                        }
                        break;
                    case 1074:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "V";
                        }
                        else
                        {
                            resultPhrase += "v";
                        }
                        break;
                    case 1075:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "G";
                        }
                        else
                        {
                            resultPhrase += "g";
                        }
                        break;
                    case 1076:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "D";
                        }
                        else
                        {
                            resultPhrase += "d";
                        }
                        break;
                    case 1077:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "E";
                        }
                        else
                        {
                            resultPhrase += "e";
                        }
                        break;
                    case 1105:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Yo";
                        }
                        else
                        {
                            resultPhrase += "yo";
                        }
                        break;
                    case 1078:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Sh";
                        }
                        else
                        {
                            resultPhrase += "sh";
                        }
                        break;
                    case 1079:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Z";
                        }
                        else
                        {
                            resultPhrase += "z";
                        }
                        break;
                    case 1080:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "I";
                        }
                        else
                        {
                            resultPhrase += "i";
                        }
                        break;
                    case 1081:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Y";
                        }
                        else
                        {
                            resultPhrase += "y";
                        }
                        break;
                    case 1082:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "K";
                        }
                        else
                        {
                            resultPhrase += "k";
                        }
                        break;
                    case 1083:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "L";
                        }
                        else
                        {
                            resultPhrase += "l";
                        }
                        break;
                    case 1084:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "M";
                        }
                        else
                        {
                            resultPhrase += "m";
                        }
                        break;
                    case 1085:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "N";
                        }
                        else
                        {
                            resultPhrase += "n";
                        }
                        break;
                    case 1086:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "O";
                        }
                        else
                        {
                            resultPhrase += "o";
                        }
                        break;
                    case 1087:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "P";
                        }
                        else
                        {
                            resultPhrase += "p";
                        }
                        break;
                    case 1088:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "R";
                        }
                        else
                        {
                            resultPhrase += "r";
                        }
                        break;
                    case 1089:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "S";
                        }
                        else
                        {
                            resultPhrase += "s";
                        }
                        break;
                    case 1090:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "T";
                        }
                        else
                        {
                            resultPhrase += "t";
                        }
                        break;
                    case 1091:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "U";
                        }
                        else
                        {
                            resultPhrase += "u";
                        }
                        break;
                    case 1092:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Ph";
                        }
                        else
                        {
                            resultPhrase += "ph";
                        }
                        break;
                    case 1093:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "H";
                        }
                        else
                        {
                            resultPhrase += "h";
                        }
                        break;
                    case 1094:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "C";
                        }
                        else
                        {
                            resultPhrase += "c";
                        }
                        break;
                    case 1095:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Ch";
                        }
                        else
                        {
                            resultPhrase += "ch";
                        }
                        break;
                    case 1096:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Sh";
                        }
                        else
                        {
                            resultPhrase += "sh";
                        }
                        break;
                    case 1097:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Sh";
                        }
                        else
                        {
                            resultPhrase += "sh";
                        }
                        break;
                    case 1099:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "E";
                        }
                        else
                        {
                            resultPhrase += "e";
                        }
                        break;
                    case 1101:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "A";
                        }
                        else
                        {
                            resultPhrase += "a";
                        }
                        break;
                    case 1102:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "U";
                        }
                        else
                        {
                            resultPhrase += "u";
                        }
                        break;
                    case 1103:
                        if ((i == 0) || (arrPhrase[i - 1] == ' ') || (arrPhrase[i - 1] == '.') || (arrPhrase[i - 1] == '"'))
                        {
                            resultPhrase += "Ya";
                        }
                        else
                        {
                            resultPhrase += "ya";
                        }
                        break;
                    case 1100:
                        resultPhrase += "";
                        break;
                    case 1098:
                        resultPhrase += "";
                        break;
                    case 47:
                        resultPhrase += "/";
                        break;
                    case 171:
                        resultPhrase += " \" ";
                        break;
                    case 187:
                        resultPhrase += " \" ";
                        break;
                    case 34:
                        resultPhrase += " \" ";
                        break;
                    case 44:
                        resultPhrase += " , ";
                        break;
                    case 45:
                        resultPhrase += " - ";
                        break;
                    case 46:
                        resultPhrase += " ";
                        break;
                    default:
                        //resultPhrase += " ";
                        resultPhrase += arrPhrase[i];
                        break;
                }
            }

            return resultPhrase;

        }

        public static string DictionaryTranslation(string inpPhrase)
        {
            string resultPhrase = "";
            inpPhrase = DirectTranslation(inpPhrase);
            //inpPhrase = inpPhrase.ToLowerInvariant();

            if (inpPhrase == "Nachalnik Otdela Avtomatizacii Biznes - processov") 
            {
                return resultPhrase = "Director of the Department 'Automation of Business Processes'";
            }


            int counter = 1;
            char[] arrPhrase = inpPhrase.ToCharArray();
            for (int i = 0; i < arrPhrase.Length; i++)
            {
                if (arrPhrase[i] == ' ')
                {
                    counter++;
                }
            }

            string[] arrPhraseWords = new string[counter];
            string strTemp = inpPhrase;
            arrPhraseWords = strTemp.Split(' ');
            for (int i = 0; i < counter; i++)
            {
                switch (Convert.ToString(arrPhraseWords[i]))
                {
                    case "Ph/h":
                        resultPhrase += "Agricultural Farm ";
                        break;
                    case "Pticevodcheskoe":
                        resultPhrase += "Poultry ";
                        break;
                    case "Ph/hozyaystvo":
                        resultPhrase += "Agricultural Farm ";
                        break;
                    case "Uralskaya":
                        resultPhrase += "Ural ";
                        break;
                    case "Selhoz":
                        resultPhrase += "Agricultural ";
                        break;
                    case "Opetnaya":
                        resultPhrase += "Experimental ";
                        break;
                    case "Stanciya":
                        resultPhrase += "Station ";
                        break;
                    case "Phermerskoe":
                        resultPhrase += "Agricultural ";
                        break;
                    case "Hozyaystvo":
                        resultPhrase += "Farm ";
                        break;
                    case "Menedsher":
                        resultPhrase += "Manager ";
                        break;
                    case "Po":
                        resultPhrase += "of ";
                        break;
                    case "Proizvodstvu":
                        resultPhrase += "Production ";
                        break;
                    case "Mehanik":
                        resultPhrase += "Mechanic ";
                        break;
                    case "Razvitiya":
                        resultPhrase += "Development ";
                        break;
                    case "I":
                        resultPhrase += "and ";
                        break;
                    case "Torgovli":
                        resultPhrase += "Trade ";
                        break;
                    case "Prodasham":
                        resultPhrase += "Trade ";
                        break;
                    case "Stolica":
                        resultPhrase += "Capital ";
                        break;
                    case "Kommercheskiy":
                        resultPhrase += "Commercial ";
                        break;
                    case "Atash":
                        resultPhrase += "Floor ";
                        break;
                    case "G":
                        resultPhrase += "City ";
                        break;
                    case "Ul":
                        resultPhrase += "Street ";
                        break;
                    case "R":
                        resultPhrase += "Republic ";
                        break;
                    case "Zamestitel":
                        resultPhrase += "Deputy ";
                        break;
                    case "Direktora":
                        resultPhrase += "Director";
                        break;
                    case "Ooo":
                        resultPhrase += "Public Company ";
                        break;
                    case "Phinansovey":
                        resultPhrase += "Financial ";
                        break;
                    case "D":
                        resultPhrase += " ";
                        break;
                    default:
                        resultPhrase += arrPhraseWords[i] + " ";
                        break;
                }


            }

            return resultPhrase;

        }
 
    
    }

}