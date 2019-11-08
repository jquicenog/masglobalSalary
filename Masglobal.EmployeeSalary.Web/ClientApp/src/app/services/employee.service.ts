import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  API_URI = 'http://localhost:64424/api';

  constructor(private http: HttpClient) { }
  
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.API_URI}/employee`);
  }
  getEmployeeById(id): Observable<Employee> {
    return this.http.get<Employee>(`${this.API_URI}/employee/${id}`);
  }  
}
