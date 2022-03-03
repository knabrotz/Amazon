using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class EFPurchaseRecordRepository : IPurchaseRecordRepository
    {
        private BookstoreContext context;

        public EFPurchaseRecordRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<PurchaseRecord> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchaseRecord(PurchaseRecord purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
