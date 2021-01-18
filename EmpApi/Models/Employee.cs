using System;
using System.Data;

namespace EmpApi.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }



    }

    public class PostEmployee
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    //public class Read : Employee
    //{
    //    public Read (DataRow row)
    //    {
    //        ID = Convert.ToInt32(row["ID"]);
    //        FullName = row["FullName"].ToString();
    //        Email = row["Email"].ToString();
    //        Address = row["Address"].ToString();
    //        ContactNumber = row["ContactNumber"].ToString();
    //        Country = row["Country"].ToString();
    //        State = row["State"].ToString();
    //        City = row["City"].ToString();
    //        Pincode = row["Pincode"].ToString();
    //        Password = row["Password"].ToString();
    //    }

    //}
}