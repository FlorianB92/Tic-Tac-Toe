using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static bool spiel_aktiv = true;
        static string spieler_aktuell = "X";
        static char[] feld = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static string spielzug;
        static int zug;
        static char gewonnen = 'a';
        static char unentschieden = 'b';

        static void Main(string[] args)

        {
            SpielAusgeben();
            while (spiel_aktiv)
            {
                Console.WriteLine("Spieler " + spieler_aktuell + " am Zug");
                zug = Spieler_eingabe();
                bool aktiv = spiel_aktiv;
                if (Convert.ToBoolean(zug))
                {
                    feld[zug] = Convert.ToChar(spieler_aktuell);
                    SpielAusgeben();
                    gewonnen = Spieler_sieg();
                    if (gewonnen == 'X' || gewonnen == 'O')
                    {
                        Console.WriteLine("Spieler " + gewonnen + " hat gewonnen!");
                        spiel_aktiv = false;
                        break;
                    }
                    unentschieden = Unentschieden();
                    if (unentschieden == 'a')
                    {
                        Console.WriteLine("Spiel ist unentschieden ausgegangen");
                        spiel_aktiv = false;
                    }
                    Spieler_wechseln();
                }
            }
        }

 
        public static void SpielAusgeben()
        {
            Console.WriteLine(" {0}  |  {1}  |  {2}", feld[1], feld[2], feld[3]);
            Console.WriteLine("---------------");
            Console.WriteLine(" {0}  |  {1}  |  {2}", feld[4], feld[5], feld[6]);
            Console.WriteLine("---------------");
            Console.WriteLine(" {0}  |  {1}  |  {2}", feld[7], feld[8], feld[9]);
        }

        public static int Spieler_eingabe()
        {
            while (true)
            {
                Console.WriteLine("Bitte Feld eingeben ");
                spielzug = Console.ReadLine();
                int z;
                bool isbumber = int.TryParse(spielzug, out z);
                if(spielzug == "q")
                {
                    spiel_aktiv = false;
                    Console.WriteLine("Spiel Beendet");
                     return zug;
                }
                if (isbumber)
                {
                    zug = Convert.ToInt32(spielzug);
                    if(zug >=1 && zug <= 9)
                    {
                        if (feld[zug] == 'X' || feld[zug] == 'O')
                        {
                            Console.WriteLine("Das Feld ist bereits belegt - ein anderes wählen!");
                        }
                        else 
                        {
                            return zug; 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zahl muss zwischen 1 und 9 liegen");
                    }
                }
            }

        }
        static void Spieler_wechseln()
        {
            //global spieler_aktuell;
            if (spieler_aktuell == "X")
            {
                spieler_aktuell = "O";
            }
            else
            {
                spieler_aktuell = "X";
            }
        }
        static char Spieler_sieg()
        {
            //reihen
            if (feld[1] == feld[2] && feld[1] == feld[3])
            {
                return feld[1];
            }
            if (feld[4] == feld[5] && feld[4] == feld[6])
            {
                return feld[4];
            }
            if (feld[7] == feld[8] && feld[7] == feld[9])
            {
                return feld[7];
            }
            //spalten
            if (feld[1] == feld[4] && feld[1] == feld[7])
            {
                return feld[1];
            }
            if (feld[2] == feld[5] && feld[2] == feld[8])
            {
                return feld[2];
            }
            if (feld[3] == feld[6] && feld[3] == feld[9])
            {
                return feld[3];
            }
            //diagonal
            if (feld[1] == feld[5] && feld[1] == feld[9])
            {
                return feld[5];
            }
            if (feld[7] == feld[5] && feld[7] == feld[3])
            {
                return feld[5];
            }
            return gewonnen;
        }
        static char Unentschieden()
        {
            if (feld[1] == 'X' | feld[1] == 'O'
                && feld[2] == 'X' | feld[2] == 'O'
                && feld[3] == 'X' | feld[3] == 'O'
                && feld[4] == 'X' | feld[4] == 'O'
                && feld[5] == 'X' | feld[5] == 'O'
                && feld[6] == 'X' | feld[6] == 'O'
                && feld[7] == 'X' | feld[7] == 'O'
                && feld[8] == 'X' | feld[8] == 'O'
                && feld[9] == 'X' | feld[9] == 'O')
            {
                return 'a';
            }
            return 'b';
        }

    }
}