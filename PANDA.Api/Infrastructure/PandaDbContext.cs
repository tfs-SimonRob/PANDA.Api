﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PANDA.Api.Models;

namespace PANDA.Api.Infrastructure
{
    public class PandaDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateTimeOffsetConverter = new ValueConverter<DateTimeOffset, string>(
                v => v.ToString("o"), // ISO 8601 string for SQLite
                v => DateTimeOffset.Parse(v));

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentDate)
                .HasConversion(dateTimeOffsetConverter);

            // Optional: enforce enum-to-int conversion
            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<int>();
        }
    }
}