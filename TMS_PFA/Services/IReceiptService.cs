using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public interface IReceiptService
    {
        IList<ReceiptViewModel> GetAllReceipt();
        ReceiptViewModel GetReceiptById(Guid id);
        //EditReceiptViewModel GetEditReceipt(Guid? id);
        //IList<ReceiptViewModel> GetReceiptByDriver(Guid DId);

        void AddReceipt(ReceiptViewModel rec);
        void UpdateReceipt(ReceiptViewModel rec);
        void DeleteReceipt(ReceiptViewModel rec);
    }
}
