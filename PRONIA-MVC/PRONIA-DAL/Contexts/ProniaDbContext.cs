using Microsoft.EntityFrameworkCore;
using PRONIA_DAL.Models;

namespace PRONIA_DAL.Contexts
{
    public class ProniaDbContext : DbContext
    {
        public DbSet<SliderItem> SliderItesms { get; set; }

        public ProniaDbContext(DbContextOptions<ProniaDbContext> options): base(options)
        {
            

        }


    }
}
