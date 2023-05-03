using Microsoft.EntityFrameworkCore;

namespace SZC_API.Services
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }
    }
}