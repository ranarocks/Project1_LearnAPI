using EmpApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace EmpApi.Data_Access_Layer
{
    public class EmployeeDetails
    {
        public List<Employee> GetDataReg()
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

        public ReturnObject GetDetailsByEmail(string Email)
        {
            var returnObj = new ReturnObject();

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
            cmd.Parameters.Add("@Response_Message", SqlDbType.VarChar, 50);
            cmd.Parameters["@Response_Message"].Direction = ParameterDirection.Output;

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
            if (Emp.Count > 0)
            {
                returnObj.ListEmployee = Emp;
               
            }
            else
            {
                returnObj.Message = (string)cmd.Parameters["@Response_Message"].Value;
               
            }

            return returnObj;

        }

        public ReturnMessage PostDataLogic([FromBody] PostEmployee InsertEmp)
        {
            var messageObj = new ReturnMessage();

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
            cmd.Parameters.Add("@ResponseMessage", SqlDbType.VarChar, 50);
            cmd.Parameters["@ResponseMessage"].Direction = ParameterDirection.Output;

            int res = cmd.ExecuteNonQuery();

            

            if (res > 0)
            {
                messageObj.Message = (string)cmd.Parameters["@ResponseMessage"].Value;
            }
            else
            {
                messageObj.Message = (string)cmd.Parameters["@ResponseMessage"].Value;
            }

            return messageObj;

        }

        public ReturnObject CredentialCheckLogic(string Email, string Password)
        {
            var returnObj = new ReturnObject();

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
            cmd.Parameters.Add("@Response_Message", SqlDbType.VarChar, 50);
            cmd.Parameters["@Response_Message"].Direction = ParameterDirection.Output;

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

            if(Emp.Count > 0)
            {
                returnObj.ListEmployee = Emp;

            }
            else
            {
                returnObj.Message = (string)cmd.Parameters["@Response_Message"].Value;
            }

            return returnObj;
        }

        public List<Employee> CheckEmailOrUsernameLogic(string Email, string Username)
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
        public Ismail IsEmailLogic(string Email)
        {
            var MailObj = new Ismail();
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
            cmd.Parameters.Add("@EmailExists", SqlDbType.Bit);
            cmd.Parameters["@EmailExists"].Direction = ParameterDirection.Output;
            var res = cmd.ExecuteReader();
            if (res != null)
            {
                MailObj.IsEmail = (bool)cmd.Parameters["@EmailExists"].Value;
            }
            else
            {
                MailObj.IsEmail = (bool)cmd.Parameters["@EmailExists"].Value;
            }
            

            return MailObj;
        }

    }
}