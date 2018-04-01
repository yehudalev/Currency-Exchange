using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class RatesDBContext : DbContext
    {
        public RatesDBContext() : base()
        {
            
        }

        public DbSet<HistoricalRateData> histories { get; set; }
        public DbSet<Currency> currencies { get; set; }
    }
}
