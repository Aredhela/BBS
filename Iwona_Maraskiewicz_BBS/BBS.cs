using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iwona_Maraskiewicz_BBS
{
    class BBS
    {

        // p i q - liczby pierwsze rozne od siebie, ktore w dzieleniu przez 4 daja reszte 3
        // ziarno - dowolna liczba niepodzielna przez p ani przez q
        // ziarno jest poczatkowa wartoscia generatora (x_0), kolejne wyliczane sa wzorem x_i+1=(x_i)^2 mod N
        public BBS(int p, int q, int ziarno)
        {
            x = ziarno;
            n = p * q;
        }

        public bool wygenerujLosowyBit()
        {
            //przykladowo, tutaj brany jest najmniej znaczacy bit (bit parzystosci),
            //moznaby wziac ktorykolwiek inny, ale wziac reszte z dzielenia przez 2 jest najprosciej :D
            bool wygenerowanyBit = (x % 2) == 1;
            x = (x * x) % n; //obliczenie nastepnej wartosci wg wzoru x=x^2 mod N // x_i+1=(x_i)^2 mod N
            return wygenerowanyBit;
        }

        public string wygenerujLosowyCiag(int dlugoscWBitach)
        {
            string wygenerowanyCiag = "";
            for (int i = 0; i < dlugoscWBitach; ++i)
            {
                wygenerowanyCiag += wygenerujLosowyBit() ? '1' : '0';
            }
            return wygenerowanyCiag;
        }

        public byte wygenerujLosowyBajt()
        {
            return Convert.ToByte(wygenerujLosowyCiag(8), 2);
        }

        private int x;
        private int n;

        // wykonuje alogrytm sita erastotenesa na liczbach z przedzialu <0,n), zwraca liczby pierwsze z tego przedzialu ktore w dzieleniu przez 4 daja reszte 3
        public static List<int> sitoErastotenesaMod4Equals3(int n)
        {
            return sitoErastotenesaMod4Equals3(0, n);
        }

        // wykonuje alogrytm sita erastotenesa na liczbach z przedzialu <0,n), zwraca liczby pierwsze z przedzialu <min,n) ktore w dzieleniu przez 4 daja reszte 3
        public static List<int> sitoErastotenesaMod4Equals3(int min, int n)
        {
            List<int> liczbyPierwsze = new List<int>();
            bool[] liczby = new bool[n];
            for (int i = 2; i < liczby.Length; ++i)
            {
                liczby[i] = true;
            }
            liczby[0] = false;
            liczby[1] = false;
            double pierwiastek = Math.Floor(Math.Sqrt(n));
            for (int i = 2; i <= pierwiastek; ++i)
            {
                if (liczby[i])
                {
                    for (int j = i * 2; j < liczby.Length; j += i)
                    {
                        liczby[j] = false;
                    }
                }
            }
            for (int i = 0; i < liczby.Length; ++i)
            {
                if (i % 4 != 3) liczby[i] = false;
            }
            for (int i = min; i < liczby.Length; ++i)
            {
                if (liczby[i]) liczbyPierwsze.Add(i);
            }
            return liczbyPierwsze;
        }
    }
}
