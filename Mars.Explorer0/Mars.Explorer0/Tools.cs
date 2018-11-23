using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Explorer0
{

    public static class Tools
    {

        public static void DimensionControl()
        {
            bool gecerli = false;
            string sayi = "";
            string[] konum;
            Console.Write("Lütfen alan boyutunu giriniz: ");
            ConsoleKeyInfo karakter;
            do
            {
                karakter = Console.ReadKey(true);
                if (karakter.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool kontrol = double.TryParse(karakter.KeyChar.ToString(), out val);
                    if (kontrol)
                    {
                        sayi += karakter.KeyChar;
                        Console.Write(karakter.KeyChar);
                    }
                    if (karakter.Key == ConsoleKey.Spacebar)
                    {
                        sayi += karakter.KeyChar;
                        Console.Write(karakter.KeyChar);
                    }
                }
                else
                {
                    if (karakter.Key == ConsoleKey.Backspace && sayi.Length > 0)
                    {
                        sayi = sayi.Substring(0, (sayi.Length - 1));
                        Console.Write("\b \b");
                    }
                }
                konum = sayi.Split(' ');
                if (konum.Length == 2 && konum[1].ToString() != "")
                {
                    gecerli = true;
                }
                else if ((konum.Length < 2 || konum.Length > 2) && karakter.Key == ConsoleKey.Enter)
                {
                    sayi = string.Empty;
                    Array.Clear(konum, 0, konum.Length);
                    gecerli = false;
                    Console.WriteLine(" \nGirdiğiniz boyut geçerli değildir.");
                    Console.Write("Lütfen alan boyutunu tekrar giriniz: ");
                }
            }

            while (karakter.Key != ConsoleKey.Enter || gecerli != true);

            Dimension.DimX = Convert.ToInt32(konum[0].ToString());
            Dimension.DimY = Convert.ToInt32(konum[1].ToString());

        }
        public static string[] LocationControl()
        {

            bool gecerli = false;
            string sayi = "";
            string[] loc;
            string yon;
            string N = "0", W = "270", E = "90", S = "180";
            int boyutKontrol = 0;

            Console.Write("\nLütfen konum giriniz: ");
            ConsoleKeyInfo karakter;
            do
            {
                karakter = Console.ReadKey(true);
                yon = Convert.ToString(karakter.KeyChar);
                try
                {
                    boyutKontrol = Convert.ToInt32(karakter.KeyChar.ToString());
                }
                catch (Exception)
                { }

                if (karakter.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool kontrol = double.TryParse(karakter.KeyChar.ToString(), out val);
                    if (kontrol && sayi.Split(' ').Length <= 1 && boyutKontrol <= Dimension.DimX)
                    {
                        sayi += karakter.KeyChar;
                        Console.Write(karakter.KeyChar);
                    }
                    if (kontrol && sayi.Split(' ').Length == 2 && boyutKontrol <= Dimension.DimY)
                    {
                        sayi += karakter.KeyChar;
                        Console.Write(karakter.KeyChar);
                    }
                    if (karakter.Key == ConsoleKey.Spacebar)
                    {
                        sayi += karakter.KeyChar;
                        Console.Write(karakter.KeyChar);
                    }
                    if (sayi.Split(' ').Length == 3 && sayi.Split(' ')[2].ToString() == "" && (yon.ToUpper() == "N" || yon.ToUpper() == "E" || yon.ToUpper() == "W" || yon.ToUpper() == "S"))
                    {
                        sayi += karakter.KeyChar;
                        Console.Write(karakter.KeyChar);
                    }
                }
                else
                {
                    if (karakter.Key == ConsoleKey.Backspace && sayi.Length > 0)
                    {
                        sayi = sayi.Substring(0, (sayi.Length - 1));
                        Console.Write("\b \b");
                    }
                }
                loc = sayi.Split(' ');
                if (loc.Length == 3 && loc[2].ToString() != "")
                {
                    gecerli = true;
                }
                else if (loc.Length != 3 && karakter.Key == ConsoleKey.Enter)
                {
                    sayi = string.Empty;
                    Array.Clear(loc, 0, loc.Length);
                    gecerli = false;
                    Console.WriteLine(" \nGirdiğiniz konum geçerli değildir.");
                    Console.Write("Lütfen konumu tekrar giriniz: ");
                }
            }

            while (karakter.Key != ConsoleKey.Enter || gecerli != true);

            string yon1 = loc[2].ToString().ToUpper();
            if (yon1 == "N") loc[2] = N;
            if (yon1 == "W") loc[2] = W;
            if (yon1 == "E") loc[2] = E;
            if (yon1 == "S") loc[2] = S;
            return loc;
        }
        public static string OrderControl()
        {
            string kontrol = "";
            string direktif = "";
            bool gecerli = false;
            int count = 0;
            do
            {
                Console.Write("\nLütfen direktif giriniz: ");
                direktif = Console.ReadLine();
                for (int i = 0; i < direktif.Length; i++)
                {
                    kontrol = direktif[i].ToString().ToUpper();
                    if (kontrol == "L" || kontrol == "R" || kontrol == "M")
                    {
                        count++;
                        if (direktif.Length == count) gecerli = true;

                    }
                    else { Console.Write("\nLütfen girdiğiniz direktifi kontrol ediniz. "); break; }
                }
            } while (gecerli != true);
            return direktif;
        }

    }
}
