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
    public class VehicleRepository : IVehicleRepository
    {

        public ApplicationDbContext Context { get; }
        private DbSet<Vehicle> table = null;

        public VehicleRepository(ApplicationDbContext appDbContext)
        {
            Context = appDbContext;
            table = appDbContext.Vehicles;

        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            List<SelectListItem> vehicles = table.OrderBy(v => v.Id)
                        .Select(v =>
                        new SelectListItem
                        {
                            Value = v.Id.ToString(),
                            Text = v.NumberPlate.ToString()
                        }).ToList();

            return new SelectList(vehicles, "Value", "Text");
        }
    }
}
