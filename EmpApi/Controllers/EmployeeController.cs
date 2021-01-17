using EmpApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace EmpApi.Controllers
{
    public class EmployeeController : ApiController
    {

        [HttpGet]
        [Route("Employee/GetDetails")]
        public List<Employee> GetDetails()
        {
            //Using Connection String From Web Configuration File
            string Con = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlConnection DbCon = new SqlConnection(Con);
            DbCon.Open();  //Opening Connection for Database
            string GetProc = "spGetData";
            SqlCommand cmd = new SqlCommand(GetProc, DbCon)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Employee> Emp = new List<Employee>();
            while (rdr.Read())
            {
                Emp.Add(new Employee
                {
                    ID = Convert.ToInt32(rdr["ID"]),
                    FullName = rdr["FullName"].ToString(),
                    Email = rdr["Email"].ToString(),
                    Address = rdr["Address"].ToString(),
                    ContactNumber = rdr["ContactNumber"].ToString(),
                    Country = rdr["Country"].ToString(),
                    State = rdr["State"].ToString(),
                    City = rdr["City"].ToString(),
                    Pincode = rdr["Pincode"].ToString(),
                    Password = rdr["Password"].ToString(),
                });
            }

            return Emp;
        }

        [HttpGet]
        [Route("Employee/GetDetailsByEmail/Email")]
        public List<Employee> GetDetailsByEmail(string Email)
        {
            // Using Connection String From Web Configuration File
            string Con = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlConnection DbCon = new SqlConnection(Con);
            DbCon.Open();  //Opening Connection for Database
            string GetEmailData = "spUserInfo";
            SqlCommand cmd = new SqlCommand(GetEmailData, DbCon)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Email", Email);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Employee> Emp = new List<Employee>();
            while (rdr.Read())
            {
                Emp.Add(new Employee
                {
                    ID = Convert.ToInt32(rdr["ID"]),
                    FullName = rdr["FullName"].ToString(),
                    Email = rdr["Email"].ToString(),
                    Address = rdr["Address"].ToString(),
                    ContactNumber = rdr["ContactNumber"].ToString(),
                    Country = rdr["Country"].ToString(),
                    State = rdr["State"].ToString(),
                    City = rdr["City"].ToString(),
                    Pincode = rdr["Pincode"].ToString(),
                    Password = rdr["Password"].ToString(),
                });
            }

            return Emp;
        }

        [HttpPost]
        [Route("Employee/PostData")]
        public string PostData([FromBody] PostEmployee InsertEmp)
        {
            string Con = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlConnection DbCon = new SqlConnection(Con);
            DbCon.Open();  //Opening Connection for Database
            SqlCommand cmd = new SqlCommand("spInsertDetails", DbCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FullName", InsertEmp.FullName);
            cmd.Parameters.AddWithValue("@Email", InsertEmp.Email);
            cmd.Parameters.AddWithValue("@Address", InsertEmp.Address);
            cmd.Parameters.AddWithValue("@ContactNumber", InsertEmp.ContactNumber);
            cmd.Parameters.AddWithValue("@Country", InsertEmp.Country);
            cmd.Parameters.AddWithValue("@State", InsertEmp.State);
            cmd.Parameters.AddWithValue("@City", InsertEmp.City);
            cmd.Parameters.AddWithValue("@Pincode", InsertEmp.Pincode);
            cmd.Parameters.AddWithValue("@Password", InsertEmp.Password);
            cmd.Parameters.AddWithValue("@ConfirmPassword", InsertEmp.ConfirmPassword);

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                return "Data is Inserted";
            }
            else
            {
                return "Data not Inserted";
            }

        }

        [HttpGet]
        [Route("Employee/CredentialCheck/Email/Password")]
        public List<Employee> CredentialCheck(string Email, string Password )
        {
            // Using Connection String From Web Configuration File
            string Con = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlConnection DbCon = new SqlConnection(Con);
            DbCon.Open();  //Opening Connection for Database
            string GetEmailData = "spCredentialsCheck";
            SqlCommand cmd = new SqlCommand(GetEmailData, DbCon)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Employee> Emp = new List<Employee>();
            while (rdr.Read())
            {
                Emp.Add(new Employee
                {
                    ID = Convert.ToInt32(rdr["ID"]),
                    FullName = rdr["FullName"].ToString(),
                    Email = rdr["Email"].ToString(),
                    Address = rdr["Address"].ToString(),
                    ContactNumber = rdr["ContactNumber"].ToString(),
                    Country = rdr["Country"].ToString(),
                    State = rdr["State"].ToString(),
                    City = rdr["City"].ToString(),
                    Pincode = rdr["Pincode"].ToString(),
                    Password = rdr["Password"].ToString(),
                });
            }

            return Emp;
        }

        [HttpGet]
        [Route("Employee/CheckEmailOrUsername/Email/Username")]
        public List<Employee> CheckEmailOrUsername(string Email , string Username)
        {
            // Using Connection String From Web Configuration File
            string Con = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlConnection DbCon = new SqlConnection(Con);
            DbCon.Open();  //Opening Connection for Database
            string GetEmailData = "spCheckEmailOrUsername";
            SqlCommand cmd = new SqlCommand(GetEmailData, DbCon)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Username", Username);
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Employee> Emp = new List<Employee>();
            while (rdr.Read())
            {
                Emp.Add(new Employee
                {
                    ID = Convert.ToInt32(rdr["ID"]),
                    FullName = rdr["FullName"].ToString(),
                    Email = rdr["Email"].ToString(),
                    Address = rdr["Address"].ToString(),
                    ContactNumber = rdr["ContactNumber"].ToString(),
                    Country = rdr["Country"].ToString(),
                    State = rdr["State"].ToString(),
                    City = rdr["City"].ToString(),
                    Pincode = rdr["Pincode"].ToString(),
                    Password = rdr["Password"].ToString(),
                });
            }

            return Emp;
        }


        [HttpGet]
        [Route("Employee/IsEmail/Email")]
        public string IsEmail(string Email)
        {
            // Using Connection String From Web Configuration File
            string Con = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlConnection DbCon = new SqlConnection(Con);
            DbCon.Open();  //Opening Connection for Database
            string GetEmailData = "IsEmail";
            SqlCommand cmd = new SqlCommand(GetEmailData, DbCon)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Email", Email);

            //int res = cmd.ExecuteNonQuery();
            //if(res > 0)
            //{
            //    return "Is a Valid";
            //}
            //else
            //{
            //    return "Not Found";
            //}

        }

    }
}
