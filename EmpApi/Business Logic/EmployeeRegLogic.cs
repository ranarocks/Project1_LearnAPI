using EmpApi.Data_Access_Layer;
using EmpApi.Models;
using System.Collections.Generic;

namespace EmpApi.Business_Logic
{
    public class EmployeeRegLogic
    {
        public List<Employee> GetDetails()
        {
            EmployeeDetails employeedetailsObj = new EmployeeDetails();
            return employeedetailsObj.GetDataReg();
        }

       public ReturnObject GetDetailsEmailReg(string Email)
        {
            EmployeeDetails employeedetailsObj = new EmployeeDetails();
            return employeedetailsObj.GetDetailsByEmail(Email);
        }
        public ReturnMessage PostData( PostEmployee InsertEmp)
        {
            EmployeeDetails employeeDetailsObj = new EmployeeDetails();
            return employeeDetailsObj.PostDataLogic(InsertEmp);
        }

        public ReturnObject CredentialCheck(string Email, string Password)
        {
            EmployeeDetails employeeDetailsObj = new EmployeeDetails();
            return employeeDetailsObj.CredentialCheckLogic(Email, Password);
        }
        public List<Employee> CheckEmailOrUsername(string Email, string Username)
        {
            EmployeeDetails employeeDetailsObj = new EmployeeDetails();
            return employeeDetailsObj.CheckEmailOrUsernameLogic(Email, Username);
        }
        public Ismail IsEmail(string Email)
        {
            EmployeeDetails employeeDetailsObj = new EmployeeDetails();
            return employeeDetailsObj.IsEmailLogic(Email);
        }

    }
}