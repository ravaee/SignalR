using Microsoft.EntityFrameworkCore;
using SignalR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option)
            : base(option)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

    }
}
