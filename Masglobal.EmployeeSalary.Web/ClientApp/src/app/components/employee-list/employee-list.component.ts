import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent implements OnInit {

  public employees: any = [];
  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.getEmployees();
  }

  searchEmployee(id) {
    this.employees = [];
    id ? this.getEmployeeById(id) : this.getEmployees();
  }

  getEmployees() {
    this.employeeService.getEmployees().subscribe(
      res => {
        this.employees = res;
        console.log(this.employees);
      },
      err => console.log(err)
    );
  }

  getEmployeeById(id) {
    this.employeeService.getEmployeeById(id).subscribe(
      res => {
        this.employees.push(res);
        console.log(this.employees);
      },
      err => {
        console.log(err);
      }
    );
  }
}
