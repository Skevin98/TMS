using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;
using TMS_PFA.Repositories;
using TMS_PFA.ViewModels;

namespace TMS_PFA.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IRepository<Receipt> repository;

        public ReceiptService(IRepository<Receipt> repository)
        {
            this.repository = repository;
        }

        public void AddReceipt(ReceiptViewModel rec)
        {
            Receipt receipt = new Receipt
            {
                Id = rec.Id,
                Type = rec.Type,
                Date = rec.Date,
                Weight = rec.Weight,
                Height = rec.Height,
                Width = rec.Width,
                Quantity = rec.Quantity,
                Details = rec.Details,
                PurchaseId = rec.PurchaseId
            };
            repository.Add(receipt);
        }

        public void DeleteReceipt(ReceiptViewModel rec)
        {
            throw new NotImplementedException();
        }

        public IList<ReceiptViewModel> GetAllReceipt()
        {
            IList<Receipt> receipts = repository.GetAll().Result;
            return BindReceiptList(receipts);
        }

        private IList<ReceiptViewModel> BindReceiptList(IList<Receipt> receipts)
        {
            IList<ReceiptViewModel> receiptViewModels = new List<ReceiptViewModel>();
            foreach (Receipt rec in receipts)
            {
                receiptViewModels.Add(new ReceiptViewModel
                {
                    Id = rec.Id,
                    Type = rec.Type,
                    Date = rec.Date,
                    Weight = rec.Weight,
                    Height = rec.Height,
                    Width = rec.Width,
                    Quantity = rec.Quantity,
                    Details = rec.Details,
                    PurchaseId = rec.PurchaseId
                });
            }
            return receiptViewModels;
        }

        public ReceiptViewModel GetReceiptById(Guid id)
        {
            Receipt receipt = repository.GetById(id).Result;
            if (receipt == null)
            {
                return new ReceiptViewModel();
            }
            ReceiptViewModel rec = new ReceiptViewModel
            {
                Id = receipt.Id,
                Type = receipt.Type,
                Date = receipt.Date,
                Weight = receipt.Weight,
                Height = receipt.Height,
                Width = receipt.Width,
                Quantity = receipt.Quantity,
                Details = receipt.Details,
                PurchaseId = receipt.PurchaseId

            };
            return rec;

        }

        public void UpdateReceipt(ReceiptViewModel rec)
        {
            throw new NotImplementedException();
        }
    }
}
