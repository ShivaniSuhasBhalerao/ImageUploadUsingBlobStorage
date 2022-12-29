using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Books
{
    public class Book:FullAuditedAggregateRoot<Guid>
    {
        public Book()
        {
        }

        public Book(Guid id, string name, string image, string mimeType, double fileSize)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Image = image ?? throw new ArgumentNullException(nameof(image));
            MimeType = mimeType ?? throw new ArgumentNullException(nameof(mimeType));
            FileSize = fileSize;
        }

        public string Name { get; set; }
         public string Image { get; set; }
      

        public string MimeType { get; set; }

        public double FileSize { get; set; }
    }
}
