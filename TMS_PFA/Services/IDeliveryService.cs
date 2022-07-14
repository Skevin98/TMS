using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public interface IDeliveryService
    {
        IList<DeliveryViewModel> GetAllDelivery();

        IList<DeliveryViewModel> GetDeliveryByClient(Guid CId);

        IList<DeliveryViewModel> GetDeliveryByOrder(Guid OId);

        IList<DeliveryViewModel> GetDeliveryByDriver(Guid DId);

        IList<DeliveryViewModel> GetDeliveryByVehicle(Guid VId);

        DeliveryViewModel GetDeliveryById(Guid id);
        
        EditDeliveryViewModel GetEditDelivery(Guid? id);

        void AddDelivery(EditDeliveryViewModel del);
        Task UpdateDelivery(EditDeliveryViewModel del);
        void DeleteDelivery(DeliveryViewModel del);
    }
}
