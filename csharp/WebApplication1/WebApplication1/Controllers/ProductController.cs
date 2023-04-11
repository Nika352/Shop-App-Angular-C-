using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace WebApplication1.Controllers
{
    
    public class ProductController : Controller
    {

        SqlConnection conn = new SqlConnection("Server=DESKTOP-IJL7MF3; Database=Products; " +
            "Trusted_Connection=true; ");


        //returns list of products from all the values on the table.
        [HttpGet("GetProducts")]
        public List<Product> getAllProducts()
        {

            List<Product> result = new List<Product>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Products].[dbo].[ProductsTable]", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                int id = Int32.Parse((dt.Rows[i]["id"].ToString()));
                string title = (dt.Rows[i]["title"].ToString());
                double price = double.Parse((dt.Rows[i]["price"].ToString()));
                string description = (dt.Rows[i]["description"].ToString());
                string category = (dt.Rows[i]["category"].ToString());
                string image = (dt.Rows[i]["image"].ToString());

                result.Add(new Product(id, title, price, description, category, image));
            }

            return result;
        }

        [HttpGet("GetProductById")]
        public Product getById(int id)
        {
            SqlCommand command = new SqlCommand("getById", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;

            DataTable dt = new DataTable();
            da.Fill(dt);

            string title = (dt.Rows[0]["title"].ToString());
            double price = double.Parse((dt.Rows[0]["price"].ToString()));
            string description = (dt.Rows[0]["description"].ToString());
            string category = (dt.Rows[0]["category"].ToString());
            string image = (dt.Rows[0]["image"].ToString());


            return new Product(id, title, price, description, category, image);
        }

        [HttpGet("GetJSON")]
        public string getJson()
        {
            return JsonConvert.SerializeObject(getAllProducts());
        }


      
    }
}
