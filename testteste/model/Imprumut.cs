using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testteste.model
{
    public class Imprumut
    {
        private int idcititor;
        private int idcarte;
        private DateTime dataimprumut;
        private DateTime datarestituire;

        public Imprumut()
        {

        }

        public Imprumut(int idcititor, int idcarte, DateTime dataimprumut, DateTime datarestituire)
        {
            this.idcititor = idcititor;
            this.idcarte = idcarte;
            this.dataimprumut = dataimprumut;
            this.datarestituire = datarestituire;
        }

        public Imprumut(string prop)
        {
            string[] a = prop.Split(';');

            this.idcititor=int.Parse(a[0]);
            this.idcarte=int.Parse(a[1]);

            DateTime date1 = DateTime.ParseExact(a[2].ToString(), "MM/dd/yyyy hh/mm/ss tt", CultureInfo.InvariantCulture);
            string dataimprumut = date1.ToString("yyyy-MM-dd HH:mm:ss");
            this.dataimprumut=DateTime.Parse(dataimprumut);

            if (a[3].Equals("NULL"))
            {
                this.datarestituire=DateTime.Now.AddYears(-100);
            }
            else
            {
                DateTime date2 = DateTime.ParseExact(a[3].ToString(), "MM/dd/yyyy hh/mm/ss tt", CultureInfo.InvariantCulture);
                string datarestituire = date2.ToString("yyyy-MM-dd HH:mm:ss");
                this.datarestituire=DateTime.Parse(datarestituire);
            }
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

        public DateTime Dataimprumut
        {
            get { return this.dataimprumut; }
            set { this.dataimprumut = value;}
        }

        public DateTime Datarestituire
        {
            get { return this.datarestituire; }
            set { this.datarestituire = value; }
        }

    }
}
