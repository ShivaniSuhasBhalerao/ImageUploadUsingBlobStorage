import { AuthService, RestService } from '@abp/ng.core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BookService, CreateBookDto } from '@proxy/books';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  formdata: FormData;
  imageSrc: string;
  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }
  //   tempFile: File;
  //   profileUrl: Observable<string | null>;
  //     @ViewChild('imgCustomer', { static: true }) imgCustomer: ElementRef;


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
  // export interface CreateBookDto {
  //   name?: string;
  //   image?: string;
  //   base64?: string;
  //   mimeType?: string;
  //   fileSize?: string;
  //   fileUrl?: string;
  // }

  filedata: any;
  filesize: any;
  contenttype: any;
  upload(event) {
    debugger
    // this.bookCreateAndUpdateDto.fileSize=event.target.files[0].size;
    // this.bookCreateAndUpdateDto.mimeType=event.target.files[0].type;
    // this.bookCreateAndUpdateDto.image = event.target.files[0].name;//event.currentFiles[0].name;

    let reader = new FileReader(); // HTML5 FileReader API

    let file = event.target.files[0];
    const formdata = new FormData();
    formdata.append('File', file, file.name);
    this.formdata = formdata;
    // if (event.target.files[0]) {

    //     reader.readAsDataURL(file);



    //     // When file uploads set it to file formcontrol

    //     reader.onloadend = (e) => {

    //         this.filedata = reader.result;

    //         // this.bookCreateAndUpdateDto.base64 = this.filedata;

    //         // this.bookCreateAndUpdateDto.base64 = this.bookCreateAndUpdateDto.base64.split(',')[1];

    //         // ChangeDetectorRef since file is loading outside the zone

    //     }

    // }

  }
  submit() {
    // this.bookService.uploadByInput(this.formdata as any).subscribe(x => {

    //   alert("books created");
    // });

    this.bookService.request({
      method: 'POST',
      url: '/api/book-store/books/upload?Name=jon', body: this.formdata
    }).subscribe(x => {
      alert("books created");
    });

  }
}
