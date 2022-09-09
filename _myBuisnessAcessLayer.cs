using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceDataApp
{
    public class _myBuisnessAcessLayer
    {
        public int  _EmployeeId;
        public string _EmployeeLastName;
        public string _EmployeeFirstName;
        public string _Address;
        public int _Salary;
        public int EmployeeID
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value;  }
        }

        public string FirstName
        {
            get { return _EmployeeFirstName; }
            set { _EmployeeFirstName = value; }
        }

        public string LastName
        {
            get { return _EmployeeLastName; }
            set {  _EmployeeLastName = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
        public _myBuisnessAcessLayer() { }
        public string Insert()
        {
            string con = ConfigurationManager.ConnectionStrings["Dbcon"].ConnectionString;
            using (SqlConnection sqlconn = new SqlConnection(con))
            {
                SqlCommand sqlcmd = new SqlCommand("spSyapa", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@id", EmployeeID);
                sqlcmd.Parameters.AddWithValue("@last", LastName);
                sqlcmd.Parameters.AddWithValue("@first", FirstName);
                sqlcmd.Parameters.AddWithValue("@address", Address);
                sqlcmd.Parameters.AddWithValue("@salary", Salary);
                sqlconn.Open();
                int check = sqlcmd.ExecuteNonQuery();
                if (check > 0)
                    return "PASS";
                else
                    return "FAIL";
            }

        }

    }
}