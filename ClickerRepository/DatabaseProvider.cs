using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace ClickerRepository
{
    public class DatabaseProvider: IDisposable
    {
        SqlConnection connection;
        IConfiguration configuration;
        
        public DatabaseProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            OpenConnection();
        }

        public void Dispose()
        {
            connection.Close();
        }
        
        public SqlConnection OpenConnection()
        {
            connection = new SqlConnection(configuration.GetConnectionString("database"));
            connection.Open();
            return connection;
        }
    }
}