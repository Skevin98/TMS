using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> repository;
        private readonly IUserRepository<Client> clientRepo;

        public ClientService(IRepository<Client> repository, IUserRepository<Client> clientRepo)
        {
            this.repository = repository;
            this.clientRepo = clientRepo;
        }
        public void AddClient(ClientViewModel clt)
        {
            Client client = new Client
            {
                Id =clt.Id,
                Type = clt.Type,
                Name = clt.Name,
                FirstName = clt.FirstName,
                Address = clt.Address,
                AccountId = clt.AccountId,
                PhoneNumber = clt.PhoneNumber
            };
            repository.Add(client);
            
            
        }

        public void DeleteClient(EditClientViewModel clt)
        {
            throw new NotImplementedException();
        }

        public IList<ClientViewModel> GetAllClients()
        {
            IList<Client> clients = repository.GetIncludes(o => o.PurchaseOrders, p => p.Account );
            return BindClientList(clients);
        }

        private IList<ClientViewModel> BindClientList(IList<Client> clients)
        {
            IList<ClientViewModel> clientViewModels = new List<ClientViewModel>();

            foreach (Client clt in clients)
            {
                clientViewModels.Add(new ClientViewModel
                {
                    Id = clt.Id,
                    FirstName = clt.FirstName,
                    Name = clt.Name,
                    PhoneNumber = clt.PhoneNumber,
                    Address = clt.Address,
                    Type = clt.Type,
                    AccountId = clt.AccountId
                    
                   
                });
            }
            return clientViewModels;
        }

        public ClientViewModel GetClientById(Guid id)
        {
            Client client = repository.GetById(id).Result;
            if (client == null)
            {
                return new ClientViewModel();
            }
            ClientViewModel clt = new ClientViewModel
            {
                Id = client.Id,
                Type = client.Type,
                FirstName = client.FirstName,
                Name = client.Name,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                AccountId = client.AccountId
            };

            return (clt);
        }

        public EditClientViewModel GetEditClient(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(EditClientViewModel clt)
        {
            throw new NotImplementedException();
        }
    }
}
