using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testteste.data;
using testteste.model;

namespace testteste.repository
{
    public class ImpurmutRepository
    {

        private DataAcces dataAcces;
        private string connectionString;

        public ImpurmutRepository()
        {
            this.dataAcces = new DataAcces();
            this.connectionString=GetConnection();
        }

        public void load()
        {
            string path = Application.StartupPath+@"\imprumuturi.txt";
            StreamReader read=new StreamReader(path);
            string line = "";

            while ((line=read.ReadLine())!=null)
            {
                Imprumut i = new Imprumut(line);

                if (i.Datarestituire.Year<2000)
                {
                    string sql = "insert into imprumuturi(id_cititor, id_carte, data_imprumut, data_restituire) value(@idcititor,@idcarte,@dataimprumut,null)";

                    this.dataAcces.SaveData(sql, new { i.Idcititor, i.Idcarte, i.Dataimprumut, }, connectionString);
                }
                else
                {
                    string sql = "insert into imprumuturi(id_cititor, id_carte, data_imprumut, data_restituire) value(@idcititor,@idcarte,@dataimprumut,@datarestituire)";

                    this.dataAcces.SaveData(sql, new { i.Idcititor, i.Idcarte, i.Dataimprumut, i.Datarestituire }, connectionString);
                }
            }
            read.Close();
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
