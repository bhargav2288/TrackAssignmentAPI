using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAssignmentAPI.Models
{
    public class DbModel : DbContext
    {
        public DbModel(DbContextOptions<DbModel>options) :base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
    }
}
