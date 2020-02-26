using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Tools.Database.Scripting.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.ApplicationName = typeof(Program).Assembly.GetName().Name;
            connectionStringBuilder.DataSource = "localhost";
            connectionStringBuilder.InitialCatalog = "msdb";
            connectionStringBuilder.IntegratedSecurity = true;

            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                var serverConnection = new ServerConnection(connection);
                var server = new Server(serverConnection);
                var database = server.Databases["msdb"];
                database.EnumObjectPermissions();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
