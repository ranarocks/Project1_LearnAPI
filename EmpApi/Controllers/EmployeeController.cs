using EmpApi.Business_Logic;
using EmpApi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace EmpApi.Controllers
{
    public class EmployeeController : ApiController
    {

        [HttpGet]
        [Route("Employee/GetDetails")]
        public List<Employee> GetDetails()
        {
            EmployeeRegLogic employeeRegLogic = new EmployeeRegLogic();
            return employeeRegLogic.GetDetails();
        }

        [HttpGet]
        [Route("Employee/GetDetailsByEmail/Email")]
        public ReturnObject GetDetailsByEmail(string Email)
        {
            EmployeeRegLogic employeeRegLogic = new EmployeeRegLogic();
            return employeeRegLogic.GetDetailsEmailReg(Email);
        }

        [HttpPost]
        [Route("Employee/PostData")]
        public ReturnMessage PostData([FromBody] PostEmployee InsertEmp)
        {
            EmployeeRegLogic employeeRegLogic = new EmployeeRegLogic();
            return employeeRegLogic.PostData(InsertEmp);

        }

        [HttpPost]
        [Route("Employee/CredentialCheck")]
        public ReturnObject CredentialCheck(LoginCheck login )
        {
            EmployeeRegLogic employeeRegLogic = new EmployeeRegLogic();
            return employeeRegLogic.CredentialCheck(login);
        }

        [HttpGet]
        [Route("Employee/CheckEmailOrUsername/Email/Username")]
        public List<Employee> CheckEmailOrUsername(string Email, string Username)
        {
            EmployeeRegLogic employeeRegLogic = new EmployeeRegLogic();
            return employeeRegLogic.CheckEmailOrUsername(Email, Username);
        }


        [HttpGet]
        [Route("Employee/IsEmail/Email")]
        public Ismail IsEmail(string Email)
        {
            EmployeeRegLogic employeeRegLogic = new EmployeeRegLogic();
            return employeeRegLogic.IsEmail(Email);

        }


    }
}
