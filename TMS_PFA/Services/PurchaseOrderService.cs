using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IRepository<PurchaseOrder> repository;

        public PurchaseOrderService(IRepository<PurchaseOrder> repository)
        {
            this.repository = repository;
        }

        public void AddOrder(PurchaseOrderViewModel ord)
        {
            PurchaseOrder order = new PurchaseOrder
            {
                Id = ord.Id,
                Type = ord.Type,
                Date = DateTime.UtcNow,
                Weight = ord.Weight,
                Height = ord.Height,
                Width = ord.Width,
                Quantity = ord.Quantity,
                Starting = ord.Starting,
                Destination = ord.Destination,
                Details = ord.Details,
                ClientId = ord.ClientId
            };
            repository.Add(order);
        }

        public void DeleteOrder(PurchaseOrderViewModel ord)
        {
            throw new NotImplementedException();
        }

        public IList<PurchaseOrderViewModel> GetAllOrder()
        {
            IList<PurchaseOrder> orders = repository.GetAll().Result;
            return BindOrderList(orders);
        }

        public IList<PurchaseOrderViewModel> GetOrderByClient(Guid CId)
        {
            IList<PurchaseOrder> allOrders = repository.GetAll().Result;
            IList<PurchaseOrder> orders = new List<PurchaseOrder>();
            foreach (PurchaseOrder ord in allOrders)
            {
                if (ord.ClientId.Equals(CId))
                {
                    orders.Add(ord);
                }
            }
            return BindOrderList(orders);
        }

        private IList<PurchaseOrderViewModel> BindOrderList(IList<PurchaseOrder> orders)
        {
            IList<PurchaseOrderViewModel> purchaseOrderViewModels = new List<PurchaseOrderViewModel>();
            foreach (PurchaseOrder ord in orders)
            {
                purchaseOrderViewModels.Add(new PurchaseOrderViewModel
                {
                    Id = ord.Id,
                    Type = ord.Type,
                    Date = ord.Date,
                    Weight = ord.Weight,
                    Height = ord.Height,
                    Width = ord.Width,
                    Quantity = ord.Quantity,
                    Starting = ord.Starting,
                    Destination = ord.Destination,
                    Details = ord.Details,
                    ClientId = ord.ClientId
                });
            }
            return purchaseOrderViewModels;
        }

        public PurchaseOrderViewModel GetOrderById(Guid id)
        {
            PurchaseOrder order = repository.GetById(id).Result;
            if (order == null)
            {
                return new PurchaseOrderViewModel();
            }
            PurchaseOrderViewModel ord = new PurchaseOrderViewModel
            {
                Id = order.Id,
                Type = order.Type,
                Date = order.Date,
                Weight = order.Weight,
                Height = order.Height,
                Width = order.Width,
                Quantity = order.Quantity,
                Starting = order.Starting,
                Destination = order.Destination,
                Details = order.Details,
                ClientId = order.ClientId
            };
            return ord;
        }

        public void UpdateOrder(PurchaseOrderViewModel ord)
        {
            throw new NotImplementedException();
        }

        public IList<PurchaseOrderViewModel> GetOrderByDriver(Guid DId)
        {
            IList<PurchaseOrder> allOrders = repository.GetIncludes(d => d.Deliveries);
            IList<PurchaseOrder> orders = new List<PurchaseOrder>();
            foreach (PurchaseOrder ord in allOrders)
            {
                if (ord.Deliveries.Exists(d=>d.DriverId.Equals(DId)))
                {
                    orders.Add(ord);
                }
            }
            return BindOrderList(orders);
        }


    }
}
