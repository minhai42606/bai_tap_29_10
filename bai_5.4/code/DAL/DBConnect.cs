using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DBConnect
    {
        protected string connectionString = "server=localhost;port=3306;database=hoteldb;uid=root;pwd=123456789;";

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
