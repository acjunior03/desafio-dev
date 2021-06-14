using System.Collections.Generic;

namespace Domain.Entities
{
    public class GroupByStore
    {
        public string Storename { get; set; }
        public List<TransactionDescription> ListTransactionDescription { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
