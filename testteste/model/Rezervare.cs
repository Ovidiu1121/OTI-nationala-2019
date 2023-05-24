using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testteste.model
{
    public class Rezervare
    {
        private int idcititor;
        private int idcarte;
        private DateTime datarezervare;
        private int statusrezervare;
        
        public Rezervare()
        {

        }

        public Rezervare(int idcititor,int idcarte, DateTime datarezervare, int statusrezervare)
        {
            this.idcititor = idcititor;
            this.idcarte = idcarte;
            this.datarezervare = datarezervare;
            this.statusrezervare = statusrezervare;
        }

        public Rezervare(string prop)
        {
            string[] a = prop.Split(';');

            this.idcititor=int.Parse(a[0]);
            this.idcarte=int.Parse(a[1]);
            this.datarezervare=DateTime.Parse(a[2]);
            this.statusrezervare=int.Parse(a[3]);

        }

        public int Idcititor
        {
            get { return this.idcititor; }
            set { this.idcititor = value;}
        }

        public int Idcarte
        {
            get { return this.idcarte; }
            set { this.idcarte = value;}
        }

        public DateTime Datarezervare
        {
            get { return this.datarezervare;}
            set { this.datarezervare = value;}
        }

        public int Statusrezervare
        {
            get { return this.statusrezervare; }
            set { this.statusrezervare = value; }
        }


    }
}
