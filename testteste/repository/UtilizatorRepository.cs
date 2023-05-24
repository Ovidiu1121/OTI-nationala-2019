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
    public class UtilizatorRepository
    {

        public string connectionString;
        private DataAcces dataAcces;

        public UtilizatorRepository()
        {
            this.dataAcces = new DataAcces();
            connectionString=GetConnection();
            
        }

        public void load()
        {
            string path = Application.StartupPath+@"\utilizatori.txt";
            StreamReader read=new StreamReader(path);

            string line = "";

            while ((line=read.ReadLine())!=null)
            {
                Utilizator u=new Utilizator(line);

                string sql = "insert into utilizatori(tip,nume_prenume,email,parola) values(@tip,@nume_prenume,@email,@parola)";

                this.dataAcces.SaveData(sql, new { u.Tip, u.Nume_prenume, u.Email, u.Parola }, connectionString);

            }

        }

        public List<Utilizator> getLista()
        {
            string sql = "select * from utilizatori";

            return this.dataAcces.LoadData<Utilizator, dynamic>(sql, new { }, connectionString);
        }

        public List<int> getIdByNume(string nume)
        {
            string sql = "select id from utilizatori where nume_prenume=@nume";

            return this.dataAcces.LoadData<int,dynamic>(sql, new { nume }, connectionString);
        }

        public List<Utilizator> getUtilizatorByNume(string nume)
        {
            string sql = "select * from utilizatori where nume_prenume=@nume";

            return this.dataAcces.LoadData<Utilizator, dynamic>(sql, new { nume }, connectionString);
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
