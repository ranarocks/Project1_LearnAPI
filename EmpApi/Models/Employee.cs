using System;
using System.Collections.Generic;
using System.Data;

namespace EmpApi.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FullName {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Password { get; set; }

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
    public class ReturnObject
    {
        public List<Employee> ListEmployee { get; set; }
        public string Message { get; set; }
    } 
    public class ReturnMessage
    {
        public string Message { get; set; }
    }
    public class Ismail
    {
        public Boolean IsEmail { get; set; }
    }
    
}