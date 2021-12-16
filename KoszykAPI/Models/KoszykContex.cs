using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoszykAPI.Models;


namespace KoszykAPI.Models
{
    public class KoszykContext : DbContext
    {
        public KoszykContext(DbContextOptions<KoszykContext> options)
            : base(options)
        {
        }

        public DbSet<KoszykItem> KoszykItems { get; set; }
    }

}
