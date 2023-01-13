import { Component, OnInit } from '@angular/core';
import { TestService } from '@proxy/acme/book-store/identity';
import { SendPasswordResetCodeDto } from '@proxy/volo/abp/account';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  sendPasswordResetCodeDto ={} as SendPasswordResetCodeDto; 
  constructor(public testService:TestService) { }

  ngOnInit(): void {
  }
  
  sendResetCode(event){
    console.log("event === ",event);
    console.log("this.sendPasswordResetCodeDto === ",this.sendPasswordResetCodeDto);
    this.testService.sendPasswordResetCode(this.sendPasswordResetCodeDto).subscribe(x => {
      alert("Code sent successfully")
    });
  }
}
