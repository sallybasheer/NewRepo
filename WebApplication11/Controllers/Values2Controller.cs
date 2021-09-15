using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;
namespace WebApplication11.Controllers
{
    public class Values2Controller : ApiController
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=AutomobilesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        // GET api/values2
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Engine", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
                return "no";

        }

        // GET api/values2/5
        public string Get(int id)
        {
            SqlDataAdapter db = new SqlDataAdapter("select * from Engine  where engine_id='" + id + "'", conn);
            DataTable dt = new DataTable();
            db.Fill(dt);
            if (dt.Rows.Count > 0)
                return JsonConvert.SerializeObject(dt);
            else
                return "no";
        }

        // POST api/values2
        public string Post([FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("Insert into Engine(manufacture_company,fuel_id) VALUES('" + value + "','2')", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record is added" + value;
            else
                return "no record added";
            conn.Close();

        }

        // PUT api/values2/5
        public string Put(int id, [FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Engine set  manufacture_company ='" + value + "' Where fuel_id='" + id + "'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                return "record is updating";
            else
                return "no record update";
        }

        // DELETE api/values2/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete from Engine where engine_id ='" + id + "'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record deleted" + " " + id;
            else
                return "no record deleted";
        }
    }
}