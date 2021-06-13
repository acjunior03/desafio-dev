using System;

namespace Domain.Entities
{
    public class TransactionDescription
    {
        public long Id { get; set; }
        public long TransactionId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
        public string CPF { get; set; }
        public string Card { get; set; }
        public string StoreOwner { get; set; }
        public string StoreName { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
