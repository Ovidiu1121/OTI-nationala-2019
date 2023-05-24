using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testteste.model
{
    public class Carte
    {

        private string titlu;
        private string autor;
        private int nr_pag;

        public Carte()
        {

        }

        public Carte(string titlu,string autor,int nr_pag)
        {
            this.titlu = titlu;
            this.autor = autor;
            this.nr_pag = nr_pag;
        }

        public Carte(string prop)
        {
            string[] a = prop.Split(';');

            this.titlu=a[0];
            this.autor=a[1];
            this.nr_pag=int.Parse(a[2]);

        }

        public string Titlu
        {
            get { return this.titlu; }
            set { this.titlu = value;}
        }

        public string Autor
        {
            get { return this.autor; }
            set { this.autor = value;}
        }

        public int Nr_pag
        {
            get { return this.nr_pag; }
            set { this.nr_pag = value;}
        }



    }
}
