import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookContainerService {
  apiName = 'Default';
  

  deleteFile = (filename: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/book-container/file',
      params: { filename },
    },
    { apiName: this.apiName });
  

  getBytes = (filename: string) =>
    this.restService.request<any, number[]>({
      method: 'GET',
      url: '/api/app/book-container/bytes',
      params: { filename },
    },
    { apiName: this.apiName });
  

  saveBytes = (bytes: number[], extension: string) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/book-container/save-bytes',
      params: { extension },
      body: bytes,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
