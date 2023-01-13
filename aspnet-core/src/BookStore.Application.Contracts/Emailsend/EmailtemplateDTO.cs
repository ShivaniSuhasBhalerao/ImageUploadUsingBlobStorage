
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Emailsend
{
    public class EmailtemplateDTO
    {
        public string TempletseData { get; set; }
        public string TemplateName { get; set; }
        public bool isActive { get; set; }
    }

    public class EmailSendvalue
    {
        public string subject { get; set; }
        public string body { get; set; }
    }
}
