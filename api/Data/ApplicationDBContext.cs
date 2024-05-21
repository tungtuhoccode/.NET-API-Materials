using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.Models; //import models from Models directory
using Microsoft.EntityFrameworkCore; //DbContext is in this namespace

namespace api.Data
{
    //class ApplicationDBContext inherits from DbContext
    public class ApplicationDBContext : DbContext 
    
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) //passing the options to the DbContext class
        {
            
        }

        public DbSet<Stock> Stocks {get; set; }
        public DbSet<Comment> Comment {get; set; }
    }
}