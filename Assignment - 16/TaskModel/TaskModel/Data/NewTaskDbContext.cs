using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskModel.Models;

namespace TaskModel.Data
{
    public class NewTaskDbContext : DbContext
    {
        public NewTaskDbContext (DbContextOptions<NewTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskModel.Models.NewTask> NewTask { get; set; } = default!;
    }
}
