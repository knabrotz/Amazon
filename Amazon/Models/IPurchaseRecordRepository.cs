using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public interface IPurchaseRecordRepository
    {
        IQueryable<PurchaseRecord> Purchases { get; }

        void SavePurchaseRecord(PurchaseRecord purchase);
    }
}
