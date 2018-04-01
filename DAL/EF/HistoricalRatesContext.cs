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
            //Database.SetInitializer<RatesDBContext>(new DropCreateDatabaseAlways<RatesDBContext>());
        }

        public DbSet<HistoricalRateData> histories { get; set; }
    }
}
