using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace MinhaAPICore.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public System.Data.Entity.DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
