using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workrbot.Models;

namespace Workrbot.Data
{
    public class WorkrBotContext : DbContext
    {
        public WorkrBotContext(DbContextOptions<WorkrBotContext> options) : base(options)
        {
        }

        public WorkrBotContext()
        {
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>().ToTable("Setting");
            modelBuilder.Entity<Event>().ToTable("Event");
        }

        public static WorkrBotContext Create()
        {
            return new WorkrBotContext();
        }
    }
}