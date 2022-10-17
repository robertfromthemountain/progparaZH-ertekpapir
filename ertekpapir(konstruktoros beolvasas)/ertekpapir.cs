using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ertekpapir_konstruktoros_beolvasas_
{
    // Definialjon egy ertekpapir nevu osztalyt melynek tagjai,
    internal class ertekpapir
    {
        // Nev, ertekpapir neve
        private string nev;
        // Eredmenyek, egy lebegopontos szamokat tarolo tomb-valtozo.
        private double[] eredmenyek;

        //Parameteres konstruktor, mely parameterkent egy stringben veszi at az ertekpapir adatait
        public ertekpapir(string s)
        {
            // Splittel whitespaceknel darabokra bontjuk a sort egy tombbe
            string[] darabok = s.Split(' ');
            // Letrehozzuk az eredmenyek tombot akkora mereture ahany ertek szerepel a sorban (-1 azert kell mert a 0. ertek a nev)
            eredmenyek = new double[darabok.Length - 1];
            // A 0. ertek az ertekpapir neve
            nev = darabok[0];

            for (int i = 0; i < eredmenyek.Length; i++)
            {
                try
                {
                    // Az ertekeket beirjuk az eredmenyek tombbe "darab[i+1]" azert kell, mert a 0. elem a név, a for pedig 0-tol indul
                    eredmenyek[i] = double.Parse(darabok[i + 1]);
                }
                // A konvertalals soran adodod kivetelt ugy kezeljuk, hogy a helyere egy 0-t irunk a tombbe
                catch (Exception)
                {
                    eredmenyek[i] = 0;
                    // Kiiratjuk a kivetel pontos helyet
                    Console.WriteLine(nev + "ertekpapir " + (i + 1) + ". eleme rossz!");

                }
            }

        }

        // Hozam nevu metodus, melynek visszateresi erteke hozam tipusu, es a szamok osszeget hozza vissza:
        public double Hozam()
        {
            return eredmenyek.Sum();
        }

        // Object ToString ujradefinialasa ugy, hogy az ertekpapir neve es a Hozam() fuggveny kerul kiirasra:
        public override string ToString()
        {
            return nev + " " + Hozam();
        }

        // Kiir() fuggveny, mely kiirja az osszes adatot az ertekpapirrol:
        public void Kiir()
        {
            Console.Write(nev + " ");
            foreach (var item in eredmenyek)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
