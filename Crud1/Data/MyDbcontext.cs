using Microsoft.EntityFrameworkCore;
using Crud1.Models;

namespace Crud1.Data
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options)
            : base(options)
        {
        }

        public DbSet<DowolnaKlasaModel> Model { get; set; }
        public DbSet<DrugaKlasaModel> Model2 { get; set; }
    }
}