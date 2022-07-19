using AssMVCCrudUsingADOEmp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AssMVCCrudUsingADOEmp.DAL
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public EmployeeDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string query = "select * from employees";
            cmd=new SqlCommand(query,con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dr["eid"]);
                employee.Name = dr["ename"].ToString();
                employee.Salary = Convert.ToInt32(dr["esalary"]);
                employees.Add(employee);

            }
            con.Close();

            return employees;
        }

        public Employee GetEmployeeById(int pid)
        {
            Employee e1 = new Employee();
            string query = "select * from employees where eid=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", pid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {                    
                    e1.Id = Convert.ToInt32(dr["eid"]);
                    e1.Name = dr["ename"].ToString();
                    e1.Salary = Convert.ToInt32(dr["esalary"]);

                }                
            }
            con.Close();
            return e1;
        }

        public int AddEmployee(Employee e)
        {
            string query = "insert into employees values(@name,@salary)";
            cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", e.Name);
            cmd.Parameters.AddWithValue("@salary", e.Salary);
            con.Open();
            int result=cmd.ExecuteNonQuery();
            con.Close();
            return result; 
        }

        public int UpdateEmployee(Employee e)
        {
            string query = "update employees set ename=@name, esalary=@salary where eid=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.Parameters.AddWithValue("@name",e.Name);
            cmd.Parameters.AddWithValue("@salary", e.Salary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            string query = "delete from employees where eid=@id";
            cmd= new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
