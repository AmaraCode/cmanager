using System;
using Microsoft.EntityFrameworkCore;
using AmaraCode.CManager.Models;

namespace AmaraCode.CManager.Infrastructure
{

    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
}
