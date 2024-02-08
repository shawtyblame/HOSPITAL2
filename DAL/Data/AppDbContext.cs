using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departaments => Set<Department>();
        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<HealingEvent> HealingEvents => Set<HealingEvent>();
        public DbSet<HealingEventType> HealingEventTypes => Set<HealingEventType>();
        public DbSet<Hospitalization> Hospitalizations => Set<Hospitalization>();
        public DbSet<HospitalizationCondition> HospitalizationConditions => Set<HospitalizationCondition>();
        public DbSet<HospitalizationStatus> HospitalizationStatuses => Set<HospitalizationStatus>();
        public DbSet<MedicalCard> MedicalCards => Set<MedicalCard>();
        public DbSet<RequestVisit> RequestVisits => Set<RequestVisit>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserAddicational> UserAdditionals => Set<UserAddicational>();
        public DbSet<UserCredential> UserCredentials => Set<UserCredential>();
        public DbSet<UserMainInfo> UserMainInfos => Set<UserMainInfo>();
        public DbSet<Visit> Visits => Set<Visit>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 2, Name = "Doctor" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 3, Name = "Receptionist" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 4, Name = "User" });
            modelBuilder.Entity<HealingEventType>().HasData(
                new HealingEventType { Id = 1, Name = "Лабораторное Исследование" });
            modelBuilder.Entity<HealingEventType>().HasData(
                new HealingEventType { Id = 2, Name = "Инструментальная Диагностика" });
            modelBuilder.Entity<HealingEventType>().HasData(
                new HealingEventType { Id = 3, Name = "Лекарственная Терапия" });
            modelBuilder.Entity<HealingEventType>().HasData(
                new HealingEventType { Id = 4, Name = "Физиотерапия" });
            modelBuilder.Entity<HealingEventType>().HasData(
                new HealingEventType { Id = 5, Name = "Хирургическое лечение" });
            modelBuilder.Entity<HospitalizationStatus>().HasData
                (new HospitalizationStatus { Id = 1, Name = "Госпитализирован" });
            modelBuilder.Entity<HospitalizationStatus>().HasData
                (new HospitalizationStatus { Id = 2, Name = "Отменено" });
            modelBuilder.Entity<HospitalizationCondition>().HasData(
                new HospitalizationCondition { Id = 1, Name = "Платно"});
            modelBuilder.Entity<HospitalizationCondition>().HasData(
                new HospitalizationCondition { Id = 2, Name = "Бюджет"});
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Man"});
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 2, Name = "Female"});
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Онкологическое отделение" });
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 2, Name = "Хирургическое отделение" });
        }
    }
}
