import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RequestformComponent } from './requestform/requestform.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RequestformComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
 
  http=inject(HttpClient)
  title = 'client';
  requests:any

  ngOnInit(): void {
   
  }
}
