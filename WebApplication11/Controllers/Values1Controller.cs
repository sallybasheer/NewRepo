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
    public class Values1Controller : ApiController
    {
       
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=AutomobilesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        // GET api/values1
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Color", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
                return "no";

        }
        // GET api/values1/5
        public string Get(int id)
        {
            SqlDataAdapter db = new SqlDataAdapter("select * from Color  where color_id ='" + id + "'", conn);
            DataTable dt = new DataTable();
            db.Fill(dt);
            if (dt.Rows.Count > 0)
                return JsonConvert.SerializeObject(dt);
            else
                return "no";
        }

        // POST api/values1
        public string  Post([FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("Insert into Color(color_name) VALUES('" + value + "')", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record is added" + value;
            else
                return "no record added";
            conn.Close();

        }

        // PUT api/values1/5
        public string Put(int id, [FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Car set  color_name ='" + value + "' Where color_id='" + id + "'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                return "record is updating";
            else
                return "no record update";

        }

        // DELETE api/values1/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete from Color where color_id ='" + id + "'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record deleted" + " " + id;
            else
                return "no record deleted";
        }
    }
}