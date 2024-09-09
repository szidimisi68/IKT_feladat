using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Count()%2 == 0 || args.Count() == 0)
            {
                throw new Exception("Hibás megadás");
            }
            int kozepso = Convert.ToInt32(args[Convert.ToInt32(Math.Ceiling(args.Length / 2d)-1)]);
            int elotte = Convert.ToInt32(args[Convert.ToInt32(Math.Ceiling(args.Length / 2d))-2]);
            int utana = Convert.ToInt32(args[Convert.ToInt32(Math.Ceiling(args.Length / 2d))]);
            Console.WriteLine( elotte > utana ? Math.Pow(kozepso, elotte / utana) : Math.Pow(kozepso, utana / elotte));

            //2.
            int tobbSzotagu = 0;
            int legnagyobb = 0;
            List<char> maganhangzok = new List<char>() {'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u'};
            File.ReadAllLines("szavak.txt").ToList().ForEach(x => {
                int maganhanzo = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    if (maganhangzok.Contains(x[i]))
                    {
                        maganhanzo++;
                    }
                }
                if (maganhanzo > 4)
                {
                    tobbSzotagu++;
                }
                if (maganhanzo > legnagyobb)
                {
                    legnagyobb = maganhanzo;
                }
            });
            Console.WriteLine($"4-nél több szótagú szavak: {tobbSzotagu}");
            Console.WriteLine($"Legtöbb szótagú szám: {legnagyobb}");

            //3.
            Random Rnd = new Random();
            int[,] matrix = new int[6, 6];
            int ossz = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int y = 0; y < 6; y++)
                {
                    int generalt = Rnd.Next(55, 156);
                    matrix[i,y] = generalt;
                    if (i == 0 || i == 5 || y == 0 || y == 5)
                    {
                        ossz += generalt;
                    }
                    Console.Write(" ".PadLeft(3) + generalt);
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"A szélek átlaga: {ossz / 20d}");

            //4.feladat


            List<string> sorok = new List<string>();
            File.ReadAllLines("kep.txt").ToList().ForEach(x =>
            {
                List<string> sor = x.Split(";").ToList();
                if (Convert.ToInt32(sor[1]) < 100)
                {
                    sor[1] = (Convert.ToInt32(sor[1])+20).ToString();
                }
                sorok.Add(sor[0] + ";" + sor[1] + ";" + sor[2]);
            });
            File.WriteAllLines("kekitett.txt" , sorok);
            Console.WriteLine("#Kész");
        }
    }
}