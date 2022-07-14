using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public interface IDeliveryFormService
    {
        IList<DeliveryFormViewModel> GetAllDeliveryForm();


        IList<DeliveryFormViewModel> GetDeliveryFormByClient(Guid CId);

        IList<DeliveryFormViewModel> GetDeliveryFormByDriver(Guid DId);

        DeliveryFormViewModel GetDeliveryFormById(Guid id);

        //EditDeliveryFormViewModel GetEditDelivery(Guid? id);

        void AddDeliveryForm(DeliveryFormViewModel del);
        Task UpdateDeliveryForm(DeliveryFormViewModel del);
        void DeleteDeliveryForm(DeliveryFormViewModel del);
    }
}
