import { Component, inject } from '@angular/core';
import { FormsModule,NgForm } from '@angular/forms';
import { RequestService } from '../_services/request.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-requestform',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './requestform.component.html',
  styleUrl: './requestform.component.css'
})
export class RequestformComponent {
  private formService=inject(RequestService)
  model:any={}
  showList = false;
  requests:any;
  errors: any;

  ngOnInit() {
    this.getRequests();
    
  }
  getRequests() {
    this.formService.getRequests().subscribe({
      next:(res) => {
        this.requests=res
        
        console.log(this.requests)
      },
      error:e=>console.log(e),
    })
  }
  displayRequests(){
    this.getRequests()
    this.requests.sort((a: { dueDate: { getTime: () => number; }; }, b: { dueDate: { getTime: () => number; }; }) => a.dueDate.getTime() - b.dueDate.getTime())
    this.showList = true;
  }
  toggle(){
    this.showList=!this.showList
  }
  submitForm(){
    this.errors=[]
    this.formService.createRequest(this.model).subscribe({
      next:()=>{
        this.getRequests();
      },
      error:e=>{this.errors=e
        console.log(this.errors)
      }

    })
    
  }
}
