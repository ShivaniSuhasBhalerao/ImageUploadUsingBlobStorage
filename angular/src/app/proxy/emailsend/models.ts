import type { AuditedEntityDto } from '@abp/ng.core';

export interface EmailData {
  emailToId?: string;
  emailToName?: string;
  emailSubject?: string;
  emailBody?: string;
  ishtmlTemplet: boolean;
  redricturl?: string;
}

export interface EmailSettingsDTO extends AuditedEntityDto<string> {
  emailId?: string;
  name?: string;
  password?: string;
  host?: string;
  port: number;
  useSSL: boolean;
}

export interface EmailtemplateDTO {
  templetseData?: string;
  templateName?: string;
  isActive: boolean;
}

export interface Templatename {
  name?: string;
  creationtime?: string;
}
