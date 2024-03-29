﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QnA_Maker.Models;

namespace QnA_Maker.DataAccessLayer
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Question>().HasOne(b=>b.Answers).WithMany(b=>b.Questions).HasForeignKey(b=>b.AnswerFk);

        //}
    }  
}
