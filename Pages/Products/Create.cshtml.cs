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
    public class Create : PageModel
    {
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



        public void OnGet()
        {
        }

        public string ErrorMessage { get; set;} = "";

        public void OnPost()
        {
            if(!ModelState.IsValid){
                return;
            }

            try{
                string connectionString = "Server=GUERRERO-PC\\SQLSERVER;Database=cruddb;Trusted_Connection=True;TrustServerCertificate=True";

                using(SqlConnection connection = new SqlConnection(connectionString)){
                    connection.Open();

                    string sql = "INSERT INTO products " + 
                        "(productName, enterpriseName, email, phone, amont) Values" +
                        "(@productName, @enterpriseName, @email, @phone, @amont)";

                    using (SqlCommand command = new SqlCommand(sql, connection)){
                        command.Parameters.AddWithValue("@productName", productName);
                        command.Parameters.AddWithValue("@enterpriseName", enterpriseName);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@amont", Convert.ToInt32(amont));

                        command.ExecuteNonQuery();
                    }
                }
            }catch(Exception ex){
                ErrorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Products/Index");

        }
    }
}