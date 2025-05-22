using Microsoft.EntityFrameworkCore;
using MPAzureFunctions.Entities;

namespace Fiap.Fase3.MPAzureFunctions
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Contact> Contatos { get; set; }

        public async Task<Contact?> GetContactById(Guid id)
        {
            return await Contatos
                .FromSqlRaw("SELECT * FROM dbo.GetContactById({0})", id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await Contatos
                .FromSqlRaw("SELECT * FROM dbo.GetContacts()")
                .ToListAsync();
        }

        public async Task<List<Contact>> GetContactsByDDD(int ddd)
        {
            return await Contatos
                .FromSqlRaw("SELECT * FROM dbo.GetContactsByDDD({0})", ddd)
                .ToListAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }
    }
}