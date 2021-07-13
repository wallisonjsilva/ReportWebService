using Microsoft.EntityFrameworkCore;

namespace ReportWebService.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public virtual DbSet<Report> Reports { get; set; }

        public virtual DbSet<Tenant> Tenants { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<LoginToken> LoginTokens { get; set; }


    }
}
