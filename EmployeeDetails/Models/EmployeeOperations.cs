using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeDetails.Models
{
    public class EmployeeOperations
    {
        SqlConnection conn = new SqlConnection();

        //Connection with database
        private void connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["EmployeeDB"].ToString();
            conn = new SqlConnection(connString);
            conn.Open();
        }

        //retrives the data from table
        public List<EmployeeModel> getData(string sal, string age, string location)
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            connection();
            string query = "", stroutput = "";
            if (!string.IsNullOrEmpty(sal))
            {
                stroutput = stroutput + "salary=" + sal + " and ";
            }
            if (!string.IsNullOrEmpty(age))
            {
                stroutput = stroutput + "age=" + age + " and ";
            }
            if (!string.IsNullOrEmpty(location))
            {
                stroutput = stroutput + "location='" + location + "' and ";
            }
            if (stroutput.Length != 0)
            {
                stroutput = stroutput.Trim();
                stroutput = stroutput.Remove(stroutput.Length - 3);
                query = "select * from Employee where " + stroutput + "";
            }
            else
            {
                query = "select * from Employee";
            }

            SqlCommand sqlcmd = new SqlCommand(query, conn);
            SqlDataReader sdr = sqlcmd.ExecuteReader();
            while (sdr.Read())
            {
                lstEmployee.Add(
                    new EmployeeModel
                    {
                        ID = Convert.ToInt32(sdr.GetValue(0)),
                        Name = sdr.GetValue(1).ToString(),
                        age = Convert.ToInt32(sdr.GetValue(2)),
                        salary = Convert.ToInt32(sdr.GetValue(3)),
                        location = sdr.GetValue(4).ToString(),
                        maritalStatus = sdr.GetValue(5).ToString()
                    });
            }
            conn.Close();
            return lstEmployee;
        }

        //delete the record from table
        public void Delete(int ID)
        {
            connection();
            SqlCommand sqlcmd = new SqlCommand("delete from Employee where ID=" + ID + "", conn);
            sqlcmd.ExecuteNonQuery();
        }
    }
}