﻿using ApiCrud.Students;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data;

public class AppDbContext:DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Students.db");
        base.OnConfiguring(optionsBuilder);
    }
}