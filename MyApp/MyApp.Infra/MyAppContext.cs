using Microsoft.EntityFrameworkCore;
using MyApp.Domain;
using System;

namespace MyApp.Infra
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
