﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Insight.Database.Schema;

namespace CoderFoundry.InsightUserStore.DB
{
    public static class Program
    {
        static void Main()
        {
            var schema = new SchemaObjectCollection();
            schema.Load(Assembly.GetExecutingAssembly());

            // automatically create the database
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var databaseName = "jonesh-financialportal-db";
            SchemaInstaller.CreateDatabase(connectionString);

            // automatically install it, or upgrade it
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var installer = new SchemaInstaller(connection);
                new SchemaEventConsoleLogger().Attach(installer);
                installer.Install(databaseName, schema);
            }
        }

    
    }

    
}
