import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { IFormFile } from '../microsoft/asp-net-core/http/models';
import type { IActionResult } from '../microsoft/asp-net-core/mvc/models';

@Injectable({
  providedIn: 'root',
})
export class FileService {
  apiName = 'Default';
  

  download = (fileName: string) =>
    this.restService.request<any, IActionResult>({
      method: 'GET',
      url: `/download/${fileName}`,
    },
    { apiName: this.apiName });
  

  downloadBySubDirectory = (subDirectory: string) =>
    this.restService.request<any, IActionResult>({
      method: 'GET',
      url: '/Download',
      params: { subDirectory },
    },
    { apiName: this.apiName });
  

  uploadByFormFilesAndSubDirectory = (formFiles: IFormFile[], subDirectory: string) =>
    this.restService.request<any, IActionResult>({
      method: 'POST',
      url: '/Upload',
      params: { subDirectory },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
