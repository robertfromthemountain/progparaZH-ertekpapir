using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ertekpapir_konstruktoros_beolvasas_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Elore megadott meretu (fajlban szereplo sorok szama) ertekpapir tipusu tomb letrehozasa
            ertekpapir[] ertekpapirs = new ertekpapir[5];

            try
            {
                // Fajlbeolvasas
                StreamReader read = new StreamReader("teszt.txt");
                for (int i = 0; i < ertekpapirs.Length; i++)
                {
                    // Olvassa be a fajl sorait ugy, hogy a sorokbol letrehozott Ertekpapir peldanyokat irja bele egy 5 elemu tombbe  
                    ertekpapirs[i] = new ertekpapir(read.ReadLine());
                }
                // Olvasas bezarasa
                read.Close();
            }
            catch (Exception e)
            {
                // Fajl megnyitasa soran adodo kivetel kezelese, Message tag kiirasaval
                Console.WriteLine(e.Message);
                return;
            }

            // Kiiratas Kiir() fuggvennyel:
            Console.WriteLine();
            Console.WriteLine("Ertekpapirok adatokkal: ");
            for (int i = 0; i < ertekpapirs.Length; i++)
            {
                ertekpapirs[i].Kiir();
            }

            // Kiiratas ToString() fuggvennyel:
            Console.WriteLine();
            Console.WriteLine("Ertekpapirok hozamokkal: ");
            for (int i = 0; i < ertekpapirs.Length; i++)
            {
                Console.WriteLine(ertekpapirs[i]);
            }

            // Hozzon letre egy Sikeresek nevu ertekpapir tombot, mely azokat az ertekpapir peldanyokat gyujti, melyek hozamerteke pozitiv
            ertekpapir[] sikeresek = new ertekpapir[5];
            int seged = 0;
            for (int i = 0; i < sikeresek.Length; i++)
            {
                if (ertekpapirs[i].Hozam() > 0)
                {
                    sikeresek[seged] = ertekpapirs[i];
                    seged++;
                }
            }

            // Sikeresek kiiratasa:
            Console.WriteLine();
            Console.WriteLine("Sikeres ertekpapirok (hozam>0):");
            foreach (var item in sikeresek)
            {
                Console.WriteLine(item);
            }




        }
    }
}
