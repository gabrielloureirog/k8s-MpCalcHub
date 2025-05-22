using Microsoft.EntityFrameworkCore;
using MPCalcHub.Domain.Entities;
using MPCalcHub.Domain.Interfaces.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MPCalcHub.Infrastructure.Data.Repositories;

public class ContactRepository(ApplicationDBContext context) : BaseRepository<Contact>(context), IContactRepository
{
    public override async Task<Contact> GetById(Guid id, bool include = false, bool tracking = false)
    {
        var query = BaseQuery(tracking);

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Contact> GetByEmail(string email, bool include = false, bool tracking = false)
    {
        var Contact = await BaseQuery(tracking)
            .FirstOrDefaultAsync(x => x.Email == email);

        return Contact;
    }

    public async Task<IEnumerable<Contact>> FindBy(int ddd)
    {
        return await FindBy(c => c.DDD == ddd).ToListAsync();
    }
}