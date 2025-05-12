using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.DataContext
{
    public class RTEGMS_DB : DbContext
    {
        //public RTEGMS_DB() : base("name=RTEGMS_DB")
        //{

        //}

        private readonly IConfiguration configuration;
        
        public RTEGMS_DB(IConfiguration configuration)
        {           
            this.configuration = configuration;
        }

        public DbSet<Menu_user> menu_user { get; set; }

        

        public string GetConnectionString()
        {
            return configuration.GetConnectionString("RTEGMS_DB");
        }

    }
}
