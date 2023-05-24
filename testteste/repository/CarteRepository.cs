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
    public class CarteRepository
    {
        private DataAcces dataAcces;
        public string connectionString;

        public CarteRepository()
        {
            this.dataAcces = new DataAcces();
            connectionString =GetConnection();
        }

        public void load()
        {
            string path = Application.StartupPath+@"\carti.txt";
            StreamReader read=new StreamReader(path);

            string line = "";

            while ((line=read.ReadLine())!=null)
            {
                Carte c =new Carte(line);

                string sql = "insert into carti(titlu,autor,nr_pag)  values(@titlu,@autor,@nr_pag)";

                this.dataAcces.SaveData(sql, new { c.Titlu, c.Autor, c.Nr_pag }, connectionString);
            }

        }

        public string GetConnection()
        {
            string c=Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string connectionString = configuration.GetConnectionString("Default");
            return connectionString;
        }

    }
}
