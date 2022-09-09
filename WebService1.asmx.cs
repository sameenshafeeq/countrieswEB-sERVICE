using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceDataApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string insertEmpoyees(int id,string lastname, string firstname, string address , int Salary)
        {
            _myBuisnessAcessLayer b1 = new _myBuisnessAcessLayer
            {
                EmployeeID = id,
                FirstName = firstname,
                LastName = lastname,
                Address = address,
                Salary = Salary
            };

            string status = b1.Insert();
            if (status == "PASS")
                return "Employee details inserted!!";
            else
                return "Employees details cannot be inserted!";
        }
    }
}
