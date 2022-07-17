using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public interface IVehicleService
    {
        IList<VehicleViewModel> GetAllVehicle();
        VehicleViewModel GetVehicleById(Guid id);
        EditDriverViewModel GetEditVehicle(Guid? id);

        IEnumerable<SelectListItem> GetAvailableVehicle(Guid? id);

        void AddVehicle(VehicleViewModel vhc);
        void UpdateVehicle(VehicleViewModel vhc);
        void DeleteVehicle(VehicleViewModel vhc);
    }
}
