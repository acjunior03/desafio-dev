using System.Collections.Generic;

namespace ServiceApplication.Models
{
    public class ModelTransaction
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Nature { get; set; }
        public string Signal { get; set; }
        public long Type { get; set; }

        public virtual List<ModelTransactionDescription> ListModelTransactionDescription { get; set; }
    }
}
