import type { FullAuditedEntityDto } from '@abp/ng.core';
import type { IRemoteStreamContent } from '../volo/abp/content/models';

export interface BooksDto extends FullAuditedEntityDto<string> {
  name?: string;
  image?: string;
  base64?: string;
  mimeType?: string;
  fileSize: number;
  fileUrl?: string;
}

export interface CreateBookDto {
  name?: string;
  file: IRemoteStreamContent;
}
