using taller_mecanico.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace taller_mecanico.Data.DataContext
{
    public class BaseDataContext: DbContext
    {
        public BaseDataContext(DbContextOptions<BaseDataContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Mechanic1> Mechanic { get; set; }
    }
}
