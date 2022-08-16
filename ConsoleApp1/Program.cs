using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sreda myAkvarium = new Sreda(new Kletko("Животная"), new Kletko("Растительная"), new Kletko("Бактериальная"));
            myAkvarium.Jut();

            Console.ReadKey();
        }
    }

    class Sreda
    {
        Kletko[] kletki;
        public void Jut()
        {
            foreach (Kletko kletko in kletki)
            {
                Console.Write(kletko.GetType().Name + " - ");
                //kletko.Syshestvovat();
                kletko.sposobnosti();
                Console.WriteLine();
            }
        }
        public Sreda(params Kletko[] kletki)
        {
            this.kletki = kletki;
        }
    }

    public delegate void SposobnostiKletki();

    class Kletko
    {
        string type;
        public SposobnostiKletki sposobnosti;

        void Delenie()
        {
            Console.WriteLine("Деление");
        }

        void Fotosintez()
        {
            Console.WriteLine("Фотосинтез");
        }

        void Dvigatsa()
        {
            Console.WriteLine("Двигаюсь");
        }

        void Prikreplatsa()
        {
            Console.WriteLine("Прикрепляюсь");
        }

        void Pogloshat()
        {
            Console.WriteLine("Поглощяю");
        }

        public Kletko(string type)
        {
            sposobnosti = new SposobnostiKletki(Delenie);

            if(type == "Животная")
            {
                sposobnosti += Pogloshat;
            }   
            else if(type == "Растительная")
            {
                sposobnosti += Fotosintez;
            }    
            else if(type == "Бактериальная")
            {
                sposobnosti += Dvigatsa;
                sposobnosti += Prikreplatsa;
                sposobnosti += Pogloshat;
            }
            this.type = type;
        }

        public void Syshestvovat()
        {
            Console.WriteLine(type);
            sposobnosti();
        }
    }
}
