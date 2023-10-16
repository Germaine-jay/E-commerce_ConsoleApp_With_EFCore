using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DAL.Data
{
    
    public class GermaineStoresDbContextFactory : IDesignTimeDbContextFactory<GermaineStoresContext>
    {

        public GermaineStoresDbContextFactory()
        {

        }

        public GermaineStoresContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<GermaineStoresContext>();
            var ConnectionString = @"Data Source=GERMANE-PC\SQLEXPRESS;Initial Catalog=GermaneStoresDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            OptionBuilder.UseSqlServer(ConnectionString);
            return new GermaineStoresContext(OptionBuilder.Options);
        }
    }

}
