using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Nature { get; set; }
        public string Signal { get; set; }
        public long Type { get; set; }

        public virtual ICollection<TransactionDescription> Order { get; set; }
    }
}
