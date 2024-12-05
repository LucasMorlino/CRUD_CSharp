using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace CRUD_C_.Pages.Products
{
    public class Delete : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost(int id)
        {
            deleteProduct(id);
            Response.Redirect("/Products/Index");
        }

        private void deleteProduct(int id){
            try
            {
                string connectionString = "Server=GUERRERO-PC\\SQLSERVER;Database=cruddb;Trusted_Connection=True;TrustServerCertificate=True";

                using(SqlConnection connection = new SqlConnection(connectionString)){
                    connection.Open();

                    string sql = "Delete From products WHERE id=@id";
                    using(SqlCommand command = new SqlCommand(sql, connection)){
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não deu para deletar o produto: " + ex.Message);
            }
        }
    }
}