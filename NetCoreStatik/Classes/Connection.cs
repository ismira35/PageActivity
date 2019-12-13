using Microsoft.EntityFrameworkCore;
using NetCoreStatik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStatik.Classes
{
    public class Connection
    {
        private static UsersContext connection;
       
        private Connection()
        {
         
        }
        public static UsersContext NewConnection()
        {
            if (connection == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UsersContext>();
                optionsBuilder.UseSqlServer("Server=DENO-BILGISAYAR\\SQLEXPRESS;Database=Users;Trusted_Connection=True;MultipleActiveResultSets=true");
                connection = new UsersContext(optionsBuilder.Options);
            }
            return connection;

        }
    }
}
