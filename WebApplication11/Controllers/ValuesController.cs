using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
namespace WebApplication11.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=AutomobilesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        // GET api/values

        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Car", conn) ;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
                return "no";

        }
        // GET api/values/5
        public string Get(int id)
        {
            SqlDataAdapter db = new SqlDataAdapter("select  manufacture_company from Car  where  engine_id='" + id+"'", conn);
            DataTable dt = new DataTable();
            db.Fill(dt);
            if (dt.Rows.Count > 0)
                return JsonConvert.SerializeObject(dt);
            else
                return "no";

        }

        // POST api/values
        public string Post([FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("Insert into Car(manufacture_company,engine_id,gear_id) VALUES('" + value + "','1','1')",conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record is added" + value;
            else
                return "no record added";
            conn.Close();

        }

        // PUT api/values/5
        public string Put(int id, [FromBody] string value)

        {
           SqlCommand cmd = new SqlCommand("UPDATE Car set  manufacture_company ='" + value + "' Where engine_id='" + id + "'",conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                return "record is updating";
            else
                return "no record update";

        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete from Car where car_id ='" + id + "'",conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record deleted" + " " + id;
            else
                return "no record deleted";
        }
        
    }
}
