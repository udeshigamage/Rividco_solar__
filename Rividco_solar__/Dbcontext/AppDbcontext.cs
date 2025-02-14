using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Models;
using System;

namespace Rividco_solar__.Dbcontext
{
    public class AppDbcontext : DbContext 
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
           : base(options)
        {
        }

        public DbSet<Vendor> Vendor { get; set; }
    }
}
