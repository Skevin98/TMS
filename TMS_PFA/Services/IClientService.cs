using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public interface IClientService
    {
        IList<ClientViewModel> GetAllClients();
        ClientViewModel GetClientById(Guid id);
        EditClientViewModel GetEditClient(Guid? id);

        void AddClient(ClientViewModel clt);
        void UpdateClient(EditClientViewModel clt);
        void DeleteClient(EditClientViewModel clt);
    }
}
