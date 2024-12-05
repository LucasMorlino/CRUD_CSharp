using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace CRUD_C_.Pages.Products
{
    public class Index : PageModel
    {
        public List<ProductsInfo> ProductsList { get; set; } = [];
        public void OnGet()
        {
            try{
                string connectionString = "Server=GUERRERO-PC\\SQLSERVER;Database=cruddb;Trusted_Connection=True;TrustServerCertificate=True";

                using ( SqlConnection connection = new SqlConnection(connectionString)){
                    connection.Open();

                    string sql = "SELECT * FROM products ORDER BY id DESC";

                    using ( SqlCommand command = new SqlCommand(sql, connection)){
                        using (SqlDataReader reader = command.ExecuteReader()){
                            while(reader.Read()){
                                ProductsInfo productsInfo = new ProductsInfo();
                                productsInfo.id             = reader.GetInt32(0);
                                productsInfo.productName    = reader.GetString(1);
                                productsInfo.enterpriseName = reader.GetString(2);
                                productsInfo.email          = reader.GetString(3);
                                productsInfo.phone          = reader.GetString(4);
                                productsInfo.amont          = reader.GetInt32(5);
                                productsInfo.createdAt      = reader.GetDateTime(6).ToString("dd/MM/yyyy");

                                ProductsList.Add(productsInfo);
                            }
                        }
                    }
                }

            }catch(Exception ex){
                Console.WriteLine("Possui um erro: "+ ex.Message);
            }

        }
    }

    public class ProductsInfo{
        public int id {get; set;}
        public string productName {get; set;} = "";
        public string enterpriseName {get; set;} = "";
        public string email {get; set;} = "";
        public string phone {get; set;} = "";
        public int amont {get; set;}
        public string createdAt { get; set; } = "";
    }
}
