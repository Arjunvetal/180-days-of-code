﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCode
{
    class Program
    {
        static void Main()
        {
            //Connect();
            Employee obj = new Employee
            {
                EmpNo = 7,
                Name = "D'Souza",
                Basic = 10000,
                DeptNo = 10
            };
            //Insert(obj);
            //InsertWithParameters(obj);
            //InsertWithStoredProcedure(obj);

            //QueryReturningSingleValue();
            //SqlDataReader1();
            //SqlDataReaderNextResult();
            //MARS();
            //CallFuncReturningSqlDataReader();
            //Transactions();
            //AsyncCommand();
            AsyncCommand2();
            Console.ReadLine();
        }

        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;User Id=sa;Password=sa";
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();

        }
        

        static async void AsyncCommand()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";

            await cn.OpenAsync();  //async connection
            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(40,'Ganesh',10000,20)";
                
                await cmdInsert.ExecuteNonQueryAsync();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();

        }
        static  void AsyncCommand2()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";

            cn.Open();
            
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "Select * from Employees";
            
            cmdInsert.BeginExecuteReader(delegate (IAsyncResult ar) 
            {
                SqlDataReader dr = cmdInsert.EndExecuteReader(ar);
                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                    //Console.WriteLine(dr[1]);
                }
                dr.Close();
                cn.Close();
            }, null);

            Console.WriteLine("code after begin....");

            

        }
        static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                //cmdInsert.CommandText = "insert into Employees values(4,'Ganesh',10000,20)";
                cmdInsert.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";

                Console.WriteLine(cmdInsert.CommandText);
                Console.ReadLine();
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                cn.Close();
            }

        }
        static void InsertWithParameters(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        static void InsertWithStoredProcedure(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployee";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            //TO DO ---- CALL UPDATE AND DELETE WITH STORED PROCEDURES

        }

        //one row, one column only 
        static void QueryReturningSingleValue()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select count(*) from Employees";
                //cmdSelect.CommandText = "Select * from Employees";

                object retval = cmdSelect.ExecuteScalar();

                Console.WriteLine(retval);

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        //read multiple rows
        static void SqlDataReader1()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees";
                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                    //Console.WriteLine(dr[1]);
                }
                dr.Close();
                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        //multiple results
        static void SqlDataReaderNextResult()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = cn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "Select * from Employees;select * from Departments";
                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                }

                Console.WriteLine();
                Console.WriteLine();
                dr.NextResult();
                while (dr.Read())
                {
                    Console.WriteLine(dr["DeptName"]);
                }
                dr.Close();
                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        static void MARS()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKJuly2022;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                Console.WriteLine((drDepts["DeptName"]));

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    Console.WriteLine(("    " + drEmps["Name"]));
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }

        static void CallFuncReturningSqlDataReader()
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[1]);
            }
            dr.Close();

            //Console.WriteLine(cn.State);
            Console.ReadLine();
        }
         //static SqlConnection cn = new SqlConnection();
        static SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJuly2022;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Employees ";

            SqlDataReader dr = cmdInsert.ExecuteReader(CommandBehavior.CloseConnection);
            //SqlDataReader dr = cmdInsert.ExecuteReader();
            //cn.Close();

            return dr;
        }
        static void Transactions()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJuly2022;Integrated Security=True";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.Transaction = t;

            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(10, 'Shweta', 12345, 30)";

            SqlCommand cmdInsert2 = new SqlCommand();
            cmdInsert2.Connection = cn;
            cmdInsert2.Transaction = t;

            cmdInsert2.CommandType = System.Data.CommandType.Text;
            cmdInsert2.CommandText = "insert into Employees values(20, 'Shweta', 12345, 30)";
            try
            {
                cmdInsert.ExecuteNonQuery();
                cmdInsert2.ExecuteNonQuery();
                t.Commit();
                Console.WriteLine("no errors- commit");
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine("Rollback");
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }

    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
}
