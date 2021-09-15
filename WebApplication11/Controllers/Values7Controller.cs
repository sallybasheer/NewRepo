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
    public class Values7Controller : ApiController
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=AutomobilesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");



        // GET api/values7
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Truck", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
                return "no";

        }

        // GET api/values7/5
        public string Get(int id)
        {
            SqlDataAdapter db = new SqlDataAdapter("select * from Truck where truck_id='" + id + "'", conn);
            DataTable dt = new DataTable();
            db.Fill(dt);
            if (dt.Rows.Count > 0)
                return JsonConvert.SerializeObject(dt);
            else
                return "no";
        }

        // POST api/values7
        public string Post([FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("Insert into Truck(plate_number,manufacture_company,manufacture_date,engine_id) VALUES('" + value + "','jeep11','" + 14/5/1999 +"','1')", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record is added" + value;
            else
                return "no record added";
            conn.Close();


        }

        // PUT api/values7/5
        public string Put(int id, [FromBody] string value)
        {
            SqlCommand cmd = new SqlCommand("UPDATE  Truck set plate_number ='" + value + "' Where truck_id='" + id + "'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                return "record is updating";
            else
                return "no record update";
        }

        // DELETE api/values7/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete from Truck  where truck_id ='" + id + "'", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
                return "record deleted" + " " + id;
            else
                return "no record deleted";
        }
    }
}