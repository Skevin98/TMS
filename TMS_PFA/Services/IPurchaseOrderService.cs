using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
   public interface IPurchaseOrderService
    {
        IList<PurchaseOrderViewModel> GetAllOrder();

        IList<PurchaseOrderViewModel> GetOrderByClient(Guid CId);

        IList<PurchaseOrderViewModel> GetOrderByDriver(Guid DId);

        PurchaseOrderViewModel GetOrderById(Guid id);
        //EditPurchaseOrderViewModel GetEditPurchaseOrder(Guid? id);

        void AddOrder(PurchaseOrderViewModel ord);
        void UpdateOrder(PurchaseOrderViewModel ord);
        void DeleteOrder(PurchaseOrderViewModel ord);
    }
}
