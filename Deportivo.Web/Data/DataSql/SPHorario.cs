using Deportivo.Web.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Deportivo.Web.Data.DataSql
{
    public class SPHorario
    {
        public SqlConnection conex;
        public SPHorario()
        {
            var config = GetConfiguration();
            conex = new SqlConnection(config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<VMCanchas>> spCanchas(DateTime fecini, DateTime fecfin)
        {
            try
            {
                List<VMCanchas> LstCanchas = new List<VMCanchas>();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_ESPDEPOR_Q01]", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FECINI", fecini);
                cmd.Parameters.AddWithValue("@FECFIN", fecfin);
                conex.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMCanchas objCancha = new VMCanchas();
                    objCancha.id_espdep = Convert.ToInt32(rdr["id_espdep"]);
                    objCancha.espdep_desc = rdr["espdep_desc"].ToString();
                    LstCanchas.Add(objCancha);
                }
                conex.Close();
                return LstCanchas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
