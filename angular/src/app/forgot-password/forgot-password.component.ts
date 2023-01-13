import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestService } from '@proxy/acme/book-store/identity';
import { EmailService } from '@proxy/emailsend';
import { ResetPasswordDto } from '@proxy/volo/abp/account';

export interface EmailData {
  emailToId?: string;
  emailToName?: string;
  emailSubject?: string;
  emailBody?: string;
  ishtmlTemplet: boolean;
  redricturl?: string;
}
@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  input ={}as ResetPasswordDto;
  emailData = {} as EmailData;
  resetPasswordDto ={} as ResetPasswordDto; 
  parms:any;
  constructor(private route:ActivatedRoute,public emailService:EmailService,public test:TestService) { }

  ngOnInit(): void { 
    this.route.params.forEach(x=> {this.parms=x ;console.log(this.parms)})
  }

  sendMail(event){
    console.log("event === ",event);
    console.log("this.emailData === ",this.emailData);
    this.emailService.sendEmail(this.emailData).subscribe(x => {
      alert("Email sent successfully")
    });
  }
  reset()
  {
    this.input.password
    this.input.resetToken = this.parms["resetToken"]
    this.input.userId = this.parms["userId"]
    console.log(this.input)
    this.test.resetPasswordtest(this.resetPasswordDto)
   
  }
}
