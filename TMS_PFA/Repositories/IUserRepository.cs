using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Repositories
{
    public interface IUserRepository<T>
    {
        Task<T> GetByAccoundId(string id);

        IEnumerable<SelectListItem> GetSelectList();

    }
}
