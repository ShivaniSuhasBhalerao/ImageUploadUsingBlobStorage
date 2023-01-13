import { Component, OnInit } from '@angular/core';
import { AuthService, RestService } from '@abp/ng.core';
import { HttpClient } from '@angular/common/http';
import { BookService, CreateBookDto } from '@proxy/books';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {

  formdata: FormData;
  imageSrc: string;
  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }
  bookCreateAndUpdateDto = {} as CreateBookDto;
  constructor(private oAuthService: OAuthService, private authService: AuthService, public bookService: RestService) { }
  ngOnInit(): void {
    this.bookService.request({
      method: 'GET',
      url: '/api/book-store/books/content?filename=da0cc6d7-6540-8bc9-f02a-3a086fce09f4', responseType: 'json'
    }).subscribe(x => {
      this.imageSrc = 'data:image/png;base64,' + x.toString().replace('"','');
    });
  }

  login() {
    this.authService.navigateToLogin();
  }
filedata: any;
  filesize: any;
  contenttype: any;
  upload(event) {
    debugger
    
    let reader = new FileReader(); // HTML5 FileReader API

    let file = event.target.files[0];
    const formdata = new FormData();
    formdata.append('File', file, file.name);
    this.formdata = formdata;

  }
  submit() {
 this.bookService.request({
      method: 'POST',
      url: '/api/book-store/books/upload?Name=jon', body: this.formdata
    }).subscribe(x => {
      alert("books created");
    });

  }
}


