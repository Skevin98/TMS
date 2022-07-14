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
    public class DriverRepository : IUserRepository<Driver>
    {
        public ApplicationDbContext Context { get; }
        private DbSet<Driver> table = null;

        public DriverRepository(ApplicationDbContext appDbContext)
        {
            Context = appDbContext;
            table = appDbContext.Drivers;

        }

        public async Task<Driver> GetByAccoundId(string id)
        {
            return await table.AsNoTracking().SingleOrDefaultAsync(e => e.AccountId == id);
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            List<SelectListItem> drivers = table.OrderBy(d => d.LastName)
                        .Select(d =>
                        new SelectListItem
                        {
                            Value = d.Id.ToString(),
                            Text = d.LastName +' '+d.FirstName
                        }).ToList();

            return new SelectList(drivers, "Value", "Text");
        }
    }
}
