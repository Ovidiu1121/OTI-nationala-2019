using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testteste.model
{
    public class DtoCartiImprumutate
    {

        private int idimprumut;
        private int idcarte;
        private string titlu;
        private string autor;
        private DateTime dataimprumut;
        private DateTime dataexpirare;

        public DtoCartiImprumutate()
        {

        }

        public DtoCartiImprumutate(int idimprumut,int idcarte,string titlu,string autor,DateTime dataimprumut,DateTime dataexpirare)
        {
            this.idimprumut = idimprumut;
            this.idcarte = idcarte;
            this.titlu = titlu;
            this.autor = autor;
            this.dataimprumut=dataimprumut;
            this.dataexpirare = dataexpirare;
        }

        public int IdImprumut
        {
            get { return this.idimprumut; }
            set { this.idimprumut = value;}
        }

        public int Idcarte
        {
            get { return this.idcarte; }
            set { this.idcarte = value;}
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

        public DateTime Dataimprumut
        {
            get { return this.dataimprumut; }
            set { this.dataimprumut = value;}
        }

        public DateTime Dataexpirare
        {
            get { return this.dataexpirare; }
            set { this.dataexpirare = value;}
        }

    }
}
