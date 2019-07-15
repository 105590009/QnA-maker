using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QnA_Maker.Models;

namespace QnA_Maker.DataAccessLayer
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<QnA> QnAs { get; set; }
        public DbSet<Answer> answers { get; set; }
       
    }
}
