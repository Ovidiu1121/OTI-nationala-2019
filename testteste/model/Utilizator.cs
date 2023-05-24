using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testteste.model
{
    public class Utilizator
    {

        private int tip;
        private string nume_prenume;
        private string email;
        private string parola;

        public Utilizator()
        {

        }

        public Utilizator(int tip,string nume_prenume,string email,string parola)
        {
            this.tip = tip;
            this.nume_prenume = nume_prenume;
            this.email = email;
            this.parola = parola;
        }

        public Utilizator(string prop)
        {
            string[] a = prop.Split(';');

            this.tip = int.Parse(a[0]);
            this.nume_prenume=a[1];
            this.email = a[2];
            this.parola = a[3];

        }

        public int Tip
        {
            get { return this.tip; }
            set { this.tip = value; }
        }

        public string Nume_prenume
        {
            get { return this.nume_prenume;}
            set { this.nume_prenume = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Parola
        {
            get { return this.parola; }
            set { this.parola = value;}
        }


    }
}
