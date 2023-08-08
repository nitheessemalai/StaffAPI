using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using System.Data.SqlClient;

using staff_library.Models;

namespace staff_library.staffrepository
{

    public class staffdatainfo
    {

        public readonly string connectionstring;



        public staffdatainfo()
        {
            connectionstring = @"Data source=DESKTOP-531QTCP;Initial catalog=staff;User Id=sa;Password=Anaiyaan@123";

        }

        public void Insertsp(staffmodel emp)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionstring);

                con.Open();
                con.Execute($"  exec insertstaff '{emp.NAME}','{emp.LASTNAME}','{emp.PHONENUMBER}','{emp.ADDERS}'");
                con.Close();

            }
            catch (SqlException ep)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<staffmodel> selectsp()
        {
            try
            {
                List<staffmodel> constrain = new List<staffmodel>();

                var connection = new SqlConnection(connectionstring);
                connection.Open();
                constrain = connection.Query<staffmodel>("select *from staff").ToList();
                connection.Close();
                
                return constrain;


            }
            catch (SqlException ep)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<staffmodel> selectid(int id)
        {
            try
            {
                List<staffmodel> constrain = new List<staffmodel>();

                var connection = new SqlConnection(connectionstring);
                connection.Open();
                constrain = connection.Query<staffmodel>($"exec liststaffsp {id}").ToList();
                connection.Close();

                return constrain;


            }
            catch (SqlException ep)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updatesp(staffmodel emp)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                connection.Execute($"exec  updatesp {emp.ID},'{emp.NAME}','{emp.LASTNAME}', {emp.PHONENUMBER},'{emp.ADDERS}'");

                    
                connection.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deletesp(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                connection.Execute($"exec deletesp {id}");
                connection.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
