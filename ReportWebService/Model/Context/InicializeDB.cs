using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ReportWebService.Model.Context
{
    public class InicializeDB
    {
        public static void StartDB(IApplicationBuilder app)
        {
            try
            {
                var scope = app.ApplicationServices.CreateScope();
                MySQLContext context = scope.ServiceProvider.GetRequiredService<MySQLContext>();
                StartDB(context);
            } catch(Exception ex)
            {
                System.Console.WriteLine("Falha aqui:");
                System.Console.WriteLine(ex);
            }
        }
        public static void StartDB(MySQLContext context)
        {
            context.Database.Migrate();
        }

    }
}
