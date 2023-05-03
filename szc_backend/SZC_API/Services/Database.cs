using SZC_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SZC_API.Services
{
    public class Database
    {
        private const string STR_PARAM_JEZIKID = "JezikID";
        private string _connectionString;

        public Database()
        {
            //EntityConnection entityConnection = DlApplicationData.Connection;
            //_connectionString = entityConnection.StoreConnection.ConnectionString;            
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private IList<T> PokreniProceduru<T>(string procedureName, List<SqlParameter> sqlParams) where T : new()
        {
            IList<T> result = new List<T>();
            Instantiator<T> instantiator = new Instantiator<T>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams.ToArray());

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    instantiator.CreateNewInstance();
                    for (int i = 0; i < rdr.FieldCount; ++i)
                    {
                        string name = rdr.GetName(i);
                        object value = rdr.GetValue(i);
                        instantiator.SetValue(name, value);
                    }
                    result.Add(instantiator.GetInstance());
                }

                conn.Close();
            }

            return result;
        }
        
        public List<Models.Ciscenja> getAllCleanups()
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
            {

            };

            return PokreniProceduru<Models.Ciscenja>("getAllCleanups", sqlParams).ToList<Models.Ciscenja>();
        }
        public List<Models.Klijenti> getAllClients()
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
            {

            };

            return PokreniProceduru<Models.Klijenti>("getAllClients", sqlParams).ToList<Models.Klijenti>();
        }
        public List<Models.Klijenti> getClient([FromBody] Klijenti k)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
            {
                new SqlParameter("@id_klijenta", k.id_klijenta),
            };
            
            return PokreniProceduru<Models.Klijenti>("getClient", sqlParams).ToList<Models.Klijenti>();
        }
        public List<Models.Zahtjevi> getRequestStatus([FromBody] Zahtjevi z)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
            {
                new SqlParameter("@id_zahtjeva", z.id_zahtjeva),
            };

            return PokreniProceduru<Models.Zahtjevi>("getRequestStatus", sqlParams).ToList<Models.Zahtjevi>();
        }
        public List<Models.Klijenti> log_in([FromBody] Klijenti k)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
            {
                new SqlParameter("@kor_ime", k.kor_ime),
                new SqlParameter("@lozinka", k.lozinka),
            };

            return PokreniProceduru<Models.Klijenti>("log_in", sqlParams).ToList<Models.Klijenti>();
        }
        public List<Models.Zahtjevi> getAllRequests()
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
            {

            };

            return PokreniProceduru<Models.Zahtjevi>("getAllRequests", sqlParams).ToList<Models.Zahtjevi>();
        }
        public Models.Klijenti addClient([FromBody] Klijenti k)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
                    {
                new SqlParameter("@naziv", k.naziv),
                new SqlParameter("@kor_ime", k.kor_ime),
                new SqlParameter("@lozinka", k.lozinka),
            };
            return PokreniProceduru<Models.Klijenti>("addClient", sqlParams).FirstOrDefault();
        }
        public Models.Klijenti deleteClient([FromBody] Klijenti k)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
                    {
                new SqlParameter("@id_klijenta", k.id_klijenta)
            };
            return PokreniProceduru<Models.Klijenti>("deleteClient", sqlParams).FirstOrDefault();
        }
        public Models.Zahtjevi changeRequest([FromBody] Zahtjevi z)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
                    {
                new SqlParameter("@id_zahtjeva", z.id_zahtjeva),
            };
            return PokreniProceduru<Models.Zahtjevi>("changeRequest", sqlParams).FirstOrDefault();
        }
        public Models.Zahtjevi sendRequest([FromBody] Zahtjevi z)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
                    {
                new SqlParameter("@id_klijenta", z.id_klijenta),
                new SqlParameter("@termin_z", z.termin_z),
                new SqlParameter("@adresa_z", z.adresa_z),
                new SqlParameter("@tip_ciscenje_z", z.tip_ciscenje_z),
                new SqlParameter("@tip_apartman_z", z.tip_apartman_z),
                new SqlParameter("@tel_broj_z", z.tel_broj_z),
            };
            return PokreniProceduru<Models.Zahtjevi>("sendRequest", sqlParams).FirstOrDefault();
        }
        
        public Models.Klijenti editClient([FromBody] Klijenti k)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>()
                    {
                new SqlParameter("@id_klijenta", k.id_klijenta),
                new SqlParameter("@naziv", k.naziv),
                new SqlParameter("@kor_ime", k.kor_ime),
                new SqlParameter("@lozinka", k.lozinka),
            };
            return PokreniProceduru<Models.Klijenti>("editClient", sqlParams).FirstOrDefault();
        }
        
    }
}