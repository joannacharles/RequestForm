import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
private http=inject(HttpClient)
baseUrl='https://localhost:5001/api/'

createRequest(model:any){
  return this.http.post(this.baseUrl+'requests',model)
} 
getRequests(){
  return this.http.get(this.baseUrl+'requests')
} 
}
