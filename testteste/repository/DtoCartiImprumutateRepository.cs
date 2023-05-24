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
    public class DtoCartiImprumutateRepository
    {

        public string connectionString;
        private DataAcces dataAcces;

        public DtoCartiImprumutateRepository()
        {
            this.dataAcces = new DataAcces();
            connectionString=GetConnection();

        }

        public List<DtoCartiImprumutate> getList(int utilizatorId)
        {
            string sql = "SELECT imprumuturi.id, carti.id, carti.titlu, carti.autor, imprumuturi.data_imprumut FROM utilizatori JOIN imprumuturi ON imprumuturi.id_cititor = @utilizatorId JOIN carti ON carti.id = imprumuturi.id_carte group by imprumuturi.id";

            return this.dataAcces.LoadData<DtoCartiImprumutate, dynamic>(sql, new { utilizatorId }, connectionString);
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
