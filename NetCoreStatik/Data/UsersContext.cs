using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetCoreStatik.Models
{
    public class UsersContext : DbContext
    {

        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options) { }
        
        

        public DbSet<NetCoreStatik.Models.Events> Events { get; set; }
    }
}
