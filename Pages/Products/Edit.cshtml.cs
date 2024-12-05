using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace CRUD_C_.Pages.Products
{
    public class Edit : PageModel
    {
        [BindProperty]
        public int id {get; set;}

        [BindProperty, Required(ErrorMessage = "O nome do produto é necessário")]
        public string productName {get; set;} = "";

        [BindProperty, Required(ErrorMessage = "O nome da empresa é necessário")]
        public string enterpriseName {get; set;} = "";

        [BindProperty, Required(ErrorMessage = "O email da empresa é necessário"), EmailAddress]
        public string email {get; set;} = "";

        [BindProperty, Required(ErrorMessage = "O telefone da empresa é necessário"), Phone]
        public string phone {get; set;} = "";

        [BindProperty, Required(ErrorMessage = "A quantidade do produto é necessário")]
        public int amont {get; set;}

        public string ErrorMessage { get; set;} = "";

        public void OnGet(int id)
        {
            try
            {
                string connectionString = "Server=GUERRERO-PC\\SQLSERVER;Database=cruddb;Trusted_Connection=True;TrustServerCertificate=True";

                using(SqlConnection connection = new SqlConnection(connectionString)){
                    connection.Open();

                    string sql = "SELECT * FROM products WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection)){
                        command.Parameters.AddWithValue("@id", id);

                        using(SqlDataReader reader = command.ExecuteReader( )){
                            if (reader.Read()){
                                id = reader.GetInt32(0);
                                productName = reader.GetString(1);
                                enterpriseName = reader.GetString(2);
                                email = reader.GetString(3);
                                phone = reader.GetString(4);
                                amont = reader.GetInt32(5);
                            }
                            else{
                                Response.Redirect("/Products/Index");
                            }
                        }
                    }

                }
            }    
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public void OnPost(){
            if(!ModelState.IsValid){
                return;
            }
            try
            {
                string connectionString = "Server=GUERRERO-PC\\SQLSERVER;Database=cruddb;Trusted_Connection=True;TrustServerCertificate=True";

                using(SqlConnection connection = new SqlConnection(connectionString)){
                    connection.Open();

                    string sql = "UPDATE products SET productName=@productName, enterpriseName=@enterpriseName, email=@email, phone=@phone, amont=@amont WHERE id=@id;";

                    using (SqlCommand command = new SqlCommand(sql, connection)){
                        command.Parameters.AddWithValue("@productName", productName);
                        command.Parameters.AddWithValue("@enterpriseName", enterpriseName);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@amont", amont);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            Response.Redirect("/Products/Index");
        }
    }
}