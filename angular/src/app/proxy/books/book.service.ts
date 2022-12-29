import type { BooksDto, CreateBookDto } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  apiName = 'Default';
  

  getCustomerBlobInStreamByFilenameAndUserId = (filename: string, userId: string) =>
    this.restService.request<any, number[]>({
      method: 'GET',
      url: '/api/book-store/books/content',
      params: { filename, userId },
    },
    { apiName: this.apiName });
  

  uploadByInput = (input: CreateBookDto) =>
    this.restService.request<any, BooksDto[]>({
      method: 'POST',
      url: '/api/book-store/books/upload',
      params: { name: input.name },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
