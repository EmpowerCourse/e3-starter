using E3Starter.Contracts.Persistence;
using E3Starter.Models;
using E3Starter.Persistence.NHIbernate.Repositories.Base;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3Starter.Persistence.NHIbernate.Repositories;

public class ReferenceRepository : RepositoryBase, IReferenceRepository
{
    public ReferenceRepository(ISession session) : base(session)
    {
    }

    public async Task<List<Role>> GetRolesAsync()
    {
        return await Session.Query<Role>().ToListAsync();
    }
}
