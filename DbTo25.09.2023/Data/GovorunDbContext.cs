using CW_25._09._2023.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_25._09._2023.Data
{
    public class GovorunDbContext : DbContext
    {
        public GovorunDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Govorun;Integrated Security=True;Connect Timeout=30;";
            optionsBuilder.UseSqlServer(conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnswerFelling>().HasData(new[]
            {
                new AnswerFelling() {Id = 1, Answers = "I'm fine"},
                new AnswerFelling() {Id = 2, Answers = "As usual"},
                new AnswerFelling() {Id = 3, Answers = "Bad"},
                new AnswerFelling() {Id = 4, Answers = "Wie zu Hitlers Lebzeiten!"}
            });
            modelBuilder.Entity<Greeting>().HasData(new[]
            {
                new Greeting() {Id = 1, Answer = "Hello"},
                new Greeting() {Id = 2, Answer = "Hi Gitler"},
                new Greeting() {Id = 3, Answer = "Good afternoon"}
            });
            modelBuilder.Entity<WeatherAnswer>().HasData(new[]
            {
                new WeatherAnswer() {Id = 1, Answer = "Warm"},
                new WeatherAnswer() {Id = 2, Answer = "Not too warm"},
                new WeatherAnswer() {Id = 3, Answer = "Cold"},
                new WeatherAnswer() {Id = 4, Answer = "Wie im 2. Weltkrieg!"}
            });
            modelBuilder.Entity<Farewell>().HasData(new[]
            {
                new Farewell() {Id = 1, Farewells = "See u later"},
                new Farewell() {Id = 2, Farewells = "Bye"},
                new Farewell() {Id = 3, Farewells = "Auf Wiedersehen!"}
            });

        }
        public DbSet<Greeting> Greets { get;set; }
        public DbSet<AnswerFelling> FellAnswers { get;set; }
        public DbSet<WeatherAnswer> WeatherAnswers { get;set; }
        public DbSet<Farewell> Farewells { get;set; }
    }
}
