using CrudSinger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace CrudSinger.Database
{
    public class SingerContext:DbContext
    {
        public DbSet<SingerModel> TbSingers { get; set; }
        public SingerContext()
        {
            //Solo necesario para iniciar SQLite en iOS
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "SingersDB.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
