using System;

namespace ServiceApplication.Models
{
   public  class ModelTransactionDescription
    {
        public long Id { get; set; }
        public long TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }

        public virtual ModelTransaction Transaction { get; set; }
    }
}
