﻿using System;
using Volo.Abp.Application.Dtos;

namespace BookStore.Emailsend
{
    public class EmailSettingsDTO :   AuditedEntityDto<Guid>
    {
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
    }
}