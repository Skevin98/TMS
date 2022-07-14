using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Data;
using TMS_PFA.Models;

namespace TMS_PFA.Repositories
{
    public class ClientRepository : IUserRepository<Client>
    {
        public ApplicationDbContext Context { get; }
        private DbSet<Client> table = null;

        public ClientRepository(ApplicationDbContext appDbContext)
        {
            Context = appDbContext;
            table = appDbContext.Clients;

        }

        public async Task<Client> GetByAccoundId(string id)
        {
            return await table.AsNoTracking().SingleOrDefaultAsync(e => e.AccountId == id);
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            throw new NotImplementedException();
        }
    }
}
