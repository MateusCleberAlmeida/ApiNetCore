using Microsoft.EntityFrameworkCore;
using PromoAPI.Models;

namespace PromoAPI.Data
{
    public class ApiDBContext: DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options)
           : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
