using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testteste.data;
using testteste.model;
namespace testteste.repository
{
    public class RezervariRepository
    {

        public string connectionString;
        private DataAcces dataAcces;

        public RezervariRepository()
        {
            this.dataAcces = new DataAcces();
            connectionString=GetConnection();

        }

        public void load()
        {
            string path = Application.StartupPath+@"\rezervari.txt";
            StreamReader read = new StreamReader(path);

            string line = "";

            while ((line=read.ReadLine())!=null)
            {
                Rezervare r = new Rezervare(line);

                string sql = "insert into rezervari(id_cititor,id_carte,data_rezervare,status_rezervare) values(@idcititor,@idcarte,@datarezervare,@statusrezervare)";

                this.dataAcces.SaveData(sql, new { r.Idcititor, r.Idcarte, r.Datarezervare, r.Statusrezervare }, connectionString);

            }

        }

        public string GetConnection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string connectionStringIs = configuration.GetConnectionString("Default");
            return connectionStringIs;
        }
    }
}
