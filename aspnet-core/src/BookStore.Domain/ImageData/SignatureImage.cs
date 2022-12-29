using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.ImageData
{
    public class SignatureImage:FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public byte[] MyImage { get; set; }
    }
}
