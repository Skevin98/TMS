﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public interface IDriverService
    {
        IList<DriverViewModel> GetAllDriver();
        DriverViewModel GetDrivertById(Guid id);
        EditDriverViewModel GetEditDriver(Guid? id);

        void AddDriver(DriverViewModel drv);
        void UpdateDriver(DriverViewModel drv);
        void DeleteDriver(DriverViewModel drv);
    }
}
