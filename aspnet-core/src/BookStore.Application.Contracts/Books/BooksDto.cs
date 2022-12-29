using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BookStore.Books
{
    public class BooksDto:FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Base64 { get; set; }

        public string MimeType { get; set; }

        public double FileSize { get; set; }
        public string FileUrl { get; set; }

        

    }
}
