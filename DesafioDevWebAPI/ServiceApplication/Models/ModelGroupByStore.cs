using System.Collections.Generic;

namespace ServiceApplication.Models
{
    public class ModelGroupByStore
    {
        public string Storename { get; set; }
        public List<ModelTransactionDescription> ListTransactionDescription { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
